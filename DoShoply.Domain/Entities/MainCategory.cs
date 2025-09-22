using DoShoply.Domain.Base;

namespace DoShoply.Domain.Entities
{
    public class MainCategory : BaseEntity
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
