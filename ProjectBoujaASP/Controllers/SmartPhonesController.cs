using ProjectBoujaASP.Models;
using ProjectBoujaASP.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Identity_Test.Controllers
{
    [Authorize(Roles = "admin,Manager")]
    public class SmartPhonesController : Controller
    {
        readonly ICategorieRepository categorieRepository;
        readonly IsmartPhoneRepository smartphoneRepository;

        public SmartPhonesController(IsmartPhoneRepository smartphoneRepository, ICategorieRepository categorieRepository)
        {
            this.smartphoneRepository = smartphoneRepository;
            this.categorieRepository = categorieRepository;
        }
        // GET: SmartPhonesController
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.CategorieId = new SelectList(smartphoneRepository.GetAll(), "CategorieId", "CategorieName");
            return View(smartphoneRepository.GetAll());
        }

        public ActionResult Search(string name, int? categorieId)
        {
            var result = smartphoneRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = smartphoneRepository.FindByName(name);
            else
            if (categorieId != null)
                result = smartphoneRepository.GetSmartPhonesByCategorieID(categorieId);
            ViewBag.CategorieID = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName");
            return View("Index", result);
        }


        // GET: SmartPhonesController/Details/5
        public ActionResult Details(int id)
        {
            return View(smartphoneRepository.GetById(id));
        }

        // GET: SmartPhonesController/Create

        public ActionResult Create()
        {
            ViewBag.CategorieID = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName");
            return View();
        }

        // POST: SmartPhonesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(SmartPhone s)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName", s.CategorieId);
                smartphoneRepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SmartPhonesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategorieID = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName");
            return View(smartphoneRepository.GetById(id));
        }

        // POST: SmartPhonesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SmartPhone s)
        {
            try
            {
                ViewBag.CategorieID = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName", s.CategorieId);
                smartphoneRepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SmartPhonesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(smartphoneRepository.GetById(id));
        }

        // POST: SmartPhonesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SmartPhone s)
        {
            try
            {
                smartphoneRepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
