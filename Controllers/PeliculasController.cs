using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq; // Agrega esto para usar LINQ
using System.Collections;

namespace WebApplication1.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeliculasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PeliculasController
        public ActionResult Index()
        {
            IEnumerable<Peliculas> ListaPeliculas = _context.Peliculas;
            return View(ListaPeliculas);
        }

        // GET: PeliculasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PeliculasController/Create
        public ActionResult Create()
        {
            return View();
        }
        public IActionResult Graficas()
        {
            List<Peliculas> listMovies =
                (from movies in _context.Peliculas
                 group movies by movies.Titulo into grupal
                 orderby grupal.Max(Peliculas => Peliculas.stars) descending
                 select new Peliculas
                 {
                     Titulo = grupal.Key,
                     stars = grupal.Max(p => p.stars),
                 }
                 ).Take(6).ToList();


            return StatusCode(StatusCodes.Status200OK, listMovies);

            //return View();
        }

        // POST: PeliculasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Peliculas peliculas)
        {
            if (ModelState.IsValid)
            {
                _context.Peliculas.Add(peliculas);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: PeliculasController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Obtener la película que queremos editar
            var pelicula = _context.Peliculas.Find(id);
            if (pelicula == null)
            {
                return NotFound("Hubo un error");
            }
            return View(pelicula);
        }

        // POST: PeliculasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Peliculas peliculas)
        {
            if (ModelState.IsValid)
            {
                _context.Peliculas.Update(peliculas);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: PeliculasController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Obtener la película que queremos eliminar
            var pelicula = _context.Peliculas.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }

        // POST: PeliculasController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Obtener la película que queremos eliminar
            var pelicula = _context.Peliculas.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            _context.Peliculas.Remove(pelicula);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: PeliculasController/Chart
       
    }
}
