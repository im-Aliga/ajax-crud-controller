using DemoApplication.Areas.Admin.ViewModels.Subscribe;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/subscribe")]
    public class SubscribeController : Controller
    {
        private readonly DataContext _dataContext;

        public SubscribeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        #region List
        [HttpGet("list", Name = "admin-subscribes-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dataContext.Subscribes
                .Select(s => new SubscribeItemViewModel(s.Email, s.CreatedAt))
                .ToListAsync();

            return View(model);
        } 
        #endregion
    }
}
