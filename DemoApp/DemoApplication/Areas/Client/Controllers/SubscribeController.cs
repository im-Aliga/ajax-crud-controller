using DemoApplication.Areas.Client.ViewModels.Subscribe;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    [Route("subscribe")]
    public class SubscribeController : Controller
    {
        private readonly DataContext _dbContext;

        public SubscribeController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }



        #region Add
        [HttpPost("add", Name = "subscribe-add")]
        public async Task<ActionResult> AddAsync(AddViewModel model)
        {
            var currentEmail = _dbContext.Subscribes.FirstOrDefaultAsync(e => e.Email == model.Email);
            if (!ModelState.IsValid || currentEmail != null)
            {
                return BadRequest();
            }
            if (model.Email == null)
            {
                await _dbContext.Subscribes.AddAsync(new Subscribe
                {
                    Email = model.Email,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                });

            }
            await _dbContext.SaveChangesAsync();
            return Ok();
        } 
        #endregion


    }
}
