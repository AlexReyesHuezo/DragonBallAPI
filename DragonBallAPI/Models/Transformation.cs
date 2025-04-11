namespace DragonBallAPI.Models
{
    public class Transformation
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Ki { get; set; } = string.Empty;

        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}