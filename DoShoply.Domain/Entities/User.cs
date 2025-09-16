namespace DoShoply.Domain.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();
    }
}
