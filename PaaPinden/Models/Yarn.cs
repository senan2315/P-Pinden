namespace PaaPinden.Models
{
    public class Yarn
    {
        public int YarnID { get; set; } //PK
        public string Material { get; set; } = null!;
        public double Thickness { get; set; }
        public string Color { get; set; } = null!;
        public string Description { get; set; } 
        public double KnittingNeedleSize { get; set; }


    }
}
