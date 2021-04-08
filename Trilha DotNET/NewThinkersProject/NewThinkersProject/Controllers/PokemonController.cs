using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewThinkersProject.Border.UseCase;
using NewThinkersProject.DTO.Pokemon.AddPokemon;
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
        private readonly IAddPokemonUseCase _addPokemonUseCase;

        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemon, IAddPokemonUseCase addPokemonUseCase)
        {
            _logger = logger;
            _pokemon = pokemon;
            _addPokemonUseCase = addPokemonUseCase;
        }

        [HttpGet]
        public IActionResult ListPokemons()
        {
            return Ok(_pokemon.GetPokemonList());
        }

        [HttpPost]
        public IActionResult AddPokemon([FromBody] AddPokemonRequest request)
        {
            return Ok(_addPokemonUseCase.Execute(request));
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
