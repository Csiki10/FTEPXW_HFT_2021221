using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTEPXW_HFT_2021221.Models
{
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DirectorID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Citizenship { get; set; }

        // --------------------------------------

        [NotMapped]
        public virtual ICollection<Movie> Movies { get; set; }

        public Director()
        {
            Movies = new HashSet<Movie>();
        }

    }
}
