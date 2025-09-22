using System.ComponentModel.DataAnnotations.Schema;
using DoShoply.Domain.Base;

namespace DoShoply.Domain.Entities
{
    public class Cart : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
