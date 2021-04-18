using NewThinkersProject.Border.Repositories;
using NewThinkersProject.Border.UseCase;
using NewThinkersProject.DTO.Pokemon.GetPokemonById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.UseCase.Pokemon
{
    public class GetPokemonByIdUseCase : IGetPokemonByIdUseCase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public GetPokemonByIdUseCase(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public GetPokemonByIdResponse Execute(GetPokemonByIdRequest request)
        {
            var response = new GetPokemonByIdResponse();
            try
            {
                var pokemon = _pokemonRepository.Get(request.id);
                response.message = "Nome: " + pokemon.name + "\nTipo: " + pokemon.type;

                return response;
            }
            catch
            {
                response.message = "Pokemon não encontrado";
                return response;
            }
        }
    }
}
