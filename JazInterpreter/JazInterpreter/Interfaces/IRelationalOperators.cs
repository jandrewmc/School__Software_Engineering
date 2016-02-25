using System;

namespace JazInterpreter
{
    public interface IRelationalOperators
    {
        void equal();

        void lessThanOrEqualTo();

        void greaterThanOrEqualTo();

        void lessThan();

        void greaterThan();

        void notEqual();
    }
}

