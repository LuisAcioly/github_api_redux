using NewThinkersProject.DTO.Pokemon.UpdatePokemon;
using NewThinkersProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Border.Adapter
{
    public interface IUpdatePokemonAdapter
    {
        Pokemon RequestToPokemonConversor(UpdatePokemonRequest request);
    }
}
