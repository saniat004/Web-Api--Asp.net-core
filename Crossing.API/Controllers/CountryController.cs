using Crossing.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Crossing.API.Models;
using Microsoft.AspNetCore.Http;

namespace Crossing.API.Controllers
{
    [ApiController] //using this attribute to make it look easier for developer
    [Route("/")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryInfoRepository _countryInfoRepository;
        private readonly IMapper _mapper;
        //injecting our mapper and repository 
        public CountryController(ICountryInfoRepository countryInfoRepository, IMapper mapper)
        {
            _countryInfoRepository = countryInfoRepository ??
                throw new ArgumentNullException(nameof(countryInfoRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        //request for getting  all the data of the country and borders (home page :  https://crossingbordersaniat.azurewebsites.net ) 
        [HttpGet]
        public IActionResult GetAllCountry()
        {

            var CountryEntities = _countryInfoRepository.GetCountries();

            return Ok(_mapper.Map<IEnumerable<BorderDto>>(CountryEntities));
        }


        //getting the request for specific list of crossing points by matching the name of destination ( //https://crossingbordersaniat.azurewebsites.net/pan )
        [HttpGet("{nam}")]
        public IActionResult GetBordersInfo(string nam)
        {

            if (!_countryInfoRepository.CountryExists(nam))
            {
                return NotFound();
            }
            var BordersInfo = _countryInfoRepository.GetBorderGates(nam);


            return Ok(_mapper.Map<BorderGatesDto>(BordersInfo));

        }
    }
}
      