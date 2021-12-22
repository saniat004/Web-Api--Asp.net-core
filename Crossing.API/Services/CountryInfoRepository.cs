using Crossing.API.Contexts;
using Crossing.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crossing.API.Services
{
    
    public class CountryInfoRepository : ICountryInfoRepository
    {
        private readonly CrossingInfoContext _crossingInfoContext;

        //    injecting the context 
        public CountryInfoRepository(CrossingInfoContext crossingInfoContext)
        {
            _crossingInfoContext = crossingInfoContext ?? throw new ArgumentNullException(nameof(crossingInfoContext));
        }


        //method for getting all destinations with all the list of borders  
        public IEnumerable<Country> GetCountries()
        {
            return _crossingInfoContext.Countries.Include(c => c.BorderGates);
        }

        // //method for getting specific destinations with all the list of borders  
        public BorderGates GetBorderGates(string dest)
        {
            var DestinationId = _crossingInfoContext.Countries.Where(b => b.Name == dest).FirstOrDefault().Id;

            return _crossingInfoContext.BorderGates.Where(a => a.CountryId == DestinationId).FirstOrDefault();

        }


        //checks if the country of  destination exists  
        public bool CountryExists(string name)
        {
            return _crossingInfoContext.Countries.Any(c => c.Name == name);
        }





    }
}
//public IEnumerable<BorderGates> GetBorderGates(string nameOfDestination)
//{
//    return _crossingInfoContext.BorderGates
//        .Where(b => b.Destination == nameOfDestination).ToList();
//}