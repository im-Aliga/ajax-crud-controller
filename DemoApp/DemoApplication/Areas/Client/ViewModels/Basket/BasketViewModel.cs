namespace DemoApplication.Areas.Client.ViewModels.Basket
{
    public class BasketViewModel
    {

        public int Id { get; set; }   
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantitiy { get; set; }   
        public decimal Total { get; set; }
        public BasketViewModel(int id, string title, string imgUrl, decimal price, int quantitiy, decimal total)
        {
            Id = id;
            Title = title;
            ImgUrl = imgUrl;
            Price = price;
            Quantitiy = quantitiy;
            Total = total;
        }
    }
}
