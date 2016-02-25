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

        public void equal()
        {
            var values = GetTopTwoValues();

            PushBooleanToStack(values.Item1 == values.Item2);
        }

        private void PushBooleanToStack(bool value)
        {
            StackManipulation.Push(Convert.ToInt32(value));
        }

        public void lessThanOrEqualTo()
        {
            var values = GetTopTwoValues();

            PushBooleanToStack(values.Item1 <= values.Item2);
        }

        public void greaterThanOrEqualTo()
        {
            var values = GetTopTwoValues();

            PushBooleanToStack(values.Item1 >= values.Item2);
        }

        public void lessThan()
        {
            var values = GetTopTwoValues();

            PushBooleanToStack(values.Item1 < values.Item2);
        }

        public void greaterThan()
        {
            var values = GetTopTwoValues();

            PushBooleanToStack(values.Item1 > values.Item2);
        }

        public void notEqual()
        {
            var values = GetTopTwoValues();

            PushBooleanToStack(values.Item1 != values.Item2);
        }
    }
}

