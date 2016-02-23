using System;

namespace JazInterpreter
{
	public class RelationalOperators : IRelationalOperators
	{
		private readonly IStackManipulation StackManipulation;

		public RelationalOperators (IStackManipulation stackManipulation)
		{
			this.StackManipulation = stackManipulation;
		}

		private Tuple<int, int> GetTopTwoValues()
		{
			int firstValue = PeekAndPop ();
			int secondValue = PeekAndPop ();

			return Tuple.Create (firstValue, secondValue);
		}

		private int PeekAndPop()
		{
			int value = StackManipulation.Peek ();
			StackManipulation.Pop ();

			return value;
		}

		public bool equal()
		{
			var values = GetTopTwoValues ();

			return values.Item2 == values.Item1;
		}

		public bool lessThanOrEqualTo()
		{
			var values = GetTopTwoValues ();

			return values.Item2 <= values.Item1;
		}

		public bool greaterThanOrEqualTo()
		{
			var values = GetTopTwoValues ();

			return values.Item2 >= values.Item1;
		}

		public bool lessThan()
		{
			var values = GetTopTwoValues ();

			return values.Item2 < values.Item1;
		}

		public bool greaterThan()
		{
			var values = GetTopTwoValues ();

			return values.Item2 > values.Item1;
		}

		public bool otherEqual()
		{
			var values = GetTopTwoValues ();

			return values.Item2 == values.Item1;
		}
	}
}

