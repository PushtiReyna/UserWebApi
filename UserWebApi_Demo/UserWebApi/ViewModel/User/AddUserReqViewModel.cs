namespace UserWebApi.ViewModel.User
{
    public class AddUserReqViewModel
    {
        public int Id { get; set; }

        public string Fullname { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Mobilenumber { get; set; } = null!;

        public decimal Percentage { get; set; }

        public DateTime Dob { get; set; }

        public int CategoryId { get; set; }

        public int SubcategoryId { get; set; }
    }
}
