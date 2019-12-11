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
			int storagePoint;

			for (int pointer = 0; pointer <= values.Count; pointer += 4)
			{
				storagePoint = pointer + 3;

				int result = DecodeOpCode(values[pointer], pointer, values);

				if (result == HALT_CODE)
					return;
				else
					WriteResult(storagePoint, result, values);
			}
		}

		private void WriteResult(int storagePoint, int result, List<int> values)
		{
			values[storagePoint] = result;
		}

		private int DecodeOpCode(int opCode, int pointer, List<int> values)
		{
			int value1 = values[pointer + 1];
			int value2 = values[pointer + 2];

			switch (opCode)
			{

				case 1:
					return AddValues(value1, value2);
				case 2:
					return MultiplyValues(value1, value2);
				case 99:
					return 99;
				default:
					return 99;
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
