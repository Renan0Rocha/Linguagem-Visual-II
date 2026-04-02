using System.Text.Json.Serialization;

namespace CineTrends.Models;

public class Movie
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("overview")]
    public string Overview { get; set; } = string.Empty;

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; } = string.Empty;

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }

    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }

    public string PosterFullUrl =>
        string.IsNullOrEmpty(PosterPath)
            ? "https://via.placeholder.com/500x750?text=Sem+Imagem"
            : $"https://image.tmdb.org/t/p/w500{PosterPath}";
}
