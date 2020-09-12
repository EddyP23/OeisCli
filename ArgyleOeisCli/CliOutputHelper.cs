using OeisCli.Services;
using System;
using System.Text;

namespace OeisCli
{
    public class CliOutputHelper
    {
        public static string GenerateSuccesOutput(OeisGetSequencesResponse response)
        {
            var output = new StringBuilder();

            if (response.Count > 0)
            {
                var numToDisplay = Math.Min(response.Count, 5);

                output.Append($"Found {response.Count} result(s). Showing first {numToDisplay}:\n");

                for (var i = 0; i < numToDisplay; i++)
                {
                    var seq = response.Results[i];
                    output.Append($"{i + 1}. {seq.Name}\n");
                }

            }
            else
            {
                output.Append("No results found.\n");
            }

            return output.ToString();
        }
    }
}
