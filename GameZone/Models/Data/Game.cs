namespace GameZone.Data
{
    public class Game : BaseEntity
    {



        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;


        [MaxLength(250)]
        public string Cover { get; set; } = string.Empty;

        public int CategoryId { get; set; } //foreign Key
        public Category Category { get; set; } //Navigitional Property


        public ICollection<GameDevice> Devices { get; set; } = new HashSet<GameDevice>();
    }
}
