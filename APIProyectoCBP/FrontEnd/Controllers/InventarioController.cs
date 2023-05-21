using FrontEnd.Helper;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;


namespace FrontEnd.Controllers
{
    public class InventarioController : Controller
    {

        private InventarioHelper inventarioHelper;


        public InventarioController()
        {
            inventarioHelper = new InventarioHelper();
        }

        // GET: InventarioController
        public ActionResult Index()
        {
            inventarioHelper = new InventarioHelper();
            List<InventarioViewModel> lista = inventarioHelper.GetAll();

            return View(lista);
        }

        // GET: InventarioController/Details/5
        public ActionResult Details(int id)
        {
            inventarioHelper = new InventarioHelper();
            InventarioViewModel inventario = inventarioHelper.Get(id);

            return View(inventario);
        }

        // GET: InventarioController/Create
        public ActionResult Create()
        {
            inventarioHelper = new InventarioHelper();
            InventarioViewModel inventario = new InventarioViewModel();
            inventario.Producto = inventarioHelper.GetAll();


            return View(inventario);
        }

        // POST: InventarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventarioViewModel inventario)
        {
            try
            {
                inventarioHelper = new InventarioHelper();
                inventario = inventarioHelper.Create(inventario);

                return RedirectToAction("Details", new { id = inventario.IdProducto });
            }
            catch
            {
                return View();
            }
        }

        // GET: InventarioController/Edit/5
        public ActionResult Edit(int id)
        {
            inventarioHelper = new InventarioHelper();
            InventarioViewModel inventario = inventarioHelper.Get(id);

            return View(inventario);
        }

        // POST: InventarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InventarioViewModel inventario)
        {
            try
            {
                InventarioHelper inventarioHelper = new InventarioHelper();
                inventario = inventarioHelper.Edit(inventario);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventarioController/Delete/5
        public ActionResult Delete(int id)
        {
            inventarioHelper = new InventarioHelper();
            InventarioViewModel inventario = inventarioHelper.Get(id);

            return View(inventario);
        }

        // POST: InventarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(InventarioViewModel inventario)
        {
            try
            {
                inventarioHelper = new InventarioHelper();
                inventarioHelper.Delete(inventario.IdProducto);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
