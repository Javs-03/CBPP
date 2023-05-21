using FrontEnd.Helper;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ActividadController : Controller
    {
        private ActividadHelper actividadHelper;


        public ActividadController()
        {
            actividadHelper = new ActividadHelper();
        }

        // GET: ActividadController
        public ActionResult Index()
        {
            actividadHelper = new ActividadHelper();
            List<ActividadViewModel> lista = actividadHelper.GetAll();

            return View(lista);
        }

        // GET: ActividadController/Details/5
        public ActionResult Details(int id)
        {
            actividadHelper = new ActividadHelper();
            ActividadViewModel Actividad = actividadHelper.Get(id);

            return View(Actividad);
        }

        // GET: ActividadController/Create
        public ActionResult Create()
        {
            actividadHelper = new ActividadHelper();
            ActividadViewModel Actividad = new ActividadViewModel();
            Actividad.Actividad = actividadHelper.GetAll();


            return View(Actividad);
        }

        // POST: ActividadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActividadViewModel actividad)
        {
            try
            {
                actividadHelper = new ActividadHelper();
                actividad = actividadHelper.Create(actividad);

                return RedirectToAction("Details", new { id = actividad.IdActividad });
            }
            catch
            {
                return View();
            }
        }

        // GET: ActividadController/Edit/5
        public ActionResult Edit(int id)
        {
            actividadHelper = new ActividadHelper();
            ActividadViewModel actividad = actividadHelper.Get(id);

            return View(actividad);
        }

        // POST: ActividadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ActividadViewModel actividad)
        {
            try
            {
                ActividadHelper actividadHelper = new ActividadHelper();
                actividad = actividadHelper.Edit(actividad);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ActividadController/Delete/5
        public ActionResult Delete(int id)
        {
            actividadHelper = new ActividadHelper();
            ActividadViewModel actividad = actividadHelper.Get(id);

            return View(actividad);
        }

        // POST: ActividadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ActividadViewModel actividad)
        {
            try
            {
                actividadHelper = new ActividadHelper();
                actividadHelper.Delete(actividad.IdActividad);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

