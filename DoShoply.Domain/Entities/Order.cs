using System.ComponentModel.DataAnnotations.Schema;
using DoShoply.Domain.Base;

namespace DoShoply.Domain.Entities
{
    public class Order : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Checkout))]
        public Guid CheckoutID { get; set; }
        public virtual Checkout Checkout { get; set; }
    }
}
