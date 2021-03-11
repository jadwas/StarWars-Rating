using Microsoft.AspNetCore.Mvc;
using StarWars_Rating.Models;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using StarWars_Rating.API;
using StarWars_Rating.DataAccess;
using StarWars_Rating.DataAccess.Models;

namespace StarWars_Rating.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISwApiConnector _swApiConnector;
        private readonly IRatingRepository _ratingRepository;


        public HomeController(ISwApiConnector swApiConnector, IRatingRepository ratingRepository)
        {
            _swApiConnector = swApiConnector;
            _ratingRepository = ratingRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FilmDetails(int film, CancellationToken cancellationToken)
        {
            var loadedFilm = await _swApiConnector.GetFilmAsync(film, cancellationToken);
            return View(loadedFilm);
        }
        
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddComment(Rate rate)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("FilmDetails", new { film = rate.FilmId });
            }

            await _ratingRepository.CreateAsync(rate);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
