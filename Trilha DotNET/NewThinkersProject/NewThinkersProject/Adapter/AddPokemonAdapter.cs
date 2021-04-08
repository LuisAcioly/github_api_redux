using NewThinkersProject.Border.Adapter;
using NewThinkersProject.DTO.Pokemon.AddPokemon;
using NewThinkersProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Adapter
{
    public class AddPokemonAdapter : IAddPokemonAdapter
    {
        public Pokemon RequestToPokemonConversor(AddPokemonRequest request)
        {
            var pokemon = new Pokemon();
            pokemon.name = request.name;
            pokemon.type = request.type;

            return pokemon;
        }
    }
}
