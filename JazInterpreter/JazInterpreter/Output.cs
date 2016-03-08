using System;

namespace JazInterpreter
{
    public class Output : IOutput
    {
        private readonly IStackManipulation stackManipulation;

        public Output(IStackManipulation stackManipulation)
        {
            this.stackManipulation = stackManipulation;
        }

        private int Peek()
        {
            int value = (int)stackManipulation.Peek();

            return value;
        }

        public void print()
        {
            System.Console.WriteLine(Peek());
        }

        public void show(string line)
        {
            System.Console.WriteLine(line);
        }
    }
}

