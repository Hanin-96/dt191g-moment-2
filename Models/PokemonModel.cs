using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace moment2.Models
{
    public class PokemonModel
    {
        public string? name { get; set; }

        public int hp { get; set; }

        public string? rarity { get; set; }
    }
}
