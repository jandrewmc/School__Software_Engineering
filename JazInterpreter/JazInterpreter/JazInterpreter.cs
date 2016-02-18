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


		public static void Main(string[] args) 
		{
			string filename = (new JazInterpreter()).getFileName (args);
			string[,] array = (new CodeParser ()).parse (filename);
			(new Analyzer ()).analyze (array);
		}
	}
}
