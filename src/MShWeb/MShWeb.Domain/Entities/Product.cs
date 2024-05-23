namespace MShWeb.Domain.Entities
{
    public class Product : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        
    }
}
