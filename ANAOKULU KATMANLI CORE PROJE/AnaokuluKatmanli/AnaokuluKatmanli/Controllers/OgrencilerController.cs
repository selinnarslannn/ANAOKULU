using Anaokulu.Data.Data;
using AnaokuluKatmanli.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AnaokuluKatmanli.Controllers
{
    public class OgrencilerController : Controller
    {
        private readonly ApplicationDbContext1 _db;

        public OgrencilerController(ApplicationDbContext1 db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var listele = _db.Ogrenciler.ToList();
            return View(listele);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ogrenciler ogrenciler)
        {
            _db.Add(ogrenciler);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            var yenile = _db.Ogrenciler.Find(id);
            return View(yenile);
        }
        [HttpPost]
        public IActionResult Edit(int id, Ogrenciler ogrenciler)
        {
            _db.Update(ogrenciler);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var del = _db.Ogrenciler.Find(id);
            return View(del);

        }

        [HttpPost, ActionName("Delete")]

        public IActionResult Sil(int id)
        {
            var del = _db.Ogrenciler.Find(id);
            _db.Remove(del);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
