using Crossing.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crossing.API.Services
{
   public interface ICountryInfoRepository
    {
        IEnumerable<Country> GetCountries();
        BorderGates GetBorderGates(string dest);
        bool CountryExists(string name);
    }
}
