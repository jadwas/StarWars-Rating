using StarWars_Rating.DataAccess.Models;

namespace StarWars_Rating.DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(RatingContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
