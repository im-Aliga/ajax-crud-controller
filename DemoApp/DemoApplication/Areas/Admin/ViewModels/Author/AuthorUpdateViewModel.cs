namespace DemoApplication.Areas.Admin.ViewModels.Author
{
    public class AuthorUpdateViewModel
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AuthorUpdateViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public AuthorUpdateViewModel()
        {


        }

    }
}
