using FrontEnd.Helpers;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helper
{
    public class ClienteHelper
    {
        private ServiceRepository ServiceRepository;

        public ClienteHelper()
        {
            ServiceRepository = new ServiceRepository();
        }

        public List<ClienteViewModel> GetAll()
        {
            List<ClienteViewModel> list;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/cliente/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            list = JsonConvert.DeserializeObject<List<ClienteViewModel>>(content);


            return list;
        }

        public ClienteViewModel Get(int id)
        {
            ClienteViewModel Cliente;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/cliente/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Cliente = JsonConvert.DeserializeObject<ClienteViewModel>(content);



            return Cliente;
        }

        public ClienteViewModel Create(ClienteViewModel cliente)
        {


            ClienteViewModel Cliente;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/cliente/", cliente);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Cliente = JsonConvert.DeserializeObject<ClienteViewModel>(content);



            return Cliente;
        }

        public ClienteViewModel Edit(ClienteViewModel cliente)
        {


            ClienteViewModel Cliente;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/cliente/", cliente);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Cliente = JsonConvert.DeserializeObject<ClienteViewModel>(content);



            return Cliente;
        }

        public ClienteViewModel Delete(int id)
        {


            ClienteViewModel Cliente;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/cliente/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Cliente = JsonConvert.DeserializeObject<ClienteViewModel>(content);



            return Cliente;
        }
    }
}
