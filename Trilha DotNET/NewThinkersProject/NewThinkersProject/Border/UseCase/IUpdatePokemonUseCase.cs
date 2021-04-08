using NewThinkersProject.DTO.Pokemon.UpdatePokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Border.UseCase
{
    public interface IUpdatePokemonUseCase
    {
        UpdatePokemonResponse Execute(UpdatePokemonRequest request);
    }
}
