using AhmetEmirKidik.DatabaseAccessLayer;
using AhmetEmirKidik.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AhmetEmirKidik.Web.Areas.Admin.Controllers
{
    public class UrunController : Controller
    {
        // GET: Admin/Urun
        
           
            public ActionResult List()
            {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            using (UnitOfWork unitOf = new UnitOfWork())
                {
                    return View(unitOf.UrunWork.GetAll());
                }

            }
            public ActionResult Add()
            {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            using (UnitOfWork unitOf=new UnitOfWork())
			{
                ViewBag.Kategoriler = new SelectList(unitOf.kategWork.GetAll(),"Id", "Ad");

            }
                return View();
            }
            [HttpPost, ValidateAntiForgeryToken]
            public ActionResult Add(Urun kul)
            {
                if (ModelState.IsValid)
                {
                    using (UnitOfWork unitOf = new UnitOfWork())
                    {
                        unitOf.UrunWork.Add(kul);
                        unitOf.Save();
                        return RedirectToAction("List");
                    }
                }
            using (UnitOfWork unitOf = new UnitOfWork())
            {
                ViewBag.Kategoriler = new SelectList(unitOf.kategWork.GetAll(),"Id","Ad");

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
                        Urun kul = unitOf.UrunWork.GetItem(id);
                        if (kul != null)
					{
                            ViewBag.Kategoriler = new SelectList(unitOf.kategWork.GetAll(),"Id","Ad");

                        return View(kul);
					}
                            
                        else
                            return HttpNotFound();
                    }
                }
                return RedirectToAction("List");
            }
            [HttpPost, ValidateAntiForgeryToken]
            public ActionResult Update(int? id, Urun kul)
            {
                if (ModelState.IsValid)
                {
                    using (UnitOfWork unitOf = new UnitOfWork())
                    {
                        unitOf.UrunWork.Update(kul);
                        unitOf.Save();
                        return RedirectToAction("List");
                    }
                }
            using (UnitOfWork unitOf = new UnitOfWork())
            {
                ViewBag.Kategoriler = new SelectList(unitOf.kategWork.GetAll(), "Id", "Ad");

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
                        Urun kul = unitOf.UrunWork.GetItem(id);
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
                        Urun kul = unitOf.UrunWork.GetItem(id);
                        if (kul != null)
                        {
                            unitOf.UrunWork.Remove(kul);
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
