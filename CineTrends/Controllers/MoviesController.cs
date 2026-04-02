using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using CineTrends.Models;

namespace CineTrends.Controllers;

public class MoviesController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public MoviesController(IConfiguration configuration)
    {
        _apiKey = configuration["TmdbApiKey"]
            ?? throw new InvalidOperationException("A chave 'TmdbApiKey' não foi configurada. Adicione-a em appsettings.json ou User Secrets.");

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.themoviedb.org/3/")
        };
    }

    public async Task<IActionResult> Index()
    {
        var url = $"movie/popular?language=pt-BR&page=1&api_key={_apiKey}";

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var movieResponse = JsonSerializer.Deserialize<MovieResponse>(json);

            return View(movieResponse?.Results ?? new List<Movie>());
        }

        return View(new List<Movie>());
    }
}
