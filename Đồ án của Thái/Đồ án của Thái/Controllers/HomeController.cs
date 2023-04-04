using Đồ_án_của_Thái.DTOs;
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
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var comic = _dbContext.Comics.ToList();
            
            var loginUser = User.Identity.GetUserId();
            ViewBag.LoginUser = loginUser;
            foreach (Comic i in comic)
            {
                Follow find = _dbContext.Follows.FirstOrDefault(f => f.FolloweeId == loginUser && f.ComicId == i.Id);
                if (find == null)
                {
                    i.isShowFollow = true;
                }
            }
            
            
            return View(comic);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}