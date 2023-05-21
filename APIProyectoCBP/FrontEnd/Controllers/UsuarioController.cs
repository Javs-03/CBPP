using FrontEnd.Helper;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;


namespace FrontEnd.Controllers


{ 
    public class UsuarioController : Controller
    {
        private UsuarioHelper usuarioHelper;

        public UsuarioController()
        {
            usuarioHelper = new UsuarioHelper();
        }


        public ActionResult Index()
        {
            usuarioHelper = new UsuarioHelper();
            List<UsuarioViewModel> lista = usuarioHelper.GetAll();

           return View(lista);
        }

        public ActionResult Details(int id)
        {
           usuarioHelper = new UsuarioHelper();
           UsuarioViewModel usuario = usuarioHelper.Get(id);

            return View(usuario);
        }


        public ActionResult Create()
        {
            usuarioHelper = new UsuarioHelper();
            UsuarioViewModel usuario = new UsuarioViewModel();
            usuario.Usuario = usuarioHelper.GetAll();


            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                usuarioHelper = new UsuarioHelper();
                usuario = usuarioHelper.Create(usuario);

               return RedirectToAction("Details", new { id = usuario.IdUsuario});
            }
            catch
            {
               return View();
            }
        }

        public ActionResult Edit(int id)
        {
            usuarioHelper = new UsuarioHelper();
            UsuarioViewModel user = usuarioHelper.Get(id);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
           try
           {
                UsuarioHelper userHelper = new UsuarioHelper();
                usuario = userHelper.Edit(usuario);


                return RedirectToAction(nameof(Index));
           }
            catch
            {
               return View();
           }
        }

        public ActionResult Delete(int id)
        {
           usuarioHelper = new UsuarioHelper();
           UsuarioViewModel usuario = usuarioHelper.Get(id);

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioViewModel usuario)
        {
            try
            {
                usuarioHelper = new UsuarioHelper();
                usuarioHelper.Delete(usuario.IdUsuario);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

}
