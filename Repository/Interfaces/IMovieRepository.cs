using System.Collections;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Repository.Interfaces;

public interface IMovieRepository
{
    Task<Movie> GetMovieById(int id);
    Task<IEnumerable<Movie>> GetTopRatedMovies(int pageNumber);
}
