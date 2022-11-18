using AhmetEmirKidik.DatabaseAccessLayer;
using AhmetEmirKidik.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AhmetEmirKidik.Web.Controllers
{
	public class HomeController : Controller
	{
        // GET: Home
        public ActionResult Index()
        {
            
            using (UnitOfWork unitOf = new UnitOfWork())
            {
                return View(unitOf.UrunWork.GetAll());
            }

        }
        public ActionResult About()
		{
            return View();
		}
        public ActionResult ShowCard(int? id)
		{
            if (id != null)
            {
                using (UnitOfWork unitOf = new UnitOfWork())
                {
                    Urun kul = unitOf.UrunWork.GetItem(id);
                    if (kul != null)
                    {
                        
                        
                        return View(kul);
                    }

                    else
                        return HttpNotFound();
                }
            }
            return RedirectToAction("Index");
        }
    }

    
}