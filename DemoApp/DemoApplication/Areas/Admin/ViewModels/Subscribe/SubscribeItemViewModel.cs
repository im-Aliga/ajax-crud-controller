using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Admin.ViewModels.Subscribe
{
    public class SubscribeItemViewModel
    {

        [EmailAddress]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public SubscribeItemViewModel(string email, DateTime createdAt)
        {
            Email = email;
            CreatedAt = createdAt;
        }
    }
}
