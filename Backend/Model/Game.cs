namespace backend.Model
{
    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Genre { get; set; }
        public string? Company { get; set; }
        public float? Price { get; set; }
        public string? ReleaseDate { get; set; }
    }

}
