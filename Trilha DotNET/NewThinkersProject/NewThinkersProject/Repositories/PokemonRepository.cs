using Microsoft.EntityFrameworkCore;
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

        public int Add(Pokemon newPokemon)
        {
            _local.pokemon.Add(newPokemon);
            _local.SaveChanges();
            return newPokemon.id;
        }

        public bool Delete(int id)
        {
            var deletedObj = _local.pokemon.Where(d => d.id == id).FirstOrDefault();

            if(deletedObj == null)
            {
                return false;
            }

            _local.pokemon.Remove(deletedObj);
            _local.SaveChanges();

            return true;
        }

        public Pokemon Get(int id)
        {
            return _local.pokemon.Where(d => d.id == id).FirstOrDefault();
        }

        public List<Pokemon> GetList()
        {
            return _local.pokemon.ToList();
        }

        public void  Update(Pokemon newPokemon)
        {
            _local.Attach(newPokemon);
            _local.Entry(newPokemon).State = EntityState.Modified;
            _local.SaveChanges();
        }
    }
}
