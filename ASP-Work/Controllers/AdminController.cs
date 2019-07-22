using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Work.Models;
using System.Net;

namespace ASP_Work.Controllers
{
    public class AdminController : Controller
    {
        private Model1 db = new Model1();
        // GET: Admin

        public ActionResult Index()
        {
            if (Session["flag"] != null)
            {
                if (Session["flag"].ToString() == "1")
                {
                    return View(db.W_Articles.ToList());

                }

            }

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public ActionResult Delete(Int32 articleid)
        {
            if (articleid == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            W_Articles my_Articles = db.W_Articles.Find(articleid);
            if (my_Articles == null)
            {
                return HttpNotFound();
            }
            return View(my_Articles);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 articleid)
        {
            if (Session["flag"] != null)
            {

                if (Session["flag"].ToString() == "1")
                {
                    W_Articles my_Articles = db.W_Articles.Find(articleid);
                    db.W_Articles.Remove(my_Articles);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }


    }
}