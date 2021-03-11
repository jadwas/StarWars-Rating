using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace StarWars_Rating.API.Models
{
    /// <summary>
    /// A Star Wars film
    /// </summary>
    public partial class Film
    {
        /// <summary>
        /// The people resources featured within this film.
        /// </summary>
        [JsonProperty("characters")]
        public List<object> Characters { get; set; }

        /// <summary>
        /// The ISO 8601 date format of the time that this resource was created.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// The director of this film.
        /// </summary>
        [JsonProperty("director")]
        public string Director { get; set; }

        /// <summary>
        /// the ISO 8601 date format of the time that this resource was edited.
        /// </summary>
        [JsonProperty("edited")]
        public DateTimeOffset Edited { get; set; }

        /// <summary>
        /// The episode number of this film.
        /// </summary>
        [JsonProperty("episode_id")]
        public long EpisodeId { get; set; }

        /// <summary>
        /// The opening crawl text at the beginning of this film.
        /// </summary>
        [JsonProperty("opening_crawl")]
        public string OpeningCrawl { get; set; }

        /// <summary>
        /// The planet resources featured within this film.
        /// </summary>
        [JsonProperty("planets")]
        public List<object> Planets { get; set; }

        /// <summary>
        /// The producer(s) of this film.
        /// </summary>
        [JsonProperty("producer")]
        public string Producer { get; set; }

        /// <summary>
        /// The release date at original creator country.
        /// </summary>
        [JsonProperty("release_date")]
        public DateTimeOffset ReleaseDate { get; set; }

        /// <summary>
        /// The species resources featured within this film.
        /// </summary>
        [JsonProperty("species")]
        public List<object> Species { get; set; }

        /// <summary>
        /// The starship resources featured within this film.
        /// </summary>
        [JsonProperty("starships")]
        public List<object> Starships { get; set; }

        /// <summary>
        /// The title of this film.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// The url of this resource
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// The vehicle resources featured within this film.
        /// </summary>
        [JsonProperty("vehicles")]
        public List<object> Vehicles { get; set; }

        public int Id
        {
            get
            {
                if (Url.Segments.Length > 0 && int.TryParse(Url.Segments[Url.Segments.Length - 1].Split('/').ToList().FirstOrDefault(f => !string.IsNullOrEmpty(f)), out var result))
                    return result;
                return -1;
            }
        }
    }

    public partial class Film
    {
        public static Film FromJson(string json) => JsonConvert.DeserializeObject<Film>(json, Converter.Settings);
    }
}