using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crossing.API.Entities
{
    public class BorderGates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required]
        [MaxLength(50)]
        public string Destination { get; set; }
        [MaxLength(200)]
        public string List { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public int CountryId { get; set; }

    }
}
