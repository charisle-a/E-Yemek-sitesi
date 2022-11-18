using AhmetEmirKidik.DatabaseAccessLayer;
using AhmetEmirKidik.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AhmetEmirKidik.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult List()
        {
           /* if (Session["User"] == null)
            {
                return RedirectToAction("Login", "User");
            }*///login patlar diye kapatıldı
            using (UnitOfWork unitOf=new UnitOfWork())
			{
                
                return View(unitOf.kullaniciWork.GetAll());
            }
                
        }
        public ActionResult Add()
		{
           /* if (Session["User"] == null)
            {
                return RedirectToAction("Login", "User");
            }*/ //olurda login patlar diye kapatıldı
            return View();
		}
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Add(Kullanıcı kul)
		{
            if(ModelState.IsValid)
			{
                using (UnitOfWork unitOf=new UnitOfWork())
				{
                    unitOf.kullaniciWork.Add(kul);
                    unitOf.Save();
                    return RedirectToAction("List");
				}
			}
            ModelState.AddModelError("", "Ekleme Başarısız");
            return View(kul);
		}
        public ActionResult Update(int? id)
		{
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            if (id!=null)
			{
                using (UnitOfWork unitOf=new UnitOfWork())
				{
                    Kullanıcı kul=unitOf.kullaniciWork.GetItem(id);
                    if (kul != null)
                        return View(kul);
                    else
                        return HttpNotFound();
				}
			}
            return RedirectToAction("List");
		}
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(int? id, Kullanıcı kul)
		{
            if(ModelState.IsValid)
			{
                using (UnitOfWork unitOf =new UnitOfWork())
				{
                    unitOf.kullaniciWork.Update(kul);
                    unitOf.Save();
                    return RedirectToAction("List");
				}
			}
            ModelState.AddModelError("", "Düzenleme yapılamadı");
            return View(kul);
		}
        public ActionResult Delete(int? id)
		{
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            if (id != null)
            {
                using (UnitOfWork unitOf = new UnitOfWork())
                {
                    Kullanıcı kul = unitOf.kullaniciWork.GetItem(id);
                    if (kul != null)
                        return View(kul);
                    else
                        return HttpNotFound();
                }
            }
            return RedirectToAction("List");
        }
        [HttpPost, ValidateAntiForgeryToken,ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
           if(id!=null)
			{
                using (UnitOfWork unitOf = new UnitOfWork())
                {
                    Kullanıcı kul = unitOf.kullaniciWork.GetItem(id);
                    if (kul != null)
                    {
                        unitOf.kullaniciWork.Remove(kul);
                        unitOf.Save();
                        return RedirectToAction("List");
                    }
                    else
                        return HttpNotFound();
                }
            }
            return RedirectToAction("List");
        }
        public ActionResult MainMenu()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            using (UnitOfWork unitOf = new UnitOfWork())
            {
                ViewBag.Urun = unitOf.UrunWork.GetAll().Count();
                ViewBag.Kullanıcı = unitOf.kullaniciWork.GetAll().Count();
                ViewBag.Kategori = unitOf.kategWork.GetAll().Count();
            }
            return View();
        }
        public ActionResult Login()
        {
            if (Session["User"] == null)
                return View();
            else
                return RedirectToAction("MainMenu");
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login(Kullanıcı kul)
        {
            if(ModelState.IsValid)
			{
using (UnitOfWork unitOf=new UnitOfWork())
			{
                if(unitOf.kullaniciWork.Login(kul.EPosta,kul.Parola))
				{
                        
                       Kullanıcı user = unitOf.kullaniciWork.GetItem(kul.Id);
                        Session["User"] = User;
                        return RedirectToAction("MainMenu");
				}
			}
			}
            ModelState.AddModelError("","eposta veya şifre yanlış");
                return View(kul);
        }
        public ActionResult Logout()
		{
            Session["User"] = null;
            return RedirectToAction("Login");
		}

    }
}