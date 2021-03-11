using System.Threading;
using System.Threading.Tasks;
using StarWars_Rating.API.Models;

namespace StarWars_Rating.API
{
    public interface ISwApiConnector
    {
        Task<FilmCollection> GetFilmsAsync(CancellationToken cancellationToken);
        Task<Film> GetFilmAsync(int film, CancellationToken cancellationToken);

    }
}
