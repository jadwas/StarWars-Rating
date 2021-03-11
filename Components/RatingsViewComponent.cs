using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWars_Rating.DataAccess;

namespace StarWars_Rating.Components
{
    public class RatingsViewComponent : ViewComponent
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingsViewComponent(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var comments = await _ratingRepository.ListForFilmAsync(Id);
            return await Task.FromResult((IViewComponentResult)View("RatingsViewComponent", comments));
        }
    }
}
