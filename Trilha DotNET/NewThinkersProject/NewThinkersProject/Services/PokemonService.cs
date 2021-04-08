using Microsoft.EntityFrameworkCore;
using NewThinkersProject.Context;
using NewThinkersProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly LocalDbContext _local;

        public PokemonService(LocalDbContext local)
        {
            _local = local;
        }

        public bool AddPokemon(Pokemon pokemon)
        {
            _local.pokemon.Add(pokemon);
            _local.SaveChanges();

            return true;
        }

        public bool DeletePokemon(int id)
        {
            var deletedObj = _local.pokemon.Where(d => d.id == id).FirstOrDefault();
            _local.pokemon.Remove(deletedObj);
            _local.SaveChanges();

            return true;
        }

        public Pokemon GetPokemonById(int id)
        {
            return _local.pokemon.Where(d => d.id == id).FirstOrDefault();
        }

        public List<Pokemon> GetPokemonList()
        {
            return _local.pokemon.ToList();
        }

        public bool UpdatePokemon(Pokemon newPokemon)
        {
            _local.Attach(newPokemon);
            _local.Entry(newPokemon).State = EntityState.Modified;
            _local.SaveChanges();
            return true;
        }
    }
}
