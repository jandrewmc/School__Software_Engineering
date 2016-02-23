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
			ArithmeticOperators arOp = new ArithmeticOperators (stack);
			LogicalOperators loOp = new LogicalOperators (stack);
			RelationalOperators relOp = new RelationalOperators (stack);
			Output output = new Output (stack);

			string filename = (new JazInterpreter()).getFileName (args);
			string[,] array = (new CodeParser ()).parse (filename);
			(new Analyzer ()).analyze (array);

			int instructionPointer = 0;
			int currentLevel = 0;
			bool relOpResult = false;

			while (true)
			{
				switch (array[instructionPointer,0])
				{
				case "push":
					stack.Push (Int32.Parse(array [instructionPointer, 1]));
					break;
				case "rvalue":
					Identifier identifier = SymbolsTable.variableTable[currentLevel].Find(x => x.Name == array [instructionPointer, 1]);
					stack.RValue (identifier);
					break;
				case "lvalue":
					Identifier identifier2 = SymbolsTable.variableTable[currentLevel].Find(x => x.Name == array [instructionPointer, 1]);
					stack.LValue (identifier2);
					break;
				case "pop":
					stack.Pop ();
					break;
				case ":=":
					stack.ColonEquals ();
					break;
				case "copy":
					stack.Copy ();
					break;
				case "label":
					System.Console.Write ("SHOULDNT GET HERE");
					break;
				case "goto":
					instructionPointer = ControlFlow.Goto (array [instructionPointer, 1]);
					break;
				case "gofalse":
					if (Convert.ToBoolean(stack.Peek ()))
						instructionPointer = ControlFlow.Gofalse (array [instructionPointer, 1]);
					stack.Pop ();
					break;
				case "gotrue":
					if (Convert.ToBoolean(stack.Peek ()))
						instructionPointer = ControlFlow.Gotrue (array [instructionPointer, 1]);
					stack.Pop ();
					break;
				case "halt":
					return;
				case "+":
					arOp.Add ();
					break;
				case "-":
					arOp.Subtract ();
					break;
				case "*":
					arOp.Multiply ();
					break;
				case "/":
					arOp.Divide ();
					break;
				case "div":
					arOp.Mod ();
					break;
				case "&":
					loOp.And ();	
					break;
				case "!":
					loOp.Not ();
					break;
				case "|":
					loOp.Or ();
					break;
				case "<>":
					relOpResult = relOp.equal ();				
					break;
				case "<=":
					relOpResult = relOp.lessThanOrEqualTo ();
					break;
				case ">=":
					relOpResult = relOp.greaterThanOrEqualTo ();
					break;
				case "<":
					relOpResult = relOp.lessThan ();
					break;
				case ">":
					relOpResult = relOp.greaterThan ();
					break;
				case "=":
					relOpResult = relOp.otherEqual ();
					break;
				case "print":
					output.print ();
					break;
				case "show":
					output.show (array [instructionPointer, 1]);
					break;
				case "begin":
					//TODO: gonna be ugly
					break;
				case "end":
					//TODO: gonna be ugly
					break;
				case "return":
					//TODO: gonna be ugly
					break;
				case "call":
					//TODO: gonna be ugly
					break;
				default:
					System.Console.WriteLine ("YOU DID SOMETHING VERY BAD");
					break;
				}
				instructionPointer++;
			}
		}
	}
}
