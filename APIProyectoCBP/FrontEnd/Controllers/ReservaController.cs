using FrontEnd.Helper;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;


namespace FrontEnd.Controllers
{
    public class ReservaController : Controller
    {

        private ReservaHelper reservaHelper;


        public ReservaController()
        {
            reservaHelper = new ReservaHelper();
        }


        public ActionResult Index()
        {
            reservaHelper = new ReservaHelper();
            List<ReservaViewModel> lista = reservaHelper.GetAll();

            return View(lista);
        }

        public ActionResult Details(int id)
        {
            reservaHelper = new ReservaHelper();
            ReservaViewModel reserva = reservaHelper.Get(id);

            return View(reserva);
        }


        public ActionResult Create()
        {
            reservaHelper = new ReservaHelper();
            ReservaViewModel reserva = new ReservaViewModel();
            reserva.Reserva = reservaHelper.GetAll();


            return View(reserva);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservaViewModel reserva)
        {
            try
            {
                reservaHelper = new ReservaHelper();
                reserva = reservaHelper.Create(reserva);

                return RedirectToAction("Details", new { id = reserva.IdReserva });
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            reservaHelper = new ReservaHelper();
            ReservaViewModel reserva = reservaHelper.Get(id);

            return View(reserva);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservaViewModel reserva)
        {
            try
            {
                ReservaHelper reservaHelper = new ReservaHelper();
                reserva = reservaHelper.Edit(reserva);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: ReservaController/Delete/5
        public ActionResult Delete(int id)
        {
            reservaHelper = new ReservaHelper();
            ReservaViewModel reserva = reservaHelper.Get(id);

            return View(reserva);
        }

        // POST: ReservaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ReservaViewModel reserva)
        {
            try
            {
                reservaHelper = new ReservaHelper();
                reservaHelper.Delete(reserva.IdReserva);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
