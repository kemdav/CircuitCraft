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
            ShortCircuit,
            Incalculable
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
                        new GameResistor { Resistance = 10 }
                    }
                },
                new CircuitBlock
                {
                    CircuitBlockConnectionType = CircuitBlockConnectionType.Parallel,
                    CircuitElements = new List<CircuitElement>
                    {
                        //new GameResistor { Resistance = 1 },
                        //new GameSource { Voltage = 10 }
                    }
                },
                new CircuitBlock
                {
                    CircuitBlockConnectionType = CircuitBlockConnectionType.Parallel,
                    CircuitElements = new List<CircuitElement>
                    {
                        new GameResistor { Resistance = 20 },
                        new GameSource { Voltage = 1, Orientation = 1 }
                    }
                },
                new CircuitBlock
                {
                    CircuitBlockConnectionType = CircuitBlockConnectionType.Parallel,
                    CircuitElements = new List<CircuitElement>
                    {
                        new GameResistor { Resistance = 1 },
                        new GameSource { Voltage = 1, Orientation = 0 }
                    }
                },
                new CircuitBlock
                {
                    CircuitBlockConnectionType = CircuitBlockConnectionType.Parallel,
                    CircuitElements = new List<CircuitElement>
                    {
                        new GameResistor { Resistance = 1 },
                        new GameSource { Voltage = 1, Orientation = 0 }
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

           seriesResistances.Add(1); // Temp

            foreach (var block in circuitBlocks)
            {
                double blockTotalResistance = block.GetEquivalentResistance();
                double blockTotalVoltage = block.GetEquivalentSourceVoltage();

                if (double.IsNaN(blockTotalResistance) || double.IsNaN(blockTotalVoltage)) // Reverse biased
                {
                    block.isEnabled = false;
                    break;
                }
                else
                {
                    block.isEnabled = true;
                }
            }

            foreach (var block in circuitBlocks)
            {
                double blockTotalResistance = block.GetEquivalentResistance();
                double blockTotalVoltage = block.GetEquivalentSourceVoltage();

                if (block.CircuitBlockConnectionType == CircuitBlockConnectionType.Series)
                {
                    seriesResistances.Add(blockTotalResistance);
                    seriesVoltageSource += blockTotalVoltage;
                }
                else if (block.CircuitBlockConnectionType == CircuitBlockConnectionType.Parallel)
                {
                    parallelResistances.Add(blockTotalResistance);
                    parallelVoltageSources.Add(blockTotalVoltage);
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
            int count = 0;
            if (parallelResistances != null && parallelResistances.Count > 0)
            {
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
                        continue;
                    }
                    if (count == 1 && resistance > 0)
                    {
                        rp = resistance;
                        break;
                    }
                    rp += 1.0 / resistance;
                }
            }
            if (count != 1)
            {
                rp = 1 / rp;
            }
            if (double.IsInfinity(rp))
            {
                rp = 0;
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
                double load_current = seriesVoltageSource + batteryVoltage / r_total;
                double inverseResistanceCalculation = 1/rs;
                for (int i = 0; i < parallelResistances.Count; i++)
                {
                    if (parallelResistances[i] > 0)
                    {
                        inverseResistanceCalculation += 1.0 / parallelResistances[i];
                    }
                }
                if (inverseResistanceCalculation != 0)
                {
                    inverseResistanceCalculation = 1 / inverseResistanceCalculation;
                }

                for (int i = 0; i < parallelResistances.Count; i++)
                {
                    if (parallelResistances[i] == 0 && parallelVoltageSources[i] == 0)
                    {
                        continue;
                    }
                    if (parallelVoltageSources[i] != 0 && parallelResistances[i] == 0)
                    {
                        result.Status = CircuitStatus.Incalculable;
                        return result;
                    }
                    double branchCurrent = ((parallelVoltageSources[i] / parallelResistances[i]) * inverseResistanceCalculation)/rs;
                    if (parallelResistances[i] > 0)
                    {
                        load_current += branchCurrent;
                    }
                }

                result.LoadCurrent = load_current;
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