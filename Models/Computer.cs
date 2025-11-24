
namespace Dolgozat.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        
        public string Type { get; set; }

        public double Display { get; set; }
        public int Memory { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime UpdateTime { get; set; }

        public virtual ICollection<Os> OsList { get; set; } = new List<Os>();
    }
}
