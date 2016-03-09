using JazInterpreter.Interfaces;

namespace JazInterpreter
{
	public class Analyzer : IAnalyzer
	{
	    public void Analyze(string [,] code)
		{
			new SyntaxValidator ().Validate (code);
			SymbolsTable.BuildSymbolTable (code);
		}
	}
}

