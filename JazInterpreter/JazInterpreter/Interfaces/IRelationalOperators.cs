using System;

namespace JazInterpreter
{
	public interface IRelationalOperators
	{
		bool equal();

		bool lessThanOrEqualTo();

		bool greaterThanOrEqualTo();

		bool lessThan();

		bool greaterThan();

		bool otherEqual();
	}
}

