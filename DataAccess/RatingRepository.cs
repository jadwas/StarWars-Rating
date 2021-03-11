using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWars_Rating.DataAccess.Models;

namespace StarWars_Rating.DataAccess
{
    public class RatingRepository : IRatingRepository
    {
        private readonly RatingContext _ratingContext;

        public RatingRepository(RatingContext ratingContext)
        {
            _ratingContext = ratingContext;
        }

        public async Task<List<Rate>> ListForFilmAsync(int? film)
        {
            if (!film.HasValue) return new List<Rate>();
            return await _ratingContext.Rates.Where(w => w.FilmId == film).OrderBy(o => o.StoreDateTime).AsNoTracking().ToListAsync();
        }

        public async Task CreateAsync(Rate rate)
        {
            rate.StoreDateTime = DateTime.Now;
            await _ratingContext.Rates.AddAsync(rate);
            await _ratingContext.SaveChangesAsync();
        }
    }
}