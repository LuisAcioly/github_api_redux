using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewThinkersProject.Border.UseCase;
using NewThinkersProject.DTO.Pokemon.AddPokemon;
using NewThinkersProject.DTO.Pokemon.DeletePokemon;
using NewThinkersProject.DTO.Pokemon.GetPokemonById;
using NewThinkersProject.DTO.Pokemon.UpdatePokemon;
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
        private readonly IDeletePokemonUseCase _deletePokemonUseCase;
        private readonly IGetPokemonByIdUseCase _getPokemonByIdUseCase;
        private readonly IGetPokemonListUseCase _getPokemonListUseCase;
        private readonly IUpdatePokemonUseCase _updatePokemonUseCase;


        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemon, IAddPokemonUseCase addPokemonUseCase, IDeletePokemonUseCase deletePokemonUseCase, IGetPokemonByIdUseCase getPokemonByIdUseCase, IGetPokemonListUseCase getPokemonListUseCase, IUpdatePokemonUseCase updatePokemonUseCase)
        {
            _logger = logger;
            _pokemon = pokemon;

            _addPokemonUseCase = addPokemonUseCase;
            _deletePokemonUseCase = deletePokemonUseCase;
            _getPokemonByIdUseCase = getPokemonByIdUseCase;
            _getPokemonListUseCase = getPokemonListUseCase;
            _updatePokemonUseCase = updatePokemonUseCase;
        }

        [HttpGet]
        public IActionResult ListPokemons()
        {
            var response = _getPokemonListUseCase.Execute();
            return Ok(response.message);
        }

        [HttpPost]
        public IActionResult AddPokemon([FromBody] AddPokemonRequest request)
        {
            return Ok(_addPokemonUseCase.Execute(request));
        }

        [HttpPut]
        public IActionResult UpdatePokemon([FromBody] UpdatePokemonRequest request)
        {
            return Ok(_updatePokemonUseCase.Execute(request));
        }

        [HttpGet("{id}")]
        public IActionResult GetPokemonById(int id)
        {
            var request = new GetPokemonByIdRequest();
            request.id = id;
            var response = _getPokemonByIdUseCase.Execute(request);
            return Ok(response.message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePokemon(int id)
        {
            var request = new DeletePokemonRequest();
            request.id = id;
            return Ok(_deletePokemonUseCase.Execute(request));
        }
    }
}
