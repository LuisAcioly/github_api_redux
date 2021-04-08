using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewThinkersProject.Entities
{
    public class Pokemon
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public string type { get; set; }
    }
}
