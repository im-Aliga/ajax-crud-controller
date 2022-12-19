using DemoApplication.Areas.Admin.ViewModels.Author;
using DemoApplication.Areas.Client.ViewModels.Book.Update;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Author = DemoApplication.Database.Models.Author;

namespace DemoApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/author")]
    public class AuthorController : Controller
    {
        private readonly DataContext _dataContext;

        public AuthorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region List
        [HttpGet("list", Name = "admin-author-list")]
        public async Task< IActionResult> ListAsync()
        {
            var model =  _dataContext.Authors
                .Select(a => new ListItemViewModel(a.Id, a.FirstName, a.LastName))
                .ToList();
           

            return View(model);
        }

        #endregion

        #region Add
        [HttpPost("add", Name = "author-add")]
        public async Task<ActionResult> AddAsync(AuthorAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var author = new Author
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _dataContext.Authors.AddAsync(author);

            await _dataContext.SaveChangesAsync();

            var id = author.Id;

            return Created("admin-author-list", id);
        }
        #endregion

        #region Update

        [HttpPost("update/{id}", Name = "author-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromForm] AuthorUpdateViewModel model)
        {
            var author = await _dataContext.Authors.FirstOrDefaultAsync(b => b.Id == id);
            if (author is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            author.FirstName = model.FirstName;
            author.LastName = model.LastName;
            await _dataContext.SaveChangesAsync();
            return Ok();
        } 
        #endregion

        #region Delete

        [HttpDelete("delete/{id}", Name = "author-delete-individual")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var author = await _dataContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author is null)
            {
                return NotFound();
            }

            _dataContext.Authors.Remove(author);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        } 
        #endregion
    }
}
