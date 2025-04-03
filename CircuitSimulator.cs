using SpiceSharp;
using SpiceSharp.Components;
using SpiceSharp.Simulations;
using System;
using System.Collections.Generic;
using System.Diagnostics; // For Debug.WriteLine

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
            OpenCircuit, // Effectively infinite resistance, zero current
            ShortCircuit // Effectively zero resistance, infinite current
        }

        public static LoadCalculationResult CalculateLoadState(double batteryVoltage, List<double> seriesResistances, List<double> parallelResistances, double loadResistance)
        {
            var result = new LoadCalculationResult
            {
                LoadResistance = loadResistance,
                LoadVoltage = 0,
                LoadCurrent = 0,
                Status = CircuitStatus.OK // Start assuming OK
            };

            // --- Ensure load resistance is valid ---
            // Treat negative as 0 for calculation, could also throw error
            loadResistance = Math.Max(0.0, loadResistance);
            result.LoadResistance = loadResistance; // Store the potentially adjusted value


            // --- 1. Calculate Effective Series Resistance (Rs) ---
            double rs = 0.0;
            if (seriesResistances != null && seriesResistances.Count > 0)
            {
                rs = seriesResistances.Sum(r => Math.Max(0.0, r));
            }

            // --- 2. Calculate Effective Parallel Resistance (Rp) ---
            double rp = double.PositiveInfinity; // Default to open
            bool parallelShorted = false;
            if (parallelResistances != null && parallelResistances.Count > 0)
            {
                double inverseSum = 0.0;
                foreach (double r in parallelResistances)
                {
                    double resistance = Math.Max(0.0, r);
                    if (resistance < 1e-9) // Check for short
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
                    // else rp remains PositiveInfinity (open)
                }
            }

            // --- 3. Calculate Total Circuit Resistance (R_total) ---
            double r_total;
            if (double.IsPositiveInfinity(rp)) // If parallel section is open
            {
                r_total = rs + loadResistance;
            }
            else // Parallel section has finite resistance (could be 0 if shorted)
            {
                r_total = rs + rp + loadResistance;
            }


            // --- 4/5. Calculate Total/Load Current (I_total / I_load) ---
            double i_total; // This will also be i_load

            if (r_total < 1e-9) // Check for total short circuit
            {
                Console.WriteLine($"Warning: Total resistance is near zero ({r_total} Ohm) -> Short Circuit");
                result.Status = CircuitStatus.ShortCircuit;
                // Assign infinity to represent the short condition
                result.LoadCurrent = double.PositiveInfinity;
                result.LoadVoltage = double.PositiveInfinity; // Voltage also undefined/infinite in ideal short
                return result;
            }
            else if (double.IsPositiveInfinity(r_total)) // Check for total open circuit
            {
                Console.WriteLine($"Warning: Total resistance is infinite -> Open Circuit");
                result.Status = CircuitStatus.OpenCircuit;
                result.LoadCurrent = 0.0;
                result.LoadVoltage = 0.0; // No current means no voltage drop across load
                return result;
            }
            else
            {
                // Normal calculation
                i_total = batteryVoltage / r_total;
                result.LoadCurrent = i_total;
                result.Status = CircuitStatus.OK;
            }


            // --- 6. Calculate Voltage Across the Load (V_load) ---
            // Only calculate if not short/open
            if (result.Status == CircuitStatus.OK)
            {
                result.LoadVoltage = result.LoadCurrent * result.LoadResistance;
            }

            return result;
        }
    }
}