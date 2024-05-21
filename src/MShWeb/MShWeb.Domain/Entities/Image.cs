namespace MShWeb.Domain.Entities
{
    public class Image : Entity<Guid>
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string Source { get; set; }
    }
}
