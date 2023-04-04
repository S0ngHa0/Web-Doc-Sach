using Đồ_án_của_Thái.Models;
using Đồ_án_của_Thái.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Đồ_án_của_Thái.Controllers
{
    public class ComicsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ComicsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Comics
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Comic comics)
        {
            var comic = new Comic
            {
                NameComic = comics.NameComic,
                Author = comics.Author,
                Category = comics.Category,
                Title = comics.Title,
                Picture = comics.Picture,
            };
            _dbContext.Comics.Add(comic);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Detail(int id)
        {
            var comic = _dbContext.Comics.SingleOrDefault(c => c.Id == id); ;
            if(comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var comic = _dbContext.Comics.SingleOrDefault(c => c.Id == id);
            if(comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Comic comics)
        {
            if (!ModelState.IsValid)
            {
                return View(comics);
            }
            var comic = _dbContext.Comics.SingleOrDefault(c => c.Id == comics.Id);
            comic.NameComic = comics.NameComic;
            comic.Author = comics.Author;
            comic.Category = comics.Category;
            comic.Title = comics.Title;
            comic.Picture = comics.Picture;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Read(int id)
        {
            var read = _dbContext.Chapters.Where(c => c.ComicId == id).ToList();
            return View(read);
        }
        [Authorize]
        public ActionResult CreateChapter()
        {
            var viewModel = new ComicViewModel()
            {
                Comics = _dbContext.Comics.ToList(),
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateChapter(ComicViewModel viewChap)
        {

            var chapter = new Chapter
            {
                ComicId = viewChap.Comic,
                PictureChap = viewChap.PictureChap,
            };
            _dbContext.Chapters.Add(chapter);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            Comic comics = _dbContext.Comics.Find(id);
            if(comics == null)
            {
                return HttpNotFound();
            }
            return View(comics);
        }
        

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            using(var db = new ApplicationDbContext())
            {
                Comic comics = _dbContext.Comics.Find(id);
                _dbContext.Comics.Remove(comics);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var comics = _dbContext.Follows
                .Where(f => f.FolloweeId == userId)
                .Select(f => f.Comic)
                .ToList();
            return View(comics);
        }
    }
}