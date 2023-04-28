﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }


        [HttpGet]
        //public async Task<IActionResult> GetAllHeroes()
        //for show information in schemas and also example valur we change the code to this one :==>
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            //var superHero = new List<SuperHero>
            //{
            //    new SuperHero
            //    {
            //        Id =1,
            //        Name = "Spider Man",
            //        FirstName = "Mohammad Hossein",
            //        LastName = "Mehryar",
            //        Place = "New York City"

            //    }

            // };
            return _superHeroService.GetAllHeroes();
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        //public async Task<IActionResult> GetAllHeroes()
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = _superHeroService.GetSingleHero(id);
            if (result is null)
                return NotFound("Hero not found");
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = _superHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id,SuperHero request)
        {
            var result = _superHeroService.UpdateHero(id, request);
            if (result is null)
                return NotFound("Hero not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = _superHeroService.DeleteHero(id);
            if (result is null)
                return NotFound("Hero not found");
            return Ok(result);
        }
    }
}
