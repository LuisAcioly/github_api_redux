using NewThinkersProject.Border.Repositories;
using NewThinkersProject.Border.UseCase;
using NewThinkersProject.DTO.Pokemon.DeletePokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.UseCase.Pokemon
{
    public class GetPokemonListUseCase : IGetPokemonListUseCase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public GetPokemonListUseCase(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public GetPokemonListResponse Execute()
        {
            var response = new GetPokemonListResponse();
            try
            {
                response.list = _pokemonRepository.GetList();

                string message = string.Empty;
                foreach (Entities.Pokemon pokemon in response.list)
                {
                    string pokemonString = "Nome: " + pokemon.name + " | Tipo: " + pokemon.type + "\n";
                    message += pokemonString;
                }

                response.message = message;

                return response;
            }
            catch
            {
                response.message = "Não foi possivel listar os pokemons";
                return response;
            }
        }
    }
}
