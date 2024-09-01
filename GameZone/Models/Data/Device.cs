namespace GameZone.Data
{
    public class Device : BaseEntity
    {
        [MaxLength(250)]
        public string Icon { get; set; } = string.Empty;

        public ICollection<GameDevice> Games { get; set; } = new HashSet<GameDevice>();
    }
}
