using NUnit.Framework;
using OeisCli;
using OeisCli.Exceptions;

namespace ArgyleOeisCliTests
{
    public class CliInputHelperTests
    {
        [Test]
        public void GivenNull_ThrowsInvalidInputException()
        {
            var e = Assert.Throws<InvalidInputException>(() =>
                CliInputHelper.ExtractAndValidateArguments(null));
            StringAssert.Contains("Please provide a sequence of integers", e.Message);
        }

        [Test]
        public void GivenEmptyString_ThrowsInvalidInputException()
        {
            var e = Assert.Throws<InvalidInputException>(() =>
                CliInputHelper.ExtractAndValidateArguments(new[] { "" }));
            StringAssert.Contains("Please provide at least two integers", e.Message);
        }

        [Test]
        public void GivenSingleInteger_ThrowsInvalidInputException()
        {
            var e = Assert.Throws<InvalidInputException>(() =>
                CliInputHelper.ExtractAndValidateArguments(new[] { "23" }));
            StringAssert.Contains("Please provide at least two integers", e.Message);
        }

        [Test]
        public void GivenNonInteger_ThrowsInvalidInputException()
        {
            var e = Assert.Throws<InvalidInputException>(() =>
                CliInputHelper.ExtractAndValidateArguments(new[] { "23", "12.5" }));
            StringAssert.Contains("Unable to convert", e.Message);
        }

        [Test]
        public void GivenNonNumber_ThrowsInvalidInputException()
        {
            var e = Assert.Throws<InvalidInputException>(() =>
                CliInputHelper.ExtractAndValidateArguments(new[] { "23", "asd" }));
            StringAssert.Contains("Unable to convert", e.Message);
        }

        [Test]
        public void GivenVeryBigNumber_ThrowsInvalidInputException()
        {
            var e = Assert.Throws<InvalidInputException>(() =>
                CliInputHelper.ExtractAndValidateArguments(new[] { "999999999999" }));
            StringAssert.Contains("must be an integer between", e.Message);
        }

        [Test]
        public void GivenValidInput_ReturnsListOfInts()
        {
            var seq = CliInputHelper.ExtractAndValidateArguments(new[] { "1", "2", "3" });

            Assert.AreEqual(3, seq.Count);
            Assert.AreEqual(1, seq[0]);
            Assert.AreEqual(2, seq[1]);
            Assert.AreEqual(3, seq[2]);
        }
    }
}