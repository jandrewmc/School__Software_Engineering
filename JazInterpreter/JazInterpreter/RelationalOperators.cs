using System;

namespace JazInterpreter
{
    public class RelationalOperators : IRelationalOperators
    {
        private readonly IStackManipulation StackManipulation;

        public RelationalOperators(IStackManipulation stackManipulation)
        {
            this.StackManipulation = stackManipulation;
        }

        private Tuple<int, int> GetTopTwoValues()
        {
            int firstValue = PeekAndPop();
            int secondValue = PeekAndPop();

            return Tuple.Create(secondValue, firstValue);
        }

        private int PeekAndPop()
        {
            int value = (int)StackManipulation.Peek();
            StackManipulation.Pop();

            return value;
        }

        public bool equal()
        {
            var values = GetTopTwoValues();

            return values.Item1 == values.Item2;
        }

        public bool lessThanOrEqualTo()
        {
            var values = GetTopTwoValues();

            return values.Item1 <= values.Item2;
        }

        public bool greaterThanOrEqualTo()
        {
            var values = GetTopTwoValues();

            return values.Item1 >= values.Item2;
        }

        public bool lessThan()
        {
            var values = GetTopTwoValues();

            return values.Item1 < values.Item2;
        }

        public bool greaterThan()
        {
            var values = GetTopTwoValues();

            return values.Item1 > values.Item2;
        }

        public bool otherEqual()
        {
            var values = GetTopTwoValues();

            return values.Item1 == values.Item2;
        }
    }
}

