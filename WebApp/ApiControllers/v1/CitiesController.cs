
using App.Contracts.DAL;
using Microsoft.AspNetCore.Mvc;
using App.DAL.EF;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using WebApp.Util;

namespace WebApp.ApiControllers.v1
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/cities/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CitiesController : ControllerBase
    {
        private readonly IAppUnitOfWork _bll;
        private readonly PublicDTOBllMapper<App.DTO.v1_0.City, App.DAL.DTO.City> _mapper;

        public CitiesController(AppDbContext context, IAppUnitOfWork bll, IMapper autoMapper)
        {
            _bll = bll;
            _mapper = new PublicDTOBllMapper<App.DTO.v1_0.City, App.DAL.DTO.City>(autoMapper);
        }

        /// <summary>
        /// Gets cities by country code.
        /// </summary>
        /// <param name="countryAlpha2Code">The alpha-2 code of the country.</param>
        /// <returns>A list of cities in the specified country.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<App.DTO.v1_0.City>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<App.DTO.v1_0.City>>> GetByCountry(string countryAlpha2Code)
        {
            var cities = await _bll.Cities.GetCityByCountry(countryAlpha2Code);
            if (cities == null || !cities.Any())
            {
                return NotFound();
            }
            return Ok(cities.Select(item => _mapper.Map(item)));
        }

        /// <summary>
        /// Gets a city by name and country code.
        /// </summary>
        /// <param name="cityName">The name of the city.</param>
        /// <param name="countryAlpha2Code">The alpha-2 code of the country.</param>
        /// <returns>The city with the specified name and country code.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(App.DTO.v1_0.City))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<App.DTO.v1_0.City>> GetCity(string cityName, string countryAlpha2Code)
        {
            var city = await _bll.Cities.GetCityByNameAndCountry(cityName, countryAlpha2Code);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map(city));
        }
    }
}
