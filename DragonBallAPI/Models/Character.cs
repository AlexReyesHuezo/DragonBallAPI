namespace DragonBallAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ki { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string Affiliation { get; set; }

        public ICollection<Transformation> Transformations { get; set; }
    }
}
