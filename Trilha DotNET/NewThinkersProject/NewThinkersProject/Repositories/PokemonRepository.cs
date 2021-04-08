using NewThinkersProject.Border.Repositories;
using NewThinkersProject.Context;
using NewThinkersProject.DTO.Pokemon.AddPokemon;
using NewThinkersProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly LocalDbContext _local;

        public PokemonRepository(LocalDbContext local)
        {
            _local = local;
        }

        public void Add(Pokemon newPokemon)
        {
            _local.pokemon.Add(newPokemon);
            _local.SaveChanges();
        }
    }
}
