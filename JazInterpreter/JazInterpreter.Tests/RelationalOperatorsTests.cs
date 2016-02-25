using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace JazInterpreter.Tests
{
    public class RelationalOperatorsTests
    {
        private IStackManipulation stackManipulation;
        private IRelationalOperators relationalOperators;

        [SetUp]
        public void SetUp()
        {
            stackManipulation = MockRepository.GenerateMock<IStackManipulation>();
            relationalOperators = new RelationalOperators(stackManipulation);
        }

        [Test]
        public void EqualPushesTheEqualityOfTheTopTwoElements()
        {
            int value = 10;
            stackManipulation.Expect(x => x.Peek()).Repeat.Twice().Return(value);

            relationalOperators.equal();

            stackManipulation.AssertWasCalled(x => x.Push(Arg<int>.Is.Equal(1)));
        }

        [Test]
        public void LessThanOrEqualToPushesTheResultOfTheTopTwoElements()
        {
            int firstValue = 15;
            int secondValue = 10;
            stackManipulation.Expect(x => x.Peek()).Repeat.Once().Return(firstValue);
            stackManipulation.Expect(x => x.Peek()).Repeat.Once().Return(secondValue);

            relationalOperators.lessThanOrEqualTo();

            stackManipulation.AssertWasCalled(x => x.Push(Arg<int>.Is.Equal(1)));
        }

        [Test]
        public void GreaterThanOrEqualToPushesTheResultOfTheTopTwoElements()
        {
            int firstValue = 15;
            int secondValue = 10;
            stackManipulation.Expect(x => x.Peek()).Repeat.Once().Return(firstValue);
            stackManipulation.Expect(x => x.Peek()).Repeat.Once().Return(secondValue);

            relationalOperators.greaterThanOrEqualTo();

            stackManipulation.AssertWasCalled(x => x.Push(Arg<int>.Is.Equal(0)));
        }

        [Test]
        public void LessThanPushesTheResultOfTheTopTwoElements()
        {
            int firstValue = 9;
            int secondValue = 10;
            stackManipulation.Expect(x => x.Peek()).Repeat.Once().Return(firstValue);
            stackManipulation.Expect(x => x.Peek()).Repeat.Once().Return(secondValue);

            relationalOperators.lessThan();

            stackManipulation.AssertWasCalled(x => x.Push(Arg<int>.Is.Equal(0)));
        }

        [Test]
        public void GreaterThanPushesTheResultOfTheTopTwoElements()
        {
            int firstValue = 9;
            int secondValue = 10;
            stackManipulation.Expect(x => x.Peek()).Repeat.Once().Return(firstValue);
            stackManipulation.Expect(x => x.Peek()).Repeat.Once().Return(secondValue);

            relationalOperators.greaterThan();

            stackManipulation.AssertWasCalled(x => x.Push(Arg<int>.Is.Equal(1)));
        }

        [Test]
        public void NotEqualPushesTheInverseEqualityOfTheTopTwoElements()
        {
            int value = 10;
            stackManipulation.Expect(x => x.Peek()).Repeat.Twice().Return(value);

            relationalOperators.notEqual();

            stackManipulation.AssertWasCalled(x => x.Push(Arg<int>.Is.Equal(0)));
        }
    }
}