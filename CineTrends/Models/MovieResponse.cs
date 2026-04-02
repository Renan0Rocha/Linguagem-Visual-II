using System.Text.Json.Serialization;

namespace CineTrends.Models;

public class MovieResponse
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("results")]
    public List<Movie> Results { get; set; } = new();
}
