using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWars_Rating.DataAccess.Models;

namespace StarWars_Rating.Components
{
    public class CreateRatingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {

            var rate = new Rate()
            {
                FilmId = Id
            };
            return await Task.FromResult((IViewComponentResult)View("CreateRatingViewComponent", rate));

        }
    }
}
