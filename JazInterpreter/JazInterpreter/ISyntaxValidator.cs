using System;

namespace JazInterpreter
{
	public interface ISyntaxValidator
	{
		void validate(string[,] code);
	}
}

