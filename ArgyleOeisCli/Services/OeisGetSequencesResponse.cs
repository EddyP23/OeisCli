using System.Collections.Generic;

namespace OeisCli.Services
{
    public class OeisGetSequencesResponse
    {
        public int Count { get; set; }
        public List<SequenceResult> Results { get; set; }
    }

    public class SequenceResult
    {
        public string Name { get; set; }
    }
}
