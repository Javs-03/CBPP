using FrontEnd.Helper;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ClienteController : Controller
    {

        private ClienteHelper clienteHelper;

        public ClienteController()
        {
            clienteHelper = new ClienteHelper();
        }

        public ActionResult Index()
        {
            clienteHelper = new ClienteHelper();
            List<ClienteViewModel> lista = clienteHelper.GetAll();

            return View(lista);
        }

        public ActionResult Details(int id)
        {
            clienteHelper = new ClienteHelper();
            ClienteViewModel cliente = clienteHelper.Get(id);

            return View(cliente);
        }

        public ActionResult Create()
        {
            clienteHelper = new ClienteHelper();
            ClienteViewModel cliente = new ClienteViewModel();
            cliente.Cliente = clienteHelper.GetAll();


            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            try
            {
                clienteHelper = new ClienteHelper();
                cliente = clienteHelper.Create(cliente);

                return RedirectToAction("Details", new { id = cliente.IdCliente });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            clienteHelper = new ClienteHelper();
            ClienteViewModel client = clienteHelper.Get(id);

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            try
            {
                ClienteHelper clientHelper = new ClienteHelper();
                cliente = clientHelper.Edit(cliente);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            clienteHelper = new ClienteHelper();
            ClienteViewModel usuario = clienteHelper.Get(id);

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClienteViewModel cliente)
        {
            try
            {
                clienteHelper = new ClienteHelper();
                clienteHelper.Delete(cliente.IdCliente);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
