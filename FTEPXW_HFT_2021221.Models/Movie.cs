using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTEPXW_HFT_2021221.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public int MovieId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Music { get; set; }
        [Required]
        public int RunningTime { get; set; }
        [Required]
        public int Budget { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Distributed { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int AgeLimit { get; set; }
        [Required]
        public int Income { get; set; }

        // --------------------------------------

        [ForeignKey(nameof(Protagonist))]
        public int ProtagonistID { get; set; }
        [NotMapped]
        public int Protagonist { get; set; }

        // --------------------------------------

        [ForeignKey(nameof(Director))]
        public int DirectorID { get; set; }
        [NotMapped]
        public int Director { get; set; }

    }
}
