namespace Dolgozat.Models.DtoS
{
    public class UpdateComputerDto
    {
        public string Brand { get; set; }

        public string Type { get; set; }

        public double Display { get; set; }
        public int Memory { get; set; }

        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
