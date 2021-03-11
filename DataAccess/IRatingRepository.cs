using System.Collections.Generic;
using System.Threading.Tasks;
using StarWars_Rating.DataAccess.Models;

namespace StarWars_Rating.DataAccess
{
    public interface IRatingRepository
    {
        Task<List<Rate>> ListForFilmAsync(int? film);
        Task CreateAsync(Rate rate);

    }
}
