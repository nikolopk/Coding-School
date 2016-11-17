namespace CF.Models.MVC.Category
{
    public class CategoryViewModel : ICachableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectCount { get; set; }
    }
}
