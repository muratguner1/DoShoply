using System.ComponentModel.DataAnnotations.Schema;
using DoShoply.Domain.Base;
using DoShoply.Domain.Enums;

namespace DoShoply.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public int ProductStock { get; set; }
        public Colors Color { get; set; }

        [ForeignKey(nameof(SubCategory))]
        public Guid SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
