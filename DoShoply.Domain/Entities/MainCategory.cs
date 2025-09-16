namespace DoShoply.Domain.Entities
{
    public class MainCategory
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
