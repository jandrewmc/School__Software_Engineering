using System;

namespace JazInterpreter
{
	public class SyntaxValidator
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
						//throw an error
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
					if (callCount > 1) {
						//throw error
						System.Console.WriteLine ("error in call count");
					}
					callCount = 0;
				}

				if (count > 1 || count < 0) {
					//throw an error 
					System.Console.WriteLine ("You broke it again");
				}
			}
			if (count != 0) {
				//throw an error
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

