namespace MShWeb.Domain.Entities
{
    public class Image : Entity<Guid>
    {
        public string Source { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
