using NUnit.Framework;
using OeisCli;
using OeisCli.Exceptions;
using OeisCli.Services;
using System.Collections.Generic;

namespace ArgyleOeisCliTests
{
    public class CliOutputHelperTests
    {
        [Test]
        public void GivenZeroResults_ReturnsNoResultsFound()
        {
            var response = new OeisGetSequencesResponse()
            {
                Count = 0
            };
            var output = CliOutputHelper.GenerateSuccesOutput(response);

            StringAssert.Contains("No results found.", output);
        }

        [Test]
        public void GivenSingleResult_ReturnsOneResult()
        {
            var response = new OeisGetSequencesResponse()
            {
                Count = 1,
                Results = new List<SequenceResult>() {
                    new SequenceResult() { Name = "abc" }
                }
            };
            var output = CliOutputHelper.GenerateSuccesOutput(response);

            StringAssert.Contains("Found 1 result(s)", output);
            StringAssert.Contains("1. abc", output);
        }

        [Test]
        public void GivenMoreThan5Results_Returns5Result()
        {
            var response = new OeisGetSequencesResponse()
            {
                Count = 6,
                Results = new List<SequenceResult>() {
                    new SequenceResult() { Name = "a" },
                    new SequenceResult() { Name = "b" },
                    new SequenceResult() { Name = "c" },
                    new SequenceResult() { Name = "d" },
                    new SequenceResult() { Name = "e" },
                    new SequenceResult() { Name = "fff" },
                }
            };
            var output = CliOutputHelper.GenerateSuccesOutput(response);

            StringAssert.Contains("Found 6 result(s)", output);
            StringAssert.Contains("1. a", output);
            StringAssert.Contains("2. b", output);
            StringAssert.Contains("3. c", output);
            StringAssert.Contains("4. d", output);
            StringAssert.Contains("5. e", output);

            StringAssert.DoesNotContain("fff", output);

        }
    }
}