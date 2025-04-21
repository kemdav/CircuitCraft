using System; // Make sure you have this for Math functions
using System.Collections.Generic; // For the Dictionaries


namespace CircuitCraft
{
    public static class DifficultyManager
    {
        // Operating Current Scaling
        private static double initialInterval = 2.0;
        private static double minimumInterval = 0.1;
        private static double startLevel = 1.0; // Use double for calculations
        private static double currentDecayFactor = 0.90; // How fast the interval shrinks
        private static double baseCurrentPerLevel = 0.1; // How fast the minimum current rises

        // Voltage Scaling (Linear Increase)
        private static double initialSourceMultiplier = 1.0; // Starting multiplier at startLevel
        private static double sourceMultiplierIncreasePerLevel = 0.15; // How much V multiplier increases per level

        // Resistance Scaling (Exponential Decay - similar to interval)
        private static double initialResistanceMultiplier = 1.0; // Starting multiplier at startLevel
        private static double minimumResistanceMultiplier = 0.1; // Smallest allowed multiplier
        private static double resistanceDecayFactor = 0.92; // How fast R multiplier shrinks (can be different from currentDecayFactor)

        // --- Calculated Values ---
        public static double ScaledMinimumOperatingCurrent { get; private set; }
        public static double ScaledMaximumOperatingCurrent { get; private set; }
        public static double ScaledOperatingCurrentInterval { get; private set; }
        public static double SourceValueMultiplier { get; private set; } = 1.0;
        public static double ResistanceValueMultiplier { get; private set; } = 1.0;

        // The dictionaries storing value-image pairs
        public static Dictionary<double, Image> VoltageValues { get; private set; }
        public static Dictionary<double, Image> ResistanceValues { get; private set; }

        // Method to update everything when level changes
        public static void UpdateDifficulty(List<Image> CircuitElementSourceSprites, List<Image> CircuitElementResistorSprites, ref int CurrentLevel, int newLevel)
        {
            CurrentLevel = newLevel;
            ScaledDifficultyAndMultipliers(CurrentLevel);
            UpdateImageKeys(CircuitElementSourceSprites, CircuitElementResistorSprites);
        }


        public static void ScaledDifficultyAndMultipliers(int CurrentLevel)
        {
            double currentLevelDouble = (double)CurrentLevel; // Use double for calculations

            // --- Operating Current Scaling ---
            double baseMinimumCurrent = currentLevelDouble * baseCurrentPerLevel; // Base target shifts up

            double currentRange = initialInterval - minimumInterval;
            double exponent = Math.Max(0, currentLevelDouble - startLevel); // Ensure exponent isn't negative

            ScaledOperatingCurrentInterval = minimumInterval + currentRange * Math.Pow(currentDecayFactor, exponent);
            ScaledOperatingCurrentInterval = Math.Max(minimumInterval, ScaledOperatingCurrentInterval); // Clamp to minimum

            ScaledMinimumOperatingCurrent = baseMinimumCurrent; // Set the floor
            ScaledMaximumOperatingCurrent = ScaledMinimumOperatingCurrent + ScaledOperatingCurrentInterval; // Calculate the ceiling

            // --- Source Value Multiplier Scaling (Linear Increase) ---
            SourceValueMultiplier = initialSourceMultiplier + (sourceMultiplierIncreasePerLevel * Math.Max(0, currentLevelDouble - startLevel));
            // Optional: Add a Max cap if needed: SourceValueMultiplier = Math.Min(maxSourceMultiplier, SourceValueMultiplier);

            // --- Resistance Value Multiplier Scaling (Exponential Decay) ---
            double resistanceRange = initialResistanceMultiplier - minimumResistanceMultiplier;
            ResistanceValueMultiplier = minimumResistanceMultiplier + resistanceRange * Math.Pow(resistanceDecayFactor, exponent); // Using the same exponent logic
            ResistanceValueMultiplier = Math.Max(minimumResistanceMultiplier, ResistanceValueMultiplier); // Clamp to minimum
        }

        public static void UpdateImageKeys(List<Image> CircuitElementSourceSprites, List<Image> CircuitElementResistorSprites)
        {
            // Use the current public multipliers to build the dictionaries
            VoltageValues = new Dictionary<double, Image>() {
            { Math.Round(1.0 * SourceValueMultiplier, 2), CircuitElementSourceSprites[0] }, // Rounding might be good for display
            { Math.Round(2.0 * SourceValueMultiplier, 2), CircuitElementSourceSprites[1] },
            { Math.Round(3.0 * SourceValueMultiplier, 2), CircuitElementSourceSprites[2] },
            { Math.Round(4.0 * SourceValueMultiplier, 2), CircuitElementSourceSprites[3] },
            { Math.Round(5.0 * SourceValueMultiplier, 2), CircuitElementSourceSprites[4] }
        };

            ResistanceValues = new Dictionary<double, Image>()
        {
            { Math.Round(1.0 * ResistanceValueMultiplier, 2), CircuitElementResistorSprites[0] },
            { Math.Round(2.0 * ResistanceValueMultiplier, 2), CircuitElementResistorSprites[1] },
            { Math.Round(3.0 * ResistanceValueMultiplier, 2), CircuitElementResistorSprites[2] },
            { Math.Round(4.0 * ResistanceValueMultiplier, 2), CircuitElementResistorSprites[3] },
            { Math.Round(5.0 * ResistanceValueMultiplier, 2), CircuitElementResistorSprites[4] }
        };
            // Consider potential issues if rounding makes two different base values result in the same scaled value.
            // If that's a risk, you might need a different approach than using the value as the dictionary key,
            // perhaps storing a list/array of {value, image} pairs instead.
        }

    }
}
