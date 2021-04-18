using NewThinkersProject.Border.Repositories;
using NewThinkersProject.Border.UseCase;
using NewThinkersProject.DTO.Pokemon.AddPokemon;
using NewThinkersProject.DTO.Pokemon.DeletePokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.UseCase.Pokemon
{
    public class DeletePokemonUseCase : IDeletePokemonUseCase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public DeletePokemonUseCase(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public DeletePokemonResponse Execute(DeletePokemonRequest request)
        {
            var response = new DeletePokemonResponse();

            try
            {
                var deleted = _pokemonRepository.Delete(request.id);
                if (deleted)
                {
                    response.message = "Pokemon deletado!";
                    return response;
                }

                else
                {
                    response.message = "Erro ao deleter o pokemon";
                    return response;
                }
            }
            catch
            {
                response.message = "Erro ao deleter o pokemon";
                return response;
            }
        }
    }
}
