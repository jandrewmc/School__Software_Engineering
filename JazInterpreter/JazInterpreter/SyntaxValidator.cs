using System;

namespace JazInterpreter
{
	public class SyntaxValidator : ISyntaxValidator
	{
		public SyntaxValidator ()
		{
		}

		private void checkForMatchingLabels(string[,] code)
		{
			for (int i = 0; i < code.GetLength(0); i++) 
			{
				if (code [i, 0] == "goto" || code [i, 0] == "call" || code [i, 0] == "gofalse" || code [i, 0] == "gotrue") {
					string labelToLookFor = code [i, 1];
					bool found = false;
					for (int j = 0; j < code.GetLength(0); j++) {
						if (code [j, 0] == "label") {
							if (code [j, 1] == labelToLookFor) {
								found = true;
								break;
							}
						}
					}
					if (!found) 
					{
						throw new SyntaxError ("No label found that matches " + labelToLookFor);
						System.Console.WriteLine ("You broke it");
					}
				}
			}
		}

		private void checkForMatchingBeginAndEndStatements(string[,] code)
		{
			int count = 0;
			int callCount = 0;
			for (int i = 0; i < code.GetLength (0); i++) {
				if (code [i, 0] == "begin")
					count++;
				if (count == 1 && code [i, 0] == "call")
					callCount++;
				if (code [i, 0] == "end") {
					count--;
					if (callCount > 1) 
					{
						throw new SyntaxError ("More than one call contained in a begin/end block");
						System.Console.WriteLine ("error in call count");
					}
					callCount = 0;
				}

				if (count > 1) 
				{
					throw new SyntaxError ("Found successive begin statements without a corresponding end statement");
				}
				if (count < 0) {
					throw new SyntaxError ("Found and additional end statement without a preceeding begin statement");
				}
			}
			if (count != 0) {
				//TODO: Throw an Error
				System.Console.WriteLine ("You majorly broke it");
			}
		}

		public void validate(string[,] code)
		{
			checkForMatchingLabels (code);
			checkForMatchingBeginAndEndStatements (code);
		}
	}
}

