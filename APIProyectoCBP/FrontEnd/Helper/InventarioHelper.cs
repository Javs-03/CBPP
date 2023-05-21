using FrontEnd.Helpers;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helper
{
    public class InventarioHelper
    {
        private ServiceRepository ServiceRepository;

        public InventarioHelper()
        {
            ServiceRepository = new ServiceRepository();
        }

        public List<InventarioViewModel> GetAll()
        {
            List<InventarioViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/inventario/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<InventarioViewModel>>(content);



            return lista;
        }

        public InventarioViewModel Get(int id)
        {
            InventarioViewModel Inventario;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/inventario/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Inventario = JsonConvert.DeserializeObject<InventarioViewModel>(content);



            return Inventario;
        }

        public InventarioViewModel Create(InventarioViewModel inventario)
        {


            InventarioViewModel Inventario;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/inventario/", inventario);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Inventario = JsonConvert.DeserializeObject<InventarioViewModel>(content);



            return Inventario;
        }

        public InventarioViewModel Edit(InventarioViewModel inventario)
        {


            InventarioViewModel Inventario;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/innventario/", inventario);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Inventario = JsonConvert.DeserializeObject<InventarioViewModel>(content);



            return Inventario;
        }

        public InventarioViewModel Delete(int id)
        {


            InventarioViewModel Inventario;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/inventario/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Inventario = JsonConvert.DeserializeObject<InventarioViewModel>(content);



            return Inventario;
        }
    }
}
