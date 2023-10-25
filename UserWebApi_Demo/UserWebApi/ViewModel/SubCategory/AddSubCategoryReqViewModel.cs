namespace UserWebApi.ViewModel.SubCategory
{
    public class AddSubCategoryReqViewModel
    {
        public int SubcategoryId { get; set; }

        public int? CategoryId { get; set; }

        public string Subcategoryname { get; set; } = null!;
    }
}
