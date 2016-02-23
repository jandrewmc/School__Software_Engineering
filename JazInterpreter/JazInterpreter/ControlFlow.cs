using System;

namespace JazInterpreter
{
	public class ControlFlow :IControlFlow
	{
		public static int Goto(string label)
		{
			int value = 0;
			SymbolsTable.labelTable.TryGetValue (label, out value);
			return value;
		}

		public static int Gofalse(string label)
		{
			int value = 0;
			SymbolsTable.labelTable.TryGetValue (label, out value);
			return value;
		}

		public static int Gotrue(string label)
		{
			int value = 0;
			SymbolsTable.labelTable.TryGetValue (label, out value);
			return value;
		}
	}
}

