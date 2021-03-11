using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWars_Rating.API.Models;

namespace StarWars_Rating.API
{
    public class SwApiConnector : ISwApiConnector
    {
        public async Task<FilmCollection> GetFilmsAsync(CancellationToken cancellationToken)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("https://swapi.dev/api/films/", cancellationToken);
            var apiResponse = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<FilmCollection>(apiResponse);
        }

        public async Task<Film> GetFilmAsync(int film, CancellationToken cancellationToken)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync($"https://swapi.dev/api/films/{film}/", cancellationToken);
            var apiResponse = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<Film>(apiResponse);
        }
    }
}