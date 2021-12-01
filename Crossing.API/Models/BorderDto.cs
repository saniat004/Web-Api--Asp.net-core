using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crossing.API.Models
{
    public class BorderDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
       public ICollection<BorderGatesDto> BorderGates { get; set; } = new List<BorderGatesDto>();
    }
}
