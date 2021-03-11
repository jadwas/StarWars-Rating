using System.Collections.Generic;
using Newtonsoft.Json;

namespace StarWars_Rating.API.Models
{
    public class FilmCollection
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("results")]
        public List<Film> Results { get; set; }
    }
}
