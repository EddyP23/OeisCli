using OeisCli.Exceptions;
using OeisCli.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OeisCli
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var oeisService = new OeisService(new HttpClient());

            try
            {
                var sequence = CliInputHelper.ExtractAndValidateArguments(args);
                var response = await oeisService.FetchOeisDb(sequence);
                var outputString = CliOutputHelper.GenerateSuccesOutput(response);

                Console.WriteLine(outputString);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case InvalidInputException _:
                    case NetworkErrorException _:
                        Console.Error.WriteLine(ex.Message);
                        break;
                    default:
                        throw;
                }
            }
        }
    }
}
