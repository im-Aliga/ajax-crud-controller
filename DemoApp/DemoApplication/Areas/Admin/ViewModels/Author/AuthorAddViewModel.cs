namespace DemoApplication.Areas.Admin.ViewModels.Author
{
    public class AuthorAddViewModel
    {

     
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AuthorAddViewModel()
        {

        }
        public AuthorAddViewModel( string firstName, string lastName)
        {
            
            FirstName = firstName;
            LastName = lastName;
        }

       
    }
}
