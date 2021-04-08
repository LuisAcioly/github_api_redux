using NewThinkersProject.DTO.Pokemon.DeletePokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Border.UseCase
{
    public interface IDeletePokemonUseCase
    {
        DeletePokemonResponse Execute(DeletePokemonRequest request);
    }
}
