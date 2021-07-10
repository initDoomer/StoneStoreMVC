﻿using Microsoft.AspNetCore.Mvc;
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
            _db.Category.Add(obj);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}