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
				if (code [i, 0] == "goto" || code [i, 0] == "call") {
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
						System.Console.WriteLine ("You broke it");
					}
				}
			}
		}

		public void validate(string[,] code)
		{
			checkForMatchingLabels (code);
		}
	}
}

