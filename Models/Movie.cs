using System.Text.Json.Serialization;

namespace MovieApi.Models;

public class Movie
{
    [JsonPropertyName("id")]
    public int MovieId { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("release_date")]
    public DateTime? ReleaseDate { get; set; }

    [JsonPropertyName("overview")]
    public string? Overview  { get; set; }

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }
}