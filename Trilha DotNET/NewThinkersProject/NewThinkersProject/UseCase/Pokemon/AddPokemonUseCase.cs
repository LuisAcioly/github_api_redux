using NewThinkersProject.Border.Adapter;
using NewThinkersProject.Border.Repositories;
using NewThinkersProject.Border.UseCase;
using NewThinkersProject.DTO.Pokemon.AddPokemon;
using NewThinkersProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.UseCase.Pokemon
{
    public class AddPokemonUseCase : IAddPokemonUseCase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IAddPokemonAdapter _adapter;

        public AddPokemonUseCase(IPokemonRepository pokemonRepository, IAddPokemonAdapter adapter)
        {
            _pokemonRepository = pokemonRepository;
            _adapter = adapter;
        }

        public AddPokemonResponse Execute(AddPokemonRequest request)
        {
            var response = new AddPokemonResponse();
            try
            {
                var newPokemon = _adapter.RequestToPokemonConversor(request);
                _pokemonRepository.Add(newPokemon);
                response.message = "Adicionado com sucesso";
                return response;
            }
            catch
            {
                response.message = "Erro ao adicionar o produto";
                return response;
            }
        }
    }
}
