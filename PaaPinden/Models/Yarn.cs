namespace PaaPinden.Models
{
    public class Yarn
    {
        public int YarnID { get; set; } //PK
        public string Material { get; set; }
        public double Thickness { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public double KnittingNeedleSize { get; set; }


    }
}
