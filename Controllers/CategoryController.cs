using Microsoft.AspNetCore.Mvc;
using StoneStoreMVC.Data;
using StoneStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneStoreMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }


        // GET: Create
        public IActionResult Create()
        {
            return View();
        }


        // Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // GET: Edit
        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);

            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        // Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // GET: Delete
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //Post: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Category tempObj)
        {
            var id = tempObj.Id;
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
