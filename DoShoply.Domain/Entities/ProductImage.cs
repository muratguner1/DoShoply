using System.ComponentModel.DataAnnotations.Schema;
using DoShoply.Domain.Base;

namespace DoShoply.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
