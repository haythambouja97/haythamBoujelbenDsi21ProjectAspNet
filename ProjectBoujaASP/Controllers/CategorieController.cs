using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectBoujaASP.Models;
using ProjectBoujaASP.Models.Repositories;

namespace ProjectBoujaASP.Controllers
{
    [Authorize(Roles = "admin,Manager")]

    public class CategorieController : Controller
    {
        readonly ICategorieRepository Categorierepository;
        public CategorieController(ICategorieRepository Categorierepository)
        {
            this.Categorierepository = Categorierepository;
        }
        // GET: CategorieController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(Categorierepository.GetAll());
        }

        // GET: CategorieController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.studentcount = Categorierepository.SmartPhoneCount(id);

            var Categorie = Categorierepository.GetById(id);
            return View(Categorie);
        }

        // GET: CategorieController/Create
        //[Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategorieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize]
        public ActionResult Create(Categorie s)
        {
            try
            {
                Categorierepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController/Edit/5
        public ActionResult Edit(int id)
        {
            var Categorie = Categorierepository.GetById(id);
            return View(Categorie);
        }

        // POST: CategorieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categorie s)
        {
            try
            {
                Categorierepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController/Delete/5
        public ActionResult Delete(int id)
        {
            var Categorie = Categorierepository.GetById(id);
            return View(Categorie);
        }

        // POST: CategorieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categorie s)
        {
            try
            {

                Categorierepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
