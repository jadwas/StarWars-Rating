using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWars_Rating.API;

namespace StarWars_Rating.Components
{
    public class FilmsViewComponent : ViewComponent
    {
        private readonly ISwApiConnector _apiConnector;

        public FilmsViewComponent(ISwApiConnector apiConnector)
        {
            _apiConnector = apiConnector;
        }
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var model = await _apiConnector.GetFilmsAsync(cancellationToken);
            return await Task.FromResult((IViewComponentResult)View("FilmsViewComponent", model));
        }
    }
}
