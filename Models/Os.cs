using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dolgozat.Models
{
    public class Os
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ComputerId { get; set; }
        [JsonIgnore]
        public virtual Computer Computer { get; set; }
    }

}
