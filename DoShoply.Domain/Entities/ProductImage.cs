using System.ComponentModel.DataAnnotations.Schema;

namespace DoShoply.Domain.Entities
{
    public class ProductImage
    {
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
