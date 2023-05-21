using FrontEnd.Helper;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class BitacoraController : Controller
    {
        private BitacoraHelper bitacoraHelper;



        public BitacoraController()
        {
            bitacoraHelper = new BitacoraHelper();
        }


        // GET: BitacoraController
        public ActionResult Index()
        {
            bitacoraHelper = new BitacoraHelper();
            List<BitacoraViewModel> lista = bitacoraHelper.GetAll();

            return View(lista);
        }

        // GET: BitacoraController/Details/5
        public ActionResult Details(int id)
        {
            bitacoraHelper = new BitacoraHelper();
            BitacoraViewModel Bitacora = bitacoraHelper.Get(id);

            return View(Bitacora);
        }

        // GET: BitacoraController/Create
        public ActionResult Create()
        {
            bitacoraHelper = new BitacoraHelper();
            BitacoraViewModel Bitacora = new BitacoraViewModel();
            Bitacora.Bitacora = bitacoraHelper.GetAll();


            return View(Bitacora);
        }

        // POST: BitacoraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BitacoraViewModel bitacora)
        {
            try
            {
                bitacoraHelper = new BitacoraHelper();
                bitacora = bitacoraHelper.Create(bitacora);

                return RedirectToAction("Details", new { id = bitacora.Bitacora });
            }
            catch
            {
                return View();
            }
        }

        // GET: BitacoraController/Edit/5
        public ActionResult Edit(int id)
        {
            bitacoraHelper = new BitacoraHelper();
            BitacoraViewModel persona = bitacoraHelper.Get(id);

            return View(persona);
        }

        // POST: BitacoraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BitacoraViewModel bitacora)
        {
            try
            {
                BitacoraHelper bitacoraHelper = new BitacoraHelper();
                bitacora = bitacoraHelper.Edit(bitacora);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BitacoraController/Delete/5
        public ActionResult Delete(int id)
        {
            bitacoraHelper = new BitacoraHelper();
            BitacoraViewModel bitacora = bitacoraHelper.Get(id);

            return View(bitacora);
        }

        // POST: BitacoraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(BitacoraViewModel bitacora)
        {
            try
            {
                bitacoraHelper = new BitacoraHelper();
                bitacoraHelper.Delete(bitacora.IdUsuario);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }

}