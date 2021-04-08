using NewThinkersProject.DTO.Pokemon.AddPokemon;
using NewThinkersProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Border.Adapter
{
    public interface IAddPokemonAdapter
    {
        Pokemon RequestToPokemonConversor(AddPokemonRequest request);
    }
}
