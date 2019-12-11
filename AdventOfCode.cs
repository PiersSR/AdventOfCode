using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    class AdventOfCode
    {
        public static void Main(string[] args)
        {
            //Day One
            string[] massValues = File.ReadAllLines(@"C:\Users\piers\source\repos\AdventOfCode\AdventOfCode\InputFiles\MassValues.txt");

            FuelCalculator fuelCalculator = new FuelCalculator();
            Console.WriteLine($"Day 1 Part 1: \n\t Fuel Requirement: {fuelCalculator.CalculateFuelNeeded(massValues)}");
            fuelCalculator.CalculateExtraFuelNeeded(massValues, 0, 0);
            Console.WriteLine($"Day 1 Part 2: \n\t Extra Fuel Requirement: {fuelCalculator.totalExtraFuelRequirement}");

            OpCodeProcessor opCodeProcessor = new OpCodeProcessor();
            Console.WriteLine($"Day 2 Part 1: \n\t Opcode Result: {opCodeProcessor.ProcessOpCodes()}");
            Console.ReadKey();
        }
    }
}
