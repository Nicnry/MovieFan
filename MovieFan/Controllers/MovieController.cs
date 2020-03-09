using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieFan.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieFan.Controllers
{
    public class MovieController : Controller
    {
        private readonly moviefanContext db;

        public MovieController(moviefanContext db)
        {
            this.db = db;
        }
        // GET: Movie
        public ActionResult Index()
        {
            List<Movies> movies = db.Movies.Include(m => m.Category).ToList();
            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            Movies movie = db.Movies.Find(id);
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            Movies movie = db.Movies
                .Include(m => m.Category)
                .Include(m => m.Rating)
                .Include(m => m.UserLikeMovie).ThenInclude(m => m.User)
                .SingleOrDefault(x => x.Id == id);

            List <Categories> categories = db.Categories.ToList();
            ViewBag.CategoryId = db.Categories.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() }).ToList();
            ViewBag.RatingId = db.Ratings.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() }).ToList();
            TempData["name"] = "Test data";
            return View(movie);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<Movies> Edit(int id, Movies movie)
        {
            try
            {
                // TODO: Add update logic here
                db.Update(movie);
                db.SaveChanges();
                TempData["Saved"] = movie.Title;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}