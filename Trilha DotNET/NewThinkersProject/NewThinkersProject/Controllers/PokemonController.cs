using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewThinkersProject.Entities;
using NewThinkersProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IPokemonService _pokemon;

        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemon)
        {
            _logger = logger;
            _pokemon = pokemon;
        }

        [HttpGet]
        public IActionResult ListPokemons()
        {
            return Ok(_pokemon.GetPokemonList());
        }

        [HttpPost]
        public IActionResult AddPokemon([FromBody] Pokemon pokemon)
        {
            return Ok(_pokemon.AddPokemon(pokemon));
        }

        [HttpPut]
        public IActionResult UpdatePokemon([FromBody] Pokemon pokemon)
        {
            return Ok(_pokemon.UpdatePokemon(pokemon));
        }

        [HttpGet("{id}")]
        public IActionResult GetPokemonById(int id)
        {
            return Ok(_pokemon.GetPokemonById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePokemon(int id)
        {
            return Ok(_pokemon.DeletePokemon(id));
        }
    }
}
