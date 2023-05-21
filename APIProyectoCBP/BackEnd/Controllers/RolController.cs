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
    public class RolController : ControllerBase
    {
        private readonly ILogger<RolController> logger;
        private IRolDAL rolDAL;

        private RolModel Convertir(Rol entity)
        {
            return new RolModel
            {
                IdRol = entity.IdRol,
                DescRol = entity.DescRol


            };
        }

        private Rol Convertir(RolModel model)
        {
            return new Rol
            {
                IdRol = model.IdRol,
                DescRol = model.DescRol


            };
        }
        public RolController(ILogger<RolController> logger)
        {
            rolDAL = new RolDALImpl(new Entities.DBProyectoContext());
            this.logger = logger;
        }

        // GET: api/<RolController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                logger.LogDebug("Ingreso a Get All Roles");
                IEnumerable<Rol> roles = rolDAL.GetAll();

                List<RolModel> lista = new List<RolModel>();

                foreach (var rol in roles)
                {
                    lista.Add(Convertir(rol)

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

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Rol rol;
            rol = rolDAL.Get(id);

            return new JsonResult(Convertir(rol));

        }

        // POST api/<RolController>
        [HttpPost]
        public JsonResult Post([FromBody] RolModel rol)
        {

            Rol entity = Convertir(rol);
            rolDAL.Add(entity);
            return new JsonResult(Convertir(entity));

        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] RolModel rol)
        {

            rolDAL.Update(Convertir(rol));
            return new JsonResult(Convertir(rol));

        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Rol rol = new Rol { IdRol = id };
            rolDAL.Remove(rol);

            return new JsonResult(Convertir(rol));

        }
    }
}
