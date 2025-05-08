using System; 
using System.Collections.Generic;


namespace CircuitCraft
{
    public static class DifficultyManager
    {
        private static double initialInterval = 2.0;
        private static double minimumInterval = 0.1;
        private static double startLevel = 1.0;
        private static double currentDecayFactor = 0.90; 
        private static double baseCurrentPerLevel = 0.1;

        private static double initialSourceMultiplier = 1.0; 
        private static double sourceMultiplierIncreasePerLevel = 0.15;

        private static double initialResistanceMultiplier = 1.0; 
        private static double minimumResistanceMultiplier = 0.1; 
        private static double resistanceDecayFactor = 0.92; 

        public static double ScaledMinimumOperatingCurrent { get; private set; }
        public static double ScaledMaximumOperatingCurrent { get; private set; }
        public static double ScaledOperatingCurrentInterval { get; private set; }
        public static double SourceValueMultiplier { get; private set; } = 1.0;
        public static double ResistanceValueMultiplier { get; private set; } = 1.0;

        public static Dictionary<double, Image> VoltageValues { get; private set; }
        public static Dictionary<double, Image> ResistanceValues { get; private set; }

        public static void UpdateDifficulty(List<Image> CircuitElementSourceSprites, List<Image> CircuitElementResistorSprites, ref int CurrentLevel, int newLevel)
        {
            CurrentLevel = newLevel;
            ScaledDifficultyAndMultipliers(CurrentLevel);
            UpdateImageKeys(CircuitElementSourceSprites, CircuitElementResistorSprites);
        }


        public static void ScaledDifficultyAndMultipliers(int CurrentLevel)
        {
            double currentLevelDouble = (double)CurrentLevel;

            double baseMinimumCurrent = currentLevelDouble * baseCurrentPerLevel; 

            double currentRange = initialInterval - minimumInterval;
            double exponent = Math.Max(0, currentLevelDouble - startLevel);

            ScaledOperatingCurrentInterval = minimumInterval + currentRange * Math.Pow(currentDecayFactor, exponent);
            ScaledOperatingCurrentInterval = Math.Max(minimumInterval, ScaledOperatingCurrentInterval); 

            ScaledMinimumOperatingCurrent = baseMinimumCurrent;
            ScaledMaximumOperatingCurrent = ScaledMinimumOperatingCurrent + ScaledOperatingCurrentInterval; 

            SourceValueMultiplier = initialSourceMultiplier + (sourceMultiplierIncreasePerLevel * Math.Max(0, currentLevelDouble - startLevel));

            double resistanceRange = initialResistanceMultiplier - minimumResistanceMultiplier;
            ResistanceValueMultiplier = minimumResistanceMultiplier + resistanceRange * Math.Pow(resistanceDecayFactor, exponent); 
            ResistanceValueMultiplier = Math.Max(minimumResistanceMultiplier, ResistanceValueMultiplier); 
        }

        public static void UpdateImageKeys(List<Image> CircuitElementSourceSprites, List<Image> CircuitElementResistorSprites)
        {
            VoltageValues = new Dictionary<double, Image>() {
            { Math.Round(1.0 * SourceValueMultiplier, 2), CircuitElementSourceSprites[0] }, 
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
        }

    }
}
