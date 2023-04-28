using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id =1,
                Name = "Spider Man",
                FirstName = "Mohammad Hossein",
                LastName = "Mehryar",
                Place = "New York City"

            },
            new SuperHero
            {
                Id = 2 ,
                Name = "Wonder Woman",
                FirstName = "Farkhondeh",
                LastName = "Namazi",
                Place = "New York City"
            }

         };


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
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        //public async Task<IActionResult> GetAllHeroes()
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return NotFound("Sorry,but this Hero doesn't exist!");
            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id,SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return NotFound("Sorry,but this Hero doesn't exist!");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(superHeroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return NotFound("Sorry,but this Hero doesn't exist!");

            superHeroes.Remove(hero);
            return Ok(superHeroes);
        }
    }
}
