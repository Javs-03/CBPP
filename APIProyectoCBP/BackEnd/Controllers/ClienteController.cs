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
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> logger;
        private IClienteDAL clienteDAL;

        private ClienteModel Convertir(Cliente entity)
        {
            return new ClienteModel
            {
                IdCliente = entity.IdCliente,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Direccion = entity.Direccion,
                NumTelefono = entity.NumTelefono,
                Email = entity.Email,
                Usuario = entity.Usuario 


            };
        }

        private Cliente Convertir(ClienteModel model)
        {
            return new Cliente
            {
                IdCliente = model.IdCliente,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Direccion = model.Direccion,
                NumTelefono = model.NumTelefono,
                Email = model.Email,
                Usuario = model.Usuario


            };
        }
        public ClienteController(ILogger<ClienteController> logger)
        {
            clienteDAL = new ClienteDALImpl(new Entities.DBProyectoContext());
            this.logger = logger;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                logger.LogDebug("Ingreso a Get All Clientes");
                IEnumerable<Cliente> clientes = clienteDAL.GetAll();

                List<ClienteModel> lista = new List<ClienteModel>();

                foreach (var cliente in clientes)
                {
                    lista.Add(Convertir(cliente)

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

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Cliente cliente;
            cliente = clienteDAL.Get(id);

            return new JsonResult(Convertir(cliente));

        }

        // POST api/<ClienteController>
        [HttpPost]
        public JsonResult Post([FromBody] ClienteModel cliente)
        {

            Cliente entity = Convertir(cliente);
            clienteDAL.Add(entity);
            return new JsonResult(Convertir(entity));

        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] ClienteModel cliente)
        {

            clienteDAL.Update(Convertir(cliente));
            return new JsonResult(Convertir(cliente));

        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Cliente cliente = new Cliente { IdCliente = id };
            clienteDAL.Remove(cliente);

            return new JsonResult(Convertir(cliente));

        }
    }
}
