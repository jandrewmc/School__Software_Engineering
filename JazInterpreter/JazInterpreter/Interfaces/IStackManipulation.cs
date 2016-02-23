using System;

namespace JazInterpreter
{
	public interface IStackManipulation
	{
		void Push(int value);

		void RValue(string identifier, int level);

		void LValue(string identifier);

		void Pop();

		int Peek();

		void ColonEquals();

		void Copy();
	}
}

