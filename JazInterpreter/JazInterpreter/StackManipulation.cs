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

		public void RValue(string identifier, int level) {
			int value = 0;
			SymbolsTable.variableTable [level].TryGetValue (identifier, out value);
			Stack.Push(value);
		}

		public void LValue(string identifier) {
			Stack.Push(identifier);
		}

		public void Pop() 
		{
			if (Stack.Count == 0) {
				throw new UnderflowException();
			}

			Stack.Pop();
		}

		public int Peek() {
			if (Stack.Count == 0) {
				throw new UnderflowException();
			}

			return (int) Stack.Peek();
		}

		public void ColonEquals() {
			try {
				int value = (int) Stack.Pop();
				Identifier identifier = (Identifier) Stack.Pop();

				identifier.Value = value;
			} catch (InvalidCastException) {
				throw new MissingLValueException();
			}
		}

		public void Copy() {
			Stack.Push(Stack.Peek());
		}
	}
}

