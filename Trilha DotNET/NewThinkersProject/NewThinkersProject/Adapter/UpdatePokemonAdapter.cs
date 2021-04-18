using NewThinkersProject.Border.Adapter;
using NewThinkersProject.DTO.Pokemon.UpdatePokemon;
using NewThinkersProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Adapter
{
    public class UpdatePokemonAdapter : IUpdatePokemonAdapter
    {
        public Pokemon RequestToPokemonConversor(UpdatePokemonRequest request)
        {
            var pokemon = new Pokemon();
            pokemon.id = request.id;
            pokemon.name = request.name;
            pokemon.type = request.type;

            return pokemon;
        }
    }
}
