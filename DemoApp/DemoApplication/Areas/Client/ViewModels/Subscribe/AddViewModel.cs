using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Client.ViewModels.Subscribe
{
    public class AddViewModel
    {
       
        [EmailAddress]
        public string Email { get; set; }
       
    }
}
