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

        public static LoadCalculationResult CalculateLoadState(double batteryVoltage, List<double> seriesResistances, List<double> parallelResistances, double loadResistance)
        {
            var result = new LoadCalculationResult
            {
                LoadResistance = loadResistance,
                LoadVoltage = 0,
                LoadCurrent = 0,
                Status = CircuitStatus.OK 
            };


            loadResistance = Math.Max(0.0, loadResistance);
            result.LoadResistance = loadResistance; 


            double rs = 0.0;
            if (seriesResistances != null && seriesResistances.Count > 0)
            {
                rs = seriesResistances.Sum(r => Math.Max(0.0, r));
            }

            double rp = double.PositiveInfinity; 
            bool parallelShorted = false;
            if (parallelResistances != null && parallelResistances.Count > 0)
            {
                double inverseSum = 0.0;
                foreach (double r in parallelResistances)
                {
                    double resistance = Math.Max(0.0, r);
                    if (resistance < 1e-9) 
                    {
                        rp = 0.0;
                        parallelShorted = true;
                        break;
                    }
                    inverseSum += 1.0 / resistance;
                }

                if (!parallelShorted)
                {
                    if (inverseSum > 1e-12) rp = 1.0 / inverseSum;
                }
            }

            double r_total;
            if (double.IsPositiveInfinity(rp)) 
            {
                r_total = rs + loadResistance;
            }
            else
            {
                r_total = rs + rp + loadResistance;
            }


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
                i_total = batteryVoltage / r_total;
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