using System;

namespace JazInterpreter
{
    class JazInterpreter
    {
        private string getFileName(string[] args)
        {
            //get name of file to be read in
            string filename;
            if (args.Length == 0)
            {
                while (true)
                {
                    Console.Write("Please enter the location of the file you wish to interpret: ");
                    filename = Console.ReadLine();
                    if (System.IO.File.Exists(filename))
                    {
                        break;
                    }
                    Console.WriteLine("That file does not exist!");
                }

            }
            else
            {
                filename = args[0];
            }
            return filename;
        }

        public static void Main(string[] args)
        {
            StackManipulation stack = new StackManipulation();
            ArithmeticOperators arOp = new ArithmeticOperators(stack);
            LogicalOperators loOp = new LogicalOperators(stack);
            RelationalOperators relOp = new RelationalOperators(stack);
            Output output = new Output(stack);

            string filename = (new JazInterpreter()).getFileName(args);
            string[,] array = (new CodeParser()).Parse(filename);
            (new Analyzer()).Analyze(array);

            int instructionPointer = 0;
            int currentLevel = 0;
			bool isAfterBeginButBeforeCall = false;
			bool isAfterCallButBeforeEnd = false;

            while (true)
            {
                switch (array[instructionPointer, 0])
                {
                    case "push":
                        stack.Push(Int32.Parse(array[instructionPointer, 1]));
                        break;
                    case "rvalue":
						if (isAfterCallButBeforeEnd)
						{
							Identifier identifier = SymbolsTable.VariableTable[currentLevel + 1].Find(x => x.Name == array[instructionPointer, 1]);
							stack.RValue(identifier);		
						}
						else
						{
					   		Identifier identifier = SymbolsTable.VariableTable[currentLevel].Find(x => x.Name == array[instructionPointer, 1]);
                       		stack.RValue(identifier);	
						}
                        break;
                    case "lvalue":
					if (isAfterBeginButBeforeCall)
						{
							Identifier identifier2 = SymbolsTable.VariableTable[currentLevel + 1].Find(x => x.Name == array[instructionPointer, 1]);
							stack.LValue(identifier2);		
						}
						else
						{
							Identifier identifier2 = SymbolsTable.VariableTable[currentLevel].Find(x => x.Name == array[instructionPointer, 1]);
							stack.LValue(identifier2);	
						}
                        break;
                    case "pop":
                        stack.Pop();
                        break;
                    case ":=":
                        stack.ColonEquals();
                        break;
                    case "copy":
                        stack.Copy();
                        break;
                    case "label":
                        break;
                    case "goto":
                        instructionPointer = ControlFlow.Goto(array[instructionPointer, 1]);
                        break;
                    case "gofalse":
                        if (!Convert.ToBoolean(stack.Peek()))
                            instructionPointer = ControlFlow.Gofalse(array[instructionPointer, 1]);
                        stack.Pop();
                        break;
                    case "gotrue":
                        if (Convert.ToBoolean(stack.Peek()))
                            instructionPointer = ControlFlow.Gotrue(array[instructionPointer, 1]);
                        stack.Pop();
                        break;
                    case "halt":
                        return;
                    case "+":
                        arOp.Add();
                        break;
                    case "-":
                        arOp.Subtract();
                        break;
                    case "*":
                        arOp.Multiply();
                        break;
                    case "/":
                        arOp.Divide();
                        break;
                    case "div":
                        arOp.Mod();
                        break;
                    case "&":
                        loOp.And();	
                        break;
                    case "!":
                        loOp.Not();
                        break;
                    case "|":
                        loOp.Or();
                        break;
                    case "<>":
                        relOp.NotEqual();				
                        break;
                    case "<=":
                        relOp.LessThanOrEqualTo();
                        break;
                    case ">=":
                        relOp.GreaterThanOrEqualTo();
                        break;
                    case "<":
                        relOp.LessThan();
                        break;
                    case ">":
                        relOp.GreaterThan();
                        break;
                    case "=":
                        relOp.Equal();
                        break;
                    case "print":
                        output.Print();
                        break;
                    case "show":
                        output.Show(array[instructionPointer, 1]);
                        break;
				case "begin":
					isAfterBeginButBeforeCall = true;
					SymbolsTable.AddLevel (currentLevel);

                        break;
				case "end":
						//need to remove level
					SymbolsTable.VariableTable.RemoveAt (currentLevel + 1);
						isAfterBeginButBeforeCall = false;
						isAfterCallButBeforeEnd = false;
                        break;
				case "return":
					//return needs to decrement the leve and restore everything
					currentLevel--;
					instructionPointer = stack.PeekAndPop ();
					isAfterBeginButBeforeCall = false;
					isAfterCallButBeforeEnd = true;
                        break;
				case "call":
					//call needs to save the current instruction pointer, set the instruction pointer to the next level,
					//increment the level, reset the boolean flags
					stack.Push (instructionPointer);
					isAfterBeginButBeforeCall = false;
					isAfterCallButBeforeEnd = false;
					currentLevel++;
					instructionPointer = SymbolsTable.LabelTable [array [instructionPointer, 1]];

                        break;
				case "":
					break;
                    default:
                        Console.WriteLine("YOU DID SOMETHING VERY BAD");
                        break;
                }
                instructionPointer++;
            }
        }
    }
}
