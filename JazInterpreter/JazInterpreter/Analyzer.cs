using System;

namespace JazInterpreter
{
	public class Analyzer
	{
		public Analyzer ()
		{
		}

		public void analyze(string [,] code)
		{
			(new SyntaxValidator ()).validate (code);


		}
	}
}

