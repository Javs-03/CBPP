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
    public class InventarioController : ControllerBase
    {
        private readonly ILogger<InventarioController> logger;
        private IInventarioDAL inventarioDAL;

        private InventarioModel Convertir(Inventario entity)
        {
            return new InventarioModel
            {
                IdProducto = entity.IdProducto,
                DescProducto = entity.DescProducto,
                CantidadDisponible = entity.CantidadDisponible


            };
        }

        private Inventario Convertir(InventarioModel model)
        {
            return new Inventario
            {
                IdProducto = model.IdProducto,
                DescProducto = model.DescProducto,
                CantidadDisponible = model.CantidadDisponible


            };
        }

        public InventarioController(ILogger<InventarioController> logger)
        {
            inventarioDAL = new InventarioDALImpl(new Entities.DBProyectoContext());
            this.logger = logger;
        }

        // GET: api/<InventarioController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                logger.LogDebug("Ingreso a Get All Inventario");
                IEnumerable<Inventario> inventarios = inventarioDAL.GetAll();

                List<InventarioModel> lista = new List<InventarioModel>();

                foreach (var inventario in inventarios)
                {
                    lista.Add(Convertir(inventario)

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

        // GET api/<InventarioController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Inventario inventario;
            inventario = inventarioDAL.Get(id);

            return new JsonResult(Convertir(inventario));

        }

        // POST api/<InventarioController>
        [HttpPost]
        public JsonResult Post([FromBody] InventarioModel inventario)
        {

            Inventario entity = Convertir(inventario);
            inventarioDAL.Add(entity);
            return new JsonResult(Convertir(entity));

        }

        // PUT api/<InventarioController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] InventarioModel inventario)
        {

            inventarioDAL.Update(Convertir(inventario));
            return new JsonResult(Convertir(inventario));

        }

        // DELETE api/<InventarioController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Inventario inventario = new Inventario { IdProducto = id };
            inventarioDAL.Remove(inventario);

            return new JsonResult(Convertir(inventario));

        }
    }
}
