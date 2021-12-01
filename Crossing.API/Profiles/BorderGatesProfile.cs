using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crossing.API.Profiles
{
    public class BorderGatesProfile :Profile
    {
        public BorderGatesProfile()
        {
            CreateMap<Entities.BorderGates, Models.BorderGatesDto>();
        }
    }
}
