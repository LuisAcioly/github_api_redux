using NewThinkersProject.Border.Adapter;
using NewThinkersProject.Border.Repositories;
using NewThinkersProject.Border.UseCase;
using NewThinkersProject.DTO.Pokemon.UpdatePokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.UseCase.Pokemon
{
    public class UpdatePokemonUseCase : IUpdatePokemonUseCase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IUpdatePokemonAdapter _adapter;

        public UpdatePokemonUseCase(IPokemonRepository pokemonRepository, IUpdatePokemonAdapter adapter)
        {
            _pokemonRepository = pokemonRepository;
            _adapter = adapter;
        }

        public UpdatePokemonResponse Execute(UpdatePokemonRequest request)
        {
            var response = new UpdatePokemonResponse();
            try
            {
                if (request.name.Length < 20)
                {
                    response.message = "Erro na alteração";
                    return response;
                }

                var newPokemon = _adapter.RequestToPokemonConversor(request);
                _pokemonRepository.Update(newPokemon);
                response.message = "Alteração realizada com sucesso";
                return response;
            }
            catch
            {
                response.message = "Erro na alteração";
                return response;
            }
        }
    }
}
