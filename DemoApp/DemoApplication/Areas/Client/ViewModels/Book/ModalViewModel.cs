using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Client.ViewModels.Book
{
    public class ModalViewModel
    {
        public ModalViewModel(int id, string title, decimal price, string author, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Price = price;
            Author = author;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }

       
    }
}
