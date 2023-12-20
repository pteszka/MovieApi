using System.Text.Json.Serialization;

namespace MovieApi.Models;

public class TopRatedMovies
{
    [JsonPropertyName("page")]
    public int PageNumber { get; set; }

    [JsonPropertyName("results")]
    public IEnumerable<Movie>? Movies { get; set; }

    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("total_results")]
    public int TotalResults  { get; set; }
}