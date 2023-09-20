using Anaokulu.Data.Data;
using AnaokuluKatmanli.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AnaokuluKatmanli.Controllers
{
    public class DerslerController : Controller
    {
        private readonly ApplicationDbContext1 _db;

        public DerslerController(ApplicationDbContext1 db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var listele = _db.Dersler.ToList();
            return View(listele);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Dersler dersler)
        {
            _db.Add(dersler);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            var yenile = _db.Dersler.Find(id);
            return View(yenile);
        }
        [HttpPost]
        public IActionResult Edit(int id, Dersler dersler)
        {
            _db.Update(dersler);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var del = _db.Dersler.Find(id);
            return View(del);

        }

        [HttpPost, ActionName("Delete")]

        public IActionResult Sil(int id)
        {
            var del = _db.Dersler.Find(id);
            _db.Remove(del);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
