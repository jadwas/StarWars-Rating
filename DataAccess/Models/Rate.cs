using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWars_Rating.DataAccess.Models
{
    public class Rate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FilmId { get; set; }

        [Required]
        public string UserName { get; set; }
        public int Rating { get; set; }

        public DateTime StoreDateTime { get; set; }

    }
}
