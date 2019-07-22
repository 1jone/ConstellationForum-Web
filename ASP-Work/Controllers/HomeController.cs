using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Work.Models;

namespace ASP_Work.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            
            
            if (Request.IsAjaxRequest())
            {
                return PartialView(db.W_Articles.ToList());
            }
            return View(db.W_Articles.ToList());
        }

        public ActionResult Destroy()
        {

            Session.Abandon();
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public ActionResult Detial(int articleid)
        {
            W_Articles articles = db.W_Articles.Find(articleid);
            articles.Hits += 1;
            db.SaveChanges();
            W_Articles articles_new = db.W_Articles.Find(articleid);
            return View(articles_new);
        }

        [AllowAnonymous]
        public PartialViewResult LoadComment(int id)
        {
            ViewBag.Id = id;
            List<W_ArticleComments> articlecomments = db.W_ArticleComments.Where(m => m.ArticleId == id).ToList();
            return PartialView(articlecomments);
        }
        [HttpPost]
        [AllowAnonymous]
        public PartialViewResult LoadComment(string frontViewData, int Id)
        {
            W_Articles articles = db.W_Articles.Find(Id);
            articles.CommentCount += 1;
            db.SaveChanges();
            ViewBag.Id = Id;
            W_ArticleComments New_ArticleComments = new W_ArticleComments();
            New_ArticleComments.Content = frontViewData;
            New_ArticleComments.ArticleId = Id;
            New_ArticleComments.User = Session["name"].ToString();
            New_ArticleComments.CreateTime = DateTime.Now;
            New_ArticleComments.Ticks = DateTime.Now.Ticks;
            if (New_ArticleComments.Content != "")
            {
                db.W_ArticleComments.Add(New_ArticleComments);
                db.SaveChanges();
            }
            List<W_ArticleComments> articlecomments = db.W_ArticleComments.Where(m => m.ArticleId == Id).OrderByDescending(m => m.CreateTime).ToList();
            return PartialView(articlecomments);
        }

        public ActionResult Login(string id)
        {
            ViewBag.ts = id;

            return View();

        }

        [HttpPost]
        public ActionResult Login(string PhoneNumber, string Pass)
        {

            foreach (var item in db.W_Users.ToList())
            {
                if (item.PhoneNumber.Equals(PhoneNumber) && item.Password.Equals(Pass.ToMd5()))
                {
                    Session["name"] = item.NickName;
                    Session["flag"] = item.flag;
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
            }
            return RedirectToRoute(new { controller = "Home", action = "Login"});

        }

        public ActionResult Register(string PhoneNumber, string Pass, string NickName)
        {
            if (Request.HttpMethod == "GET")
            {
                return View();

            }
            else
            {
                if (ModelState.IsValid)
                {
                    W_Users user = new W_Users();
                    user.NickName = NickName;
                    user.Password = Pass.ToMd5();
                    user.PhoneNumber = PhoneNumber;
                    user.flag = "0";
                    db.W_Users.Add(user);
                    try
                    {
                        db.SaveChanges();
                        return RedirectToAction("Login");

                    }
                    catch (Exception)
                    {
                        return RedirectToAction("Register");
                    }
                }

            }
            return View();
        }

        public ActionResult Category(int id)
        {
            string category = "";
            switch (id)
            {
                case 1:
                    category = "星座";
                    break;
                case 2:
                    category = "生肖";
                    break;
                case 3:
                    category = "爱情";
                    break;
                case 4:
                    category = "时尚";
                    break;
                case 5:
                    category = "知识";
                    break;
            }
            ViewBag.Title = category;
            List<W_Articles> categorycomments = db.W_Articles.Where(m => m.ArticleCategory == category).ToList();
            return View(categorycomments);
        }




        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Add()
        {
            if (Session["name"] == null)
            {
                return RedirectToRoute(new { controller = "Home", action = "Login" });
            }
            else
            {
                return View();
            } 
        }

        [HttpPost]
        public ActionResult Add(string Title, string Url, string Content)
        {
            int flag = 0;
            string New_Content_0 = Content.Replace("\n", "");
            string New_Content_1 = Content.Replace("\n\n", "</p><p>");
            string New_Content_2 = New_Content_1.Replace("\n", "");
            string brief = "";
            if (New_Content_0.Length >= 200)
            {
                brief = New_Content_0.Substring(0, 200) + "...";
            }
            if (New_Content_0.Length < 200)
            {
                brief = New_Content_0 + "...";
            }
            string New_Content = "<p class=\"MsoNormal\"><span lang = \"EN-US\" ><img src=\"" + "http://img.xingzuoxingyu.com/x33621.jpg" + "\" alt=\"x40440.jpg\"><br></span></p><p>" + New_Content_2 + "</p>";
            W_Articles articles = new W_Articles();
            articles.ImgUrl = "http://img.xingzuoxingyu.com/x33621.jpg";
            articles.Label = "12星座,天蝎座,情感";
            articles.ArticleCategory = "知识";
            articles.Brief = brief;
            articles.Title = Title;
            articles.TUserName = Session["name"].ToString();
            articles.Content = New_Content;
            articles.AddTime = DateTime.Now;
            articles.Hits = 1;
            articles.CommentCount = 1;

            foreach (var item in db.W_Articles.ToList())
            {
                if (item.Title.Equals(Title))
                {
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                db.W_Articles.Add(articles);
                db.SaveChanges();
            }
            return RedirectToRoute(new { controller = "Home", action = "Index"});
        }

    }
}