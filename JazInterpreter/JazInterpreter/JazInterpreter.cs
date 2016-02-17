using System;

namespace JazInterpreter
{
	class JazInterpreter
	{
		private string getFileName(string[] args)
		{
			//get name of file to be read in
			string filename;
			if (args.Length == 0) {
				while (true) {
					System.Console.Write ("Please enter the location of the file you wish to interpret: ");
					filename = System.Console.ReadLine ();
					if (System.IO.File.Exists (filename)) {
						break;
					}
					System.Console.WriteLine ("That file does not exist!");
				}

			} else {
				filename = args [0];
			}
			return filename;
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

		private string[,] readInCode(string filename, int fileLength)
		{
			//arrange code in inputfile into array.
			string[,] array = new string[fileLength, 2];
			string line;

			System.IO.StreamReader file2 = new System.IO.StreamReader(filename);
			int count = 0;
			while ((line = file2.ReadLine ()) != null) 
			{
				line = line.Trim ();
				string[] tokens = line.Split (new char[] {' '}, 2);

				if (tokens.Length == 2) 
				{
					array [count, 0] = tokens [0];
					array [count, 1] = tokens [1];
				} else 
				{
					array [count, 0] = tokens [0];
				}
				count++;
			}
			return array;
		}

		public static void Main(string[] args) 
		{
			JazInterpreter interpreter = new JazInterpreter ();

			string filename = interpreter.getFileName (args);
			int fileLength = interpreter.getFileLength (filename);
			string[,] array = interpreter.readInCode (filename, fileLength);
		}
	}
}
