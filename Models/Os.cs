using System.Text.Json.Serialization;

namespace Dolgozat.Models
{
    public class Os
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual Computer Computer { get; set; }
    }
}
