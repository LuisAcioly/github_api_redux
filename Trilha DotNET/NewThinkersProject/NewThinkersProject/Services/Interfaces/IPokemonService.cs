using NewThinkersProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Services
{
    public interface IPokemonService
    {
        bool AddPokemon(Pokemon pokemon);

        List<Pokemon> GetPokemonList();

        Pokemon GetPokemonById(int id);

        bool UpdatePokemon(Pokemon newPokemon);

        bool DeletePokemon(int id);
    }
}
