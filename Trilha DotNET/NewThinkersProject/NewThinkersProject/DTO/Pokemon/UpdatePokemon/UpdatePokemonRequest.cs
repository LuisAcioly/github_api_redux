using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.DTO.Pokemon.UpdatePokemon
{
    public class UpdatePokemonRequest
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public string type { get; set; }
    }
}
