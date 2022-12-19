using DemoApplication.Areas.Client.ViewModels.Basket;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DemoApplication.Areas.Client.ViewComponents
{
    [ViewComponent]
    public class ShopCard:ViewComponent
    {
        public IViewComponentResult Invoke(List<BasketViewModel>?viewModels)
        {
            var cookie = HttpContext.Request.Cookies["products"];
            var cookieViewmodel = new List<BasketViewModel>();
            if (cookie != null)
            {

                cookieViewmodel = JsonSerializer.Deserialize<List<BasketViewModel>>(cookie);

            }
            if (viewModels is not null)
            {
                cookieViewmodel = viewModels;
            }
            return View(cookieViewmodel);
        }

    }
}
