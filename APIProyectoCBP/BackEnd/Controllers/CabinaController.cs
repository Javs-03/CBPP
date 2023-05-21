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
    public class CabinaController : ControllerBase
    {
        private readonly ILogger<CabinaController> logger;
        private ICabinaDAL cabinaDAL;

        private CabinaModel Convertir(Cabina entity)
        {
            return new CabinaModel
            {
                IdCabina = entity.IdCabina,
                DescCabina = entity.DescCabina,
                CamasDisponibles = entity.CamasDisponibles,
                CantidadPersonas = entity.CantidadPersonas,
                PrecioNoche = entity.PrecioNoche,
                Disponible = entity.Disponible


            };
        }

        private Cabina Convertir(CabinaModel model)
        {
            return new Cabina
            {
                IdCabina = model.IdCabina,
                DescCabina = model.DescCabina,
                CamasDisponibles = model.CamasDisponibles,
                CantidadPersonas = model.CantidadPersonas,
                PrecioNoche = model.PrecioNoche,
                Disponible = model.Disponible


            };
        }
        public CabinaController(ILogger<CabinaController> logger)
        {
            cabinaDAL = new CabinaDALImpl(new Entities.DBProyectoContext());
            this.logger = logger;
        }

        // GET: api/<CabinaController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                logger.LogDebug("Ingreso a Get All Cabinas");
                IEnumerable<Cabina> cabinas = cabinaDAL.GetAll();

                List<CabinaModel> lista = new List<CabinaModel>();

                foreach (var cabina in cabinas)
                {
                    lista.Add(Convertir(cabina)

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

        // GET api/<CabinaController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Cabina cabina;
            cabina = cabinaDAL.Get(id);

            return new JsonResult(Convertir(cabina));

        }

        // POST api/<CabinaController>
        [HttpPost]
        public JsonResult Post([FromBody] CabinaModel cabina)
        {

            Cabina entity = Convertir(cabina);
            cabinaDAL.Add(entity);
            return new JsonResult(Convertir(entity));

        }

        // PUT api/<CabinaController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] CabinaModel cabina)
        {

            cabinaDAL.Update(Convertir(cabina));
            return new JsonResult(Convertir(cabina));

        }

        // DELETE api/<CabinaController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Cabina cabina = new Cabina { IdCabina = id };
            cabinaDAL.Remove(cabina);

            return new JsonResult(Convertir(cabina));

        }
    }
}
