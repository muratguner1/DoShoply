using System.ComponentModel.DataAnnotations.Schema;

namespace DoShoply.Domain.Entities
{
    public class SubCategory
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<MainCategory> MainCategories { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
