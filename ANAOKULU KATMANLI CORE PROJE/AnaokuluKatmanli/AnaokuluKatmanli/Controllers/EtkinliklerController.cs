using Anaokulu.Data.Data;
using AnaokuluKatmanli.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AnaokuluKatmanli.Controllers
{
    public class EtkinliklerController : Controller
    {
        private readonly ApplicationDbContext1 _db;

        public EtkinliklerController(ApplicationDbContext1 db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var listele = _db.Etkinlikler.ToList();
            return View(listele);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Etkinlikler etkinlikler)
        {
            _db.Add(etkinlikler);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            var yenile = _db.Etkinlikler.Find(id);
            return View(yenile);
        }
        [HttpPost]
        public IActionResult Edit(int id, Etkinlikler etkinlikler)
        {
            _db.Update(etkinlikler);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var del = _db.Etkinlikler.Find(id);
            return View(del);

        }

        [HttpPost, ActionName("Delete")]

        public IActionResult Sil(int id)
        {
            var del = _db.Etkinlikler.Find(id);
            _db.Remove(del);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
