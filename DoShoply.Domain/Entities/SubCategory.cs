using System.ComponentModel.DataAnnotations.Schema;
using DoShoply.Domain.Base;

namespace DoShoply.Domain.Entities
{
    public class SubCategory : BaseEntity
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<MainCategory> MainCategories { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
