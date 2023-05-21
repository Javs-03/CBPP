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
    public class ReservaController : ControllerBase
    {
        private readonly ILogger<ReservaController> logger;
        private IReservaDAL reservaDAL;

        private ReservaModel Convertir(Reserva entity)
        {
            return new ReservaModel
            {
                IdReserva = entity.IdReserva,
                CantDias = entity.CantDias,
                CantidadPersonas = entity.CantidadPersonas,
                PrecioTotal = entity.PrecioTotal,
                Cliente = entity.Cliente,
                Cabina = entity.Cabina,
                Actividad = entity.Actividad

            };
        }

        private Reserva Convertir(ReservaModel model)
        {
            return new Reserva
            {
                IdReserva = model.IdReserva,
                CantDias = model.CantDias,
                CantidadPersonas = model.CantidadPersonas,
                PrecioTotal = model.PrecioTotal,
                Cliente = model.Cliente,
                Cabina = model.Cabina,
                Actividad = model.Actividad


            };
        }
        public ReservaController(ILogger<ReservaController> logger)
        {
            reservaDAL = new ReservaDALImpl(new Entities.DBProyectoContext());
            this.logger = logger;
        }

        // GET: api/<ReservaController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                logger.LogDebug("Ingreso a Get All Reservas");
                IEnumerable<Reserva> reservas = reservaDAL.GetAll();

                List<ReservaModel> lista = new List<ReservaModel>();

                foreach (var reserva in reservas)
                {
                    lista.Add(Convertir(reserva)

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

        // GET api/<ReservaController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Reserva reserva;
            reserva = reservaDAL.Get(id);

            return new JsonResult(Convertir(reserva));

        }

        // POST api/<ReservaController>
        [HttpPost]
        public JsonResult Post([FromBody] ReservaModel reserva)
        {

            Reserva entity = Convertir(reserva);
            reservaDAL.Add(entity);
            return new JsonResult(Convertir(entity));

        }

        // PUT api/<ReservaController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] ReservaModel reserva)
        {

            reservaDAL.Update(Convertir(reserva));
            return new JsonResult(Convertir(reserva));

        }

        // DELETE api/<ReservaController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Reserva reserva = new Reserva { IdReserva = id };
            reservaDAL.Remove(reserva);

            return new JsonResult(Convertir(reserva));

        }
    }
}
