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
			StackManipulation stack = new StackManipulation ();
			string filename = (new JazInterpreter()).getFileName (args);
			string[,] array = (new CodeParser ()).parse (filename);
			(new Analyzer ()).analyze (array);

			int instructionPointer = 0;
			int currentLevel = 0;

			while (true)
			{
				switch (array[instructionPointer,0])
				{
				case "push":
					stack.Push (Int32.Parse(array [instructionPointer, 1]));
					break;
				case "rvalue":
					stack.RValue (array [instructionPointer, 1], currentLevel);
					break;
				case "lvalue":
					stack.LValue (array [instructionPointer, 1]);
					break;
				case "pop":
					stack.Pop ();
					break;
				case ":=":
					break;
				case "copy":
					stack.Copy ();
					break;
				case "label":
					System.Console.Write ("SHOULDNT GET HERE");
					break;
				case "goto":
					
					break;
				case "gofalse":
					break;
				case "gotrue":
					break;
				case "halt":
					break;
				case "+":
					break;
				case "-":
					break;
				case "*":
					break;
				case "/":
					break;
				case "div":
					break;
				case "&":
					break;
				case "!":
					break;
				case "|":
					break;
				case "<>":
					break;
				case "<=":
					break;
				case ">=":
					break;
				case "<":
					break;
				case ">":
					break;
				case "=":
					break;
				case "print":
					break;
				case "show":
					break;
				case "begin":
					break;
				case "end":
					break;
				case "return":
					break;
				case "call":
					break;
				default:
					break;
				}
				instructionPointer++;
			}
		}
	}
}
