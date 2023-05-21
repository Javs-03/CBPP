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
    public class ActividadController : ControllerBase
    {
        private readonly ILogger<ActividadController> logger;
        private IActividadDAL actividadDAL;

        private ActividadModel Convertir(Actividad entity)
        {
            return new ActividadModel
            {
                IdActividad = entity.IdActividad,
                DescActividad = entity.DescActividad,
                HorarioDisponible = entity.HorarioDisponible,
                CuposDisponible = entity.CuposDisponible


            };
        }

        private Actividad Convertir(ActividadModel model)
        {
            return new Actividad
            {
                IdActividad = model.IdActividad,
                DescActividad = model.DescActividad,
                HorarioDisponible = model.HorarioDisponible,
                CuposDisponible = model.CuposDisponible


            };
        }
        public ActividadController(ILogger<ActividadController> logger)
        {
            actividadDAL = new ActividadDALImpl(new Entities.DBProyectoContext());
            this.logger = logger;
        }

        // GET: api/<ActividadController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                logger.LogDebug("Ingreso a Get All Actividades");
                IEnumerable<Actividad> actividades = actividadDAL.GetAll();

                List<ActividadModel> lista = new List<ActividadModel>();

                foreach (var actividad in actividades)
                {
                    lista.Add(Convertir(actividad)

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

        // GET api/<ActividadController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Actividad actividad;
            actividad = actividadDAL.Get(id);

            return new JsonResult(Convertir(actividad));

        }

        // POST api/<ActividadController>
        [HttpPost]
        public JsonResult Post([FromBody] ActividadModel actividad)
        {

            Actividad entity = Convertir(actividad);
            actividadDAL.Add(entity);
            return new JsonResult(Convertir(entity));

        }

        // PUT api/<ActividadController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] ActividadModel actividad)
        {

            actividadDAL.Update(Convertir(actividad));
            return new JsonResult(Convertir(actividad));

        }

        // DELETE api/<ActividadController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Actividad actividad = new Actividad { IdActividad = id };
            actividadDAL.Remove(actividad);

            return new JsonResult(Convertir(actividad));

        }
    }
}
