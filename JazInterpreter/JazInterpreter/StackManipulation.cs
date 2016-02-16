using System;
using System.Collections;

namespace JazInterpreter
{
	public class StackManipulation : IStackManipulation
	{
		protected Stack Stack { get; set; }

		public StackManipulation()
		{
			Stack = new Stack();
		}

		public void Push(int value) {
			Stack.Push(value);
		}

		public void RValue(Identifier identifier) {
			Stack.Push(identifier.Value);
		}

		public void LValue(Identifier identifier) {
			Stack.Push(identifier);
		}

		public void Pop() {
			Stack.Pop();
		}

		public void ColonEquals() {
			int value = (int) Stack.Pop();
			Identifier identifier = (Identifier) Stack.Pop();

			identifier.Value = value;
		}

		public void Copy() {
			Stack.Push(Stack.Peek());
		}
	}
}

