using Anaokulu.Data.Data;
using AnaokuluKatmanli.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AnaokuluKatmanli.Controllers
{
    public class OgretmenlerController : Controller
    {
        private readonly ApplicationDbContext1 _db;

        public OgretmenlerController(ApplicationDbContext1 db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var listele = _db.Ogretmenler.ToList();
            return View(listele);
           
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ogretmenler ogretmenler)
        {
            _db.Add(ogretmenler);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            var yenile = _db.Ogretmenler.Find(id);
            return View(yenile);
        }
        [HttpPost]
        public IActionResult Edit(int id, Ogretmenler ogretmenler)
        {
            _db.Update(ogretmenler);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var del = _db.Ogretmenler.Find(id);
            return View(del);

        }

        [HttpPost, ActionName("Delete")]

        public IActionResult Sil(int id)
        {
            var del = _db.Ogretmenler.Find(id);
            _db.Remove(del);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
