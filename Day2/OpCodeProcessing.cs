using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
	public class OpCodeProcessor
	{
		public int HALT_CODE = 99;
		public int Output;

		public void ProcessOpCodes()
		{
			string[] file = File.ReadAllLines(@"C:\Users\piers\source\repos\AdventOfCode\AdventOfCode\InputFiles\OpCodes.txt");
			string[] fileValues = file[0].Split(',');

			int[] values = new int[fileValues.Length];
			ConvertFileToInts(fileValues, values);

			values[1] = 12;
			values[2] = 2;

			for (int pointer = 0; pointer <= values.Length; pointer += 4)
			{
				int opCode = values[pointer];
				int valuePosition1 = values[pointer + 1];
				int valuePosition2 = values[pointer + 2];
				int storagePosition = values[pointer + 3];

				if (opCode == 1) //Add Values
					values[storagePosition] = values[valuePosition1] + values[valuePosition2];
				else if (opCode == 2) //Multiply values
					values[storagePosition] = values[valuePosition1] * values[valuePosition2];
				else if (opCode == 99) //Return
					break;
				else
					Console.WriteLine("Invalid Input");
			}

			Output = values[0];
		}

		private void ConvertFileToInts(string[] fileValues, int[] values)
		{
			for(int pointer = 0; pointer < fileValues.Length; pointer++)
			{
				values[pointer] = int.Parse(fileValues[pointer]);
			}
		}
	}
}
