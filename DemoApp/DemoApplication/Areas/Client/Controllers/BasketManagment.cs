using DemoApplication.Areas.Client.ViewComponents;
using DemoApplication.Areas.Client.ViewModels.Basket;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Text.Json;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    [Route("basket")]
    public class BasketManagment : Controller
    {
        private readonly DataContext _dataContext;

        public BasketManagment(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        #region Add

        [HttpGet("add/{id}", Name = "client-basket-add")]
        public async Task<IActionResult> AddAsync([FromRoute] int id)
        {
            var products = await _dataContext.Books.FirstOrDefaultAsync(p => p.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            var booksViewModel = new List<BasketViewModel>();

            var productCookie = HttpContext.Request.Cookies["products"];
            if (productCookie == null)
            {
                var model = new List<BasketViewModel>()
                {
                    new BasketViewModel(products.Id, products.Title, String.Empty, products.Price, 1, products.Price)
                };

                HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(model));

            }
            else
            {
                booksViewModel = JsonSerializer.Deserialize<List<BasketViewModel>>(productCookie);
                var cookieModel = booksViewModel.FirstOrDefault(b => b.Id == products.Id);

                if (cookieModel == null)
                {
                    booksViewModel.Add(new BasketViewModel(products.Id, products.Title, String.Empty, products.Price, 1, products.Price));
                    HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(booksViewModel));
                }
                else
                {
                    cookieModel.Quantitiy += 1;
                    cookieModel.Total = cookieModel.Price * cookieModel.Quantitiy;
                    HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(booksViewModel));

                }


            }
            return ViewComponent(nameof(ShopCard), booksViewModel);
        }
        #endregion

        #region Delete

        [HttpGet("delete/{id}", Name = "client-basket-delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var products = await _dataContext.Books.FirstOrDefaultAsync(p => p.Id == id);

            if (products == null) return NotFound();

            var booksCookie = HttpContext.Request.Cookies["products"];

            if (booksCookie == null) return NotFound();

            var books = JsonSerializer.Deserialize<List<BasketViewModel>>(booksCookie);

            var cookieModel = books.FirstOrDefault(b => b.Id == products.Id);
            if (cookieModel.Quantitiy > 1)
            {
                cookieModel.Quantitiy -= 1;
                cookieModel.Total = cookieModel.Total - cookieModel.Price;
            }
            else
            {
                books.RemoveAll(b => b.Id == products.Id);

            }

            HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(books));



            return ViewComponent(nameof(ShopCard), books);
        } 
        #endregion

    }
}
