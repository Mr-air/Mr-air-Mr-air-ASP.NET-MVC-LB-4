using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Shoes_Store3.Models;

namespace Shoes_Store3.Controllers
{
    public class HomeController : Controller
    {
        ShoesContext db = new ShoesContext();

        public ActionResult Index()
        {
            var shoes = db.Shoes.Include(b=>b.Firma);
            return View(shoes.ToList()); 
        }

        public ActionResult FirstShoes()
        {
            var firstShoes = db.Shoes.FirstOrDefault();
            return View(firstShoes);
        }

        public ActionResult PageView(int page=1)
        {
            var shoes = db.Shoes.Include(b => b.Firma).ToList();
            int pageSize = 5;
            IEnumerable<Shoes> shoesOnPage = shoes.Skip((page - 1) * pageSize).Take(pageSize);
            PagePag pagePag = new PagePag { PageNumber = page, PageSize = pageSize, TotalShoes = shoes.Count };
            ViewShoes viewShoes = new ViewShoes { Shoess = shoesOnPage, PagePag=pagePag};
            return View(viewShoes); 
        }

        public ActionResult FilterView(int? firma)
        {
            IQueryable<Shoes> shoes = db.Shoes.Include(a => a.Firma);
            if (firma != null && firma != 0)
            {
                shoes = shoes.Where(a => a.FirmaId == firma);
            }
            List<Firmas> firmas = db.Firmas.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            firmas.Insert(0, new Firmas { Firma_name = "Все", Id = 0 });
            ShoesFilterList sfl = new ShoesFilterList
            {
                Shoes = shoes.ToList(),
                Firma = new SelectList(firmas, "Id", "Firma_name")
            };
            return View(sfl);
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            SelectList firma = new SelectList(db.Firmas, "Id", "Firma_name");
            ViewBag.Firma = firma;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Shoes shoes)
        {
            
            db.Shoes.Add(shoes);
            db.SaveChanges();
     
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            Shoes shoes = db.Shoes.Find(id);
            if (shoes != null)
            {

                SelectList firma = new SelectList(db.Firmas, "Id", "Firma_name",
                shoes.FirmaId);
                ViewBag.Firma = firma;
                return View(shoes);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Shoes shoes)
        {
            db.Entry(shoes).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var shoes = db.Shoes.Include(c => c.Firma).Where(a => a.Id == id).First();
            ViewBag.Firma = shoes;
            if (shoes != null)
            {
                return View(shoes);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
 
            Shoes shoes = db.Shoes.Find(id);
            if (shoes != null)
            {
                db.Shoes.Remove(shoes);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
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