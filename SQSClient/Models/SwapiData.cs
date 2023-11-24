using System.Text.Json.Serialization;

namespace SQSClient.Models
{
    [Serializable]
    public class SwapiData
    {
        [JsonPropertyName("count")]
        public int? Count { get; set; }

        [JsonPropertyName("next")]
        public string? Next { get; set; }

        [JsonPropertyName("previous")]
        public string? Previous { get; set; }

        [JsonPropertyName("results")]
        public List<Person>? Results { get; set; }

        public SwapiData(int? count, string? next, string? previous, List<Person>? results)
        {
            Count = count;
            Next = next;
            Previous = previous;
            Results = results;
        }

        public SwapiData()
        {
        }
    }
}
