using System;

namespace JazInterpreter
{
	public class Output :IOutput
	{
		private readonly IStackManipulation stackManipulation;

		public Output (IStackManipulation stackManipulation)
		{
			this.stackManipulation = stackManipulation;
		}

		private int PeekAndPop()
		{
			int value = stackManipulation.Peek ();
			stackManipulation.Pop ();

			return value;
		}

		public void print ()
		{
			System.Console.WriteLine (PeekAndPop ());
		}

		public void show (string line)
		{
			System.Console.WriteLine (line);
		}
	}
}

