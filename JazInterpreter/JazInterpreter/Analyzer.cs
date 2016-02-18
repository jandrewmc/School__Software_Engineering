using System;

namespace JazInterpreter
{
	public class Analyzer : IAnalyzer
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

