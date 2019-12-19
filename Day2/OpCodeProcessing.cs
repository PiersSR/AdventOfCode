using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
	public class OpCodeProcessor
	{
		public int HALT_CODE = 99;

		public int ProcessOpCodes()
		{
			string[] file = File.ReadAllLines(@"C:\Users\piers\source\repos\AdventOfCode\AdventOfCode\InputFiles\OpCodes.txt");
			string[] fileValues = file[0].Split(',');

			List<int> values = ParseFileValues(fileValues);

			InterpretValues(values);

			return values[0];
		}

		private List<int> ParseFileValues(string[] fileValues)
		{
			List<int> values = new List<int>();

			for(int pointer = 0; pointer < fileValues.Length; pointer++)
			{
				values.Add(int.Parse(fileValues[pointer]));
			}
			return values;
		}

		private void InterpretValues(List<int> values)
		{
			for (int pointer = 0; pointer <= values.Count; pointer += 4)
			{
				int opCode = values[pointer];
				int value1 = values[pointer + 1];
				int value2 = values[pointer + 2];
				int storagePoint = values[pointer + 3];

				if (opCode == HALT_CODE)
					return;

				DecodeValues(opCode, storagePoint, value1, value2, values);
			}
		}

		private int WriteResult(int storagePoint, int result, List<int> values)
		{
			return values[storagePoint] = result;
		}

		private int DecodeValues(int opCode, int storagePoint, int value1, int value2, List<int> values)
		{
			switch (opCode)
			{
				case 1:
					return WriteResult(storagePoint, AddValues(value1, value2), values);
				case 2:
					return WriteResult(storagePoint, MultiplyValues(value1, value2), values);
				case 99:
					return 99;
				default:
					return 1000;
			}
		}

		private int AddValues(int value1, int value2)
		{
			return value1 + value2;
		}

		private int MultiplyValues(int value1, int value2)
		{
			return value1 * value2;
		}
	}
}
