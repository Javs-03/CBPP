using FrontEnd.Helper;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class RolController : Controller
    { 

        private RolHelper rolHelper;


        public RolController()
        {
            rolHelper= new RolHelper();
        }
    
        // GET: RolController
        public ActionResult Index()
        {
            rolHelper = new RolHelper();
            List<RolViewModel> lista = rolHelper.GetAll();

            return View(lista);
        }

        // GET: RolController/Details/5
        public ActionResult Details(int id)
        {
            rolHelper = new RolHelper();
            RolViewModel rol = rolHelper.Get(id);

            return View(rol);
        }

        // GET: RolController/Create
        public ActionResult Create()
        {
            rolHelper = new RolHelper();
            RolViewModel rol = new RolViewModel();
            rol.Rol = rolHelper.GetAll();


            return View(rol);
        }

        // POST: RolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolViewModel rol)
        {
            try
            {
                rolHelper = new RolHelper();
                rol = rolHelper.Create(rol);

                return RedirectToAction("Details", new { id = rol.IdRol });
            }
            catch
            {
                return View();
            }
        }

        // GET: RolController/Edit/5
        public ActionResult Edit(int id)
        {
            rolHelper = new RolHelper();
            RolViewModel persona = rolHelper.Get(id);

            return View(persona);
        }

        // POST: RolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RolViewModel rol)
        {
            try
            {
                RolHelper personaHelper = new RolHelper();
                rol = personaHelper.Edit(rol);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolController/Delete/5
        public ActionResult Delete(int id)
        {
            rolHelper = new RolHelper();
            RolViewModel rol = rolHelper.Get(id);

            return View(rol);
        }

        // POST: RolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RolViewModel rol)
        {
            try
            {
                rolHelper = new RolHelper();
                rolHelper.Delete(rol.IdRol);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
