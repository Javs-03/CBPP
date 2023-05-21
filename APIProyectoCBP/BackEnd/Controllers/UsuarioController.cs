using BackEnd.Modelos;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> logger;
        private IUsuarioDAL usuarioDAL;

        private UsuarioModel Convertir(Usuario entity)
        {
            return new UsuarioModel
            {
                IdUsuario = entity.IdUsuario,
                NombreUsuario = entity.NombreUsuario,
                Contrasena = entity.Contrasena,
                Rol = entity.Rol,
                Estado = entity.Estado


            };
        }

        private Usuario Convertir(UsuarioModel model)
        {
            return new Usuario
            {
                IdUsuario = model.IdUsuario,
                NombreUsuario = model.NombreUsuario,
                Contrasena = model.Contrasena,
                Rol = model.Rol,
                Estado = model.Estado


            };
        }

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            usuarioDAL = new UsuarioDALImpl(new Entities.DBProyectoContext());
            this.logger = logger;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
               logger.LogDebug("Ingreso a Get All Usuarios");
                IEnumerable<Usuario> usuarios = usuarioDAL.GetAll();

                List<UsuarioModel> lista = new List<UsuarioModel>();

                foreach (var usuario in usuarios)
                {
                    lista.Add(Convertir(usuario)

                        );
                }
                    return new JsonResult(lista);
                }
            catch (Exception e)
            {
                 logger.LogError("");
                 return new JsonResult(null);
            }

        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Usuario usuario;
            usuario = usuarioDAL.Get(id);

             return new JsonResult(Convertir(usuario));

        }

        // POST api/<UsuarioController>
        [HttpPost]
        public JsonResult Post([FromBody] UsuarioModel usuario)
        {

            Usuario entity = Convertir(usuario);
            usuarioDAL.Add(entity);
            return new JsonResult(Convertir(entity));

        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] UsuarioModel usuario)
        {

            usuarioDAL.Update(Convertir(usuario));
            return new JsonResult(Convertir(usuario));

        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Usuario usuario = new Usuario { IdUsuario = id };
            usuarioDAL.Remove(usuario);

            return new JsonResult(Convertir(usuario));

        }
    }
}
