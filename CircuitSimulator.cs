using SpiceSharp;
using SpiceSharp.Components;
using SpiceSharp.Simulations;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CircuitCraft
{
    public static class CircuitSimulator
    {
        public struct LoadCalculationResult
        {
            public double LoadVoltage { get; set; }
            public double LoadCurrent { get; set; }
            public double LoadResistance { get; set; }
            public CircuitStatus Status { get; set; }
        }

        public enum CircuitStatus
        {
            OK,
            OpenCircuit, 
            ShortCircuit 
        }

        public static void CalculationTest()
        {
            double SourceVoltage = 10;
            double LoadResistance = 0;
            var circuitBlocks = new List<CircuitBlock>
            {
                new CircuitBlock
                {
                    CircuitBlockConnectionType = CircuitBlockConnectionType.Series,
                    CircuitElements = new List<CircuitElement>
                    {
                        new GameResistor { Resistance = 10 },
                    }
                },
                new CircuitBlock
                {
                    CircuitBlockConnectionType = CircuitBlockConnectionType.Parallel,
                    CircuitElements = new List<CircuitElement>
                    {
                        new GameResistor { Resistance = 1 },
                        new GameSource { Voltage = 1 }
                    }
                },
                new CircuitBlock
                {
                    CircuitBlockConnectionType = CircuitBlockConnectionType.Parallel,
                    CircuitElements = new List<CircuitElement>
                    {
                        new GameResistor { Resistance = 1 },
                        new GameSource { Voltage = 1 }
                    }
                },
                new CircuitBlock
                {
                    CircuitBlockConnectionType = CircuitBlockConnectionType.Parallel,
                    CircuitElements = new List<CircuitElement>
                    {
                        new GameResistor { Resistance = 1 },
                        new GameSource { Voltage = 1 }
                    }
                }
            };

            var result = CalculateLoadState(circuitBlocks, SourceVoltage, LoadResistance);
            Debug.WriteLine($"Load Voltage: {result.LoadVoltage}, Load Current: {result.LoadCurrent}, Load Resistance: {result.LoadResistance}, Status: {result.Status}");
        }


        public static LoadCalculationResult CalculateLoadState(List<CircuitBlock> circuitBlocks, double batteryVoltage, double loadResistance)
        {
            var result = new LoadCalculationResult
            {
                LoadResistance = loadResistance,
                LoadVoltage = 0,
                LoadCurrent = 0,
                Status = CircuitStatus.OK 
            };

            List<double> seriesResistances = new List<double>();
            List<double> parallelResistances = new List<double>();
            double seriesVoltageSource = 0.0;
            List<double> parallelVoltageSources = new List<double>();



            foreach (var block in circuitBlocks)
            {
                if (block.CircuitBlockConnectionType == CircuitBlockConnectionType.Series)
                {
                    seriesResistances.Add(block.GetEquivalentResistance());
                    seriesVoltageSource += block.GetEquivalentSourceVoltage();
                }
                else if (block.CircuitBlockConnectionType == CircuitBlockConnectionType.Parallel)
                {
                    parallelResistances.Add(block.GetEquivalentResistance());
                    parallelVoltageSources.Add(block.GetEquivalentSourceVoltage());
                }
            }

            loadResistance = Math.Max(0.0, loadResistance);
            result.LoadResistance = loadResistance; 


            double rs = 0.0;
            if (seriesResistances != null && seriesResistances.Count > 0)
            {
                rs = seriesResistances.Sum(r => Math.Max(0.0, r));
            }

            double rp = 0.0; 
            if (parallelResistances != null && parallelResistances.Count > 0)
            {
                int count = 0;
                foreach (double r in parallelResistances)
                {
                    if (r > 0)
                    {
                        count++;
                    }
                }
                foreach (double r in parallelResistances)
                {
                    double resistance = Math.Max(0.0, r);
                    if (resistance <= 0)
                    {
                        break;
                    }
                    if (count == 1 && resistance > 0)
                    {
                        rp = resistance;
                        break;
                    }
                    rp += 1.0 / resistance;
                }
                rp = 1 / rp;
            }


            double r_total;
            r_total = rs + rp + loadResistance;


            double i_total; 

            if (r_total < 1e-9)
            {
                Console.WriteLine($"Warning: Total resistance is near zero ({r_total} Ohm) -> Short Circuit");
                result.Status = CircuitStatus.ShortCircuit;

                result.LoadCurrent = double.PositiveInfinity;
                result.LoadVoltage = double.PositiveInfinity;
                return result;
            }
            else if (double.IsPositiveInfinity(r_total))
            {
                Console.WriteLine($"Warning: Total resistance is infinite -> Open Circuit");
                result.Status = CircuitStatus.OpenCircuit;
                result.LoadCurrent = 0.0;
                result.LoadVoltage = 0.0; 
                return result;
            }
            else
            {
                double i1 = seriesVoltageSource + batteryVoltage / r_total;
                double i2 = ((parallelVoltageSources[0] / parallelResistances[0]) * (1/((1/rs) + 
                    (1 / parallelResistances[0]) + (1 / parallelResistances[1]) + (1 / parallelResistances[2]))))/rs;
                double i3 = ((parallelVoltageSources[1] / parallelResistances[1]) * (1 / ((1 / rs) +
                    (1 / parallelResistances[0]) + (1 / parallelResistances[1]) + (1 / parallelResistances[2]))))/rs;
                double i4 = ((parallelVoltageSources[2] / parallelResistances[2]) * (1 / ((1 / rs) +
                    (1 / parallelResistances[0]) + (1 / parallelResistances[1]) + (1 / parallelResistances[2]))))/rs;
                i_total = i1 + i2 + i3 + i4;
                result.LoadCurrent = i_total;
                result.Status = CircuitStatus.OK;
            }

            if (result.Status == CircuitStatus.OK)
            {
                result.LoadVoltage = result.LoadCurrent * result.LoadResistance;
            }

            return result;
        }
    }
}