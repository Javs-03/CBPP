using FrontEnd.Helper;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CabinaController : Controller
    {
        private CabinaHelper cabinaHelper;

        public CabinaController()
        {
            cabinaHelper = new CabinaHelper();
        }
        public ActionResult Index()
        {
            cabinaHelper = new CabinaHelper();
            List<CabinaViewModel> lista = cabinaHelper.GetAll();

            return View(lista);
        }

        public ActionResult Details(int id)
        {
            cabinaHelper = new CabinaHelper();
            CabinaViewModel cabina = cabinaHelper.Get(id);

            return View(cabina);
        }

        public ActionResult Create()
        {
            cabinaHelper = new CabinaHelper();
            CabinaViewModel cabina = new CabinaViewModel();
            cabina.Cabina = cabinaHelper.GetAll();


            return View(cabina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CabinaViewModel cabina)
        {
            try
            {
                cabinaHelper = new CabinaHelper();
                cabina = cabinaHelper.Create(cabina);

                return RedirectToAction("Details", new { id = cabina.IdCabina });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            cabinaHelper = new CabinaHelper();
            CabinaViewModel cabin = cabinaHelper.Get(id);

            return View(cabin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CabinaViewModel cabina)
        {
            try
            {
                CabinaHelper cabinaHelper = new CabinaHelper();
                cabina = cabinaHelper.Edit(cabina);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            cabinaHelper = new CabinaHelper();
            CabinaViewModel cabina = cabinaHelper.Get(id);

            return View(cabina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CabinaViewModel cabina)
        {
            try
            {
                cabinaHelper = new CabinaHelper();
                cabinaHelper.Delete(cabina.IdCabina);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
