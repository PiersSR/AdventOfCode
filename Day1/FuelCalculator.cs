using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class FuelCalculator
    {
        int TotalFuelRequirement = 0;
        public int TotalExtraFuelRequirement = 0;
        int LineCounter = 0;

        /// <summary>
        /// Calculate the fuel needed from the given mass values
        /// </summary>
        public int CalculateFuelNeeded(string[] massValues)
        {
            foreach(string lineValue in massValues)
            {
                int massValue = int.Parse(lineValue);
                TotalFuelRequirement += (massValue / 3) - 2;
            }

            return TotalFuelRequirement;
        }

        public void CalculateExtraFuelNeeded(string[] lineValues, int fuelNeeded, int iteration)
        {
            if (((fuelNeeded <= 0) && (LineCounter < lineValues.Length - 1)) || iteration == 0)
            {
                fuelNeeded = iteration == 0 ? int.Parse(lineValues[LineCounter]) : int.Parse(lineValues[++LineCounter]);
            }
            
            if((fuelNeeded > 0) && (LineCounter < lineValues.Length))
            {
                fuelNeeded = (fuelNeeded / 3) - 2;
                iteration++;

                if(fuelNeeded > 0)
                    TotalExtraFuelRequirement += fuelNeeded;

                CalculateExtraFuelNeeded(lineValues, fuelNeeded, iteration);
            }
        }
    }
}
