namespace DragonBallAPI.Models
{
    public class Transformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ki { get; set; }

        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}