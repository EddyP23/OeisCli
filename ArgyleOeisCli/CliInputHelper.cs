using OeisCli.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OeisCli
{
    public class CliInputHelper
    {
        public static List<int> ExtractAndValidateArguments(string[] args)
        {
            if (args == null)
            {
                throw new InvalidInputException("Please provide a sequence of integers");
            }

            var sequence = args
                .ToList()
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x =>
                {
                    try
                    {
                        return int.Parse(x);
                    }
                    catch (OverflowException e)
                    {
                        var msg = $"The number {x} must be an integer between {int.MinValue} and {int.MaxValue}";
                        throw new InvalidInputException(msg, e);
                    }
                    catch (FormatException e)
                    {
                        var msg = $"Unable to convert {x}";
                        throw new InvalidInputException(msg, e);
                    }
                }).ToList();

            if (sequence.Count < 2)
            {
                throw new InvalidInputException("Please provide at least two integers");
            }

            return sequence;
        }
    }
}
