using System;
using NUnit.Framework;

namespace JazInterpreter.Tests
{
    public class SyntaxValidatorTests
    {
        private ISyntaxValidator syntaxValidator;

        [SetUp]
        public void SetUp()
        {
            syntaxValidator = new SyntaxValidator();
        }

        [Test]
        public void ValidateChecksGotoInstructions()
        {
            string[,] code = new string[,] { { "goto", "foo" }, { "label", "bar" } };


            Assert.Throws<SyntaxError>(() => syntaxValidator.validate(code));
        }

        [Test]
        public void ValidateChecksCallInstructions()
        {
            string[,] code = new string[,] { { "call", "foo" }, { "label", "bar" } };


            Assert.Throws<SyntaxError>(() => syntaxValidator.validate(code));
        }

        [Test]
        public void ValidateChecksGoFalseInstructions()
        {
            string[,] code = new string[,] { { "gofalse", "foo" }, { "label", "bar" } };


            Assert.Throws<SyntaxError>(() => syntaxValidator.validate(code));
        }

        [Test]
        public void ValidateChecksGoTrueInstructions()
        {
            string[,] code = new string[,] { { "gotrue", "foo" }, { "label", "bar" } };


            Assert.Throws<SyntaxError>(() => syntaxValidator.validate(code));
        }

        [Test]
        public void ValidateThrowsASyntaxErrorWhenOnlyOneOfTheLabelsDoesNotExist()
        {
            string[,] code = new string[,] { { "gotrue", "foo" }, { "label", "foo" }, { "gofalse", "baz" }, { "label", "whatsthis" } };


            Assert.Throws<SyntaxError>(() => syntaxValidator.validate(code));
        }

        [Test]
        public void ValidateThrowsAnExceptionWhenThereIsAnotherBeginWithoutAnEnd()
        {
            string[,] code = new string[,] { { "begin", "" }, { "begin", "" } };

            Assert.Throws<SyntaxError>(() => syntaxValidator.validate(code));
        }

        [Test]
        public void ValidateThrowsAnExceptionWhenThereIsAnotherEndWithoutABegin()
        {
            string[,] code = new string[,] { { "end", "" }, { "end", "" } };

            Assert.Throws<SyntaxError>(() => syntaxValidator.validate(code));
        }
    }
}