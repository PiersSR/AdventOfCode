using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class FuelCalculator
    {
        int totalFuelRequirement = 0;
        public int totalExtraFuelRequirement = 0;
        int lineCounter = 0;

        /// <summary>
        /// Calculate the fuel needed from the given mass values
        /// </summary>
        public int CalculateFuelNeeded(string[] massValues)
        {
            foreach(string lineValue in massValues)
            {
                int massValue = int.Parse(lineValue);
                totalFuelRequirement += (massValue / 3) - 2;
            }

            return totalFuelRequirement;
        }

        public void CalculateExtraFuelNeeded(string[] lineValues, int fuelNeeded, int iteration)
        {
            if (((fuelNeeded <= 0) && (lineCounter < lineValues.Length - 1)) || iteration == 0)
            {
                fuelNeeded = iteration == 0 ? int.Parse(lineValues[lineCounter]) : int.Parse(lineValues[++lineCounter]);
            }
            
            if((fuelNeeded > 0) && (lineCounter < lineValues.Length))
            {
                fuelNeeded = (fuelNeeded / 3) - 2;
                iteration++;

                if(fuelNeeded > 0)
                    totalExtraFuelRequirement += fuelNeeded;

                CalculateExtraFuelNeeded(lineValues, fuelNeeded, iteration);
            }
        }
    }
}
