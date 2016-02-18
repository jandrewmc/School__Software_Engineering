using System;

namespace JazInterpreter
{
	public interface ICodeParser
	{
		string[,] parse(string filename);
	}
}
	