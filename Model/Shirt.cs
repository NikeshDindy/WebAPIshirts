namespace WebAPIdemo.Model
{
    public class Shirt
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int Size { get; set; }
        public decimal Price { get; set; }
    }
}
