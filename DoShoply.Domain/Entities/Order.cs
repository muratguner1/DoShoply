using System.ComponentModel.DataAnnotations.Schema;

namespace DoShoply.Domain.Entities
{
    public class Order
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Checkout))]
        public Guid CheckoutID { get; set; }
        public virtual Checkout Checkout { get; set; }
    }
}
