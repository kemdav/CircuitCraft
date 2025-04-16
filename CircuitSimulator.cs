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
                        //new GameResistor { Resistance = 1 }
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

           // seriesResistances.Add(40); // Temp

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
            rp = 1 / rp;

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

                // When a branch has no resistrs, it has infinite in calculation due to 1/0
                // So the main issue is the introduction of infinite in the calculation

                double currentCalculation1, currentCalculation2, currentCalculation3;
                double inverseResistance1, inverseResistance2, inverseResistance3;

                // Empty Branch Checks
                if (parallelResistances[0] == 0 && parallelVoltageSources[0] == 0)
                {
                    currentCalculation1 = 0;
                    inverseResistance1 = 0;
                }
                else if (parallelResistances[0] == 0 && parallelVoltageSources[0] != 0)
                {
                    result.Status = CircuitStatus.Incalculable;
                    result.LoadCurrent = double.NaN;
                    result.LoadVoltage = double.NaN;
                    return result;
                }
                else
                {
                    currentCalculation1 = parallelVoltageSources[0] / parallelResistances[0];
                    inverseResistance1 = 1 / parallelResistances[0];
                }

                if (parallelResistances[1] == 0 && parallelVoltageSources[1] == 0)
                {
                    currentCalculation2 = 0;
                    inverseResistance2 = 0;
                }
                else if (parallelResistances[1] == 0 && parallelVoltageSources[1] != 0)
                {
                    result.Status = CircuitStatus.Incalculable;
                    result.LoadCurrent = double.NaN;
                    result.LoadVoltage = double.NaN;
                    return result;
                }
                else
                {
                    currentCalculation2 = parallelVoltageSources[1] / parallelResistances[1];
                    inverseResistance2 = 1 / parallelResistances[1];
                }

                if (parallelResistances[2] == 0 && parallelVoltageSources[2] == 0)
                {
                    currentCalculation3 = 0;
                    inverseResistance3 = 0;
                }
                else if (parallelResistances[2] == 0 && parallelVoltageSources[2] != 0)
                {
                    result.Status = CircuitStatus.Incalculable;
                    result.LoadCurrent = double.NaN;
                    result.LoadVoltage = double.NaN;
                    return result;
                }
                else
                {
                    currentCalculation3 = parallelVoltageSources[2] / parallelResistances[2];
                    inverseResistance3 = 1 / parallelResistances[2];
                }
                double currentCalculationPart = inverseResistance1 + inverseResistance2 + inverseResistance3;

                double i2 = (currentCalculation1 * (1/((1/rs) +
                    currentCalculationPart)))/rs;
                double i3 = (currentCalculation2 * (1 / ((1 / rs) +
                    currentCalculationPart)))/rs;
                double i4 = (currentCalculation3 * (1 / ((1 / rs) +
                    currentCalculationPart)))/rs;
                if (double.IsNaN(i2) || i2 == double.PositiveInfinity)
                {
                    i2 = 0;
                }
                if (double.IsNaN(i3) || i3 == double.PositiveInfinity)
                {
                    i3 = 0;
                }
                if (double.IsNaN(i4) || i4 == double.PositiveInfinity)
                {
                    i4 = 0;
                }
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