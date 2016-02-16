using System;

namespace JazInterpreter
{
	public class BaseException : Exception
	{
		public BaseException(string type, string message, ExitCode code)
		{
			Console.Error.WriteLine($"{type} : {message}");

			Environment.Exit((int) code);
		}
	}
}

