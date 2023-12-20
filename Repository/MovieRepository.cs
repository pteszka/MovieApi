using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Repository;

public class MovieRepository : IMovieRepository
{
    private readonly HttpClient _client;
    private readonly DataContext _context;
    
    public MovieRepository(IHttpClientFactory httpClientFactory , DataContext context)
    {
        _client = httpClientFactory.CreateClient("Tmbd");
        _context = context;
    }
    
    public async Task<Movie> GetMovieById(int id)
    {
        return await _client.GetFromJsonAsync<Movie>(
            $"movie/{id}?language=en-US");
    }

    public async Task<IEnumerable<Movie>> GetTopRatedMovies(int pageNumber)
    {
        var jsonContent = await _client.GetFromJsonAsync<TopRatedMovies>(
            $"movie/top_rated?language=en-US&page={pageNumber}");
        return jsonContent.Movies;
    }
}
