using System;

namespace JazInterpreter
{
	public class CodeParser : ICodeParser
	{
		public CodeParser ()
		{
		}

		private int getFileLength(string filename)
		{
			//get number of lines in code that should be interpreted
			System.IO.StreamReader file = new System.IO.StreamReader (filename);
			int count = 0;
			while ((file.ReadLine ()) != null)
				count++;
			file.Close ();
			return count;
		}

		public string[,] parse(string filename)
		{
			//arrange code in inputfile into array.
			string[,] array = new string[getFileLength(filename), 2];
			string line;

			System.IO.StreamReader file2 = new System.IO.StreamReader (filename);
			int count = 0;
			while ((line = file2.ReadLine ()) != null) {
				line = line.Trim ();
				string[] tokens = line.Split (new char[] { ' ' }, 2);

				if (tokens.Length == 2) {
					array [count, 0] = tokens [0];
					array [count, 1] = tokens [1];
				} else {
					array [count, 0] = tokens [0];
				}
				count++;
			}
			return array;
		}
	}
}

