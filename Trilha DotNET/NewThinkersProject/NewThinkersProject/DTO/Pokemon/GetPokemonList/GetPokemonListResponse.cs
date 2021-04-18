using System;
using System.Collections.Generic;
using NewThinkersProject.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.DTO.Pokemon.DeletePokemon
{
    public class GetPokemonListResponse
    {
        public List<Entities.Pokemon> list { get; set; }
        public string message { get; set; }
    }
}
