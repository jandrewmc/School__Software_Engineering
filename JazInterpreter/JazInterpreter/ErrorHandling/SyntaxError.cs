using System;

namespace JazInterpreter
{
	public class SyntaxError : Exception
	{
		public SyntaxError ()
		{
		}
		public SyntaxError(string message) :base(message)
		{
		}
	}
}

