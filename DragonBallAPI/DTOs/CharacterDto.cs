using System.Globalization;

namespace DragonBallAPI.DTOs
{
    public class CharacterDto
    {
        public string Name { get; set; } = string.Empty;
        public string Ki { get; set; } = string.Empty;
        public string Race { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public String Description { get; set; } = String.Empty;
        public string Affiliation { get; set; } = string.Empty;
        public List<TransformationDto> Transformations { get; set; } = new();
    }
}
