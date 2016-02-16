using System;

namespace JazInterpreter
{
	public class BaseException : Exception
	{
		public BaseException(string type, string message, ExitCode code)
		{
			Console.Error.WriteLine(string.Format("{0} : {1}", type, message));

			Environment.Exit((int) code);
		}
	}
}

