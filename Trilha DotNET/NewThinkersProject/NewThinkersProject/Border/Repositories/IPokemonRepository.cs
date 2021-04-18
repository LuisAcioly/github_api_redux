using NewThinkersProject.DTO.Pokemon.AddPokemon;
using NewThinkersProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Border.Repositories
{
    public interface IPokemonRepository
    {
        int Add(Pokemon newPokemon);

        bool Delete(int id);

        Pokemon Get(int id);

        List<Pokemon> GetList();

        void Update(Pokemon newPokemon);

    }
}
