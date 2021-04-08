using NewThinkersProject.DTO.Pokemon.AddPokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Border.UseCase
{
    public interface IAddPokemonUseCase
    {
        AddPokemonResponse Execute(AddPokemonRequest request);
    }
}
