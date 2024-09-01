namespace GameZone.Data
{
    public class Category : BaseEntity
    {
        public ICollection<Game> Games { get; set; } = new HashSet<Game>();

    }
}
