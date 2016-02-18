using System;

namespace JazInterpreter
{
	public interface IStackManipulation
	{
		void Push(int value);

		void RValue(Identifier identifier);

		void LValue(Identifier identifier);

		void Pop();

		int Peek();

		void ColonEquals();

		void Copy();
	}
}

