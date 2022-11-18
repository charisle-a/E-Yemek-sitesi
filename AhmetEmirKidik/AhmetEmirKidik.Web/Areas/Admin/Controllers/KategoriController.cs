using AhmetEmirKidik.DatabaseAccessLayer;
using AhmetEmirKidik.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AhmetEmirKidik.Web.Areas.Admin.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Admin/Kategori
        public ActionResult List()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            using (UnitOfWork unitOf = new UnitOfWork())
            {
                return View(unitOf.kategWork.GetAll());
            }

        }
        public ActionResult Add()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(Kategori kul)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork unitOf = new UnitOfWork())
                {
                    unitOf.kategWork.Add(kul);
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
            if (id != null)
            {
                using (UnitOfWork unitOf = new UnitOfWork())
                {
                    Kategori kul = unitOf.kategWork.GetItem(id);
                    if (kul != null)
                        return View(kul);
                    else
                        return HttpNotFound();
                }
            }
            return RedirectToAction("List");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(int? id, Kategori kul)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork unitOf = new UnitOfWork())
                {
                    unitOf.kategWork.Update(kul);
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
                    Kategori kul = unitOf.kategWork.GetItem(id);
                    if (kul != null)
                        return View(kul);
                    else
                        return HttpNotFound();
                }
            }
            return RedirectToAction("List");
        }
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            if (id != null)
            {
                using (UnitOfWork unitOf = new UnitOfWork())
                {
                    Kategori kul = unitOf.kategWork.GetItem(id);
                    if (kul != null)
                    {
                        unitOf.kategWork.Remove(kul);
                        unitOf.Save();
                        return RedirectToAction("List");
                    }
                    else
                        return HttpNotFound();
                }
            }
            return RedirectToAction("List");
        }
        
    }
}