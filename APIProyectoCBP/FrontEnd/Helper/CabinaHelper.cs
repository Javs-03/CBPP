using FrontEnd.Helpers;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helper
{
    public class CabinaHelper
    {
        private ServiceRepository ServiceRepository;

        public CabinaHelper()
        {
            ServiceRepository = new ServiceRepository();
        }

        public List<CabinaViewModel> GetAll()
        {
            List<CabinaViewModel> list;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/cabina/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            list = JsonConvert.DeserializeObject<List<CabinaViewModel>>(content);


            return list;
        }

        public CabinaViewModel Get(int id)
        {
            CabinaViewModel Cabina;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/cabina/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Cabina = JsonConvert.DeserializeObject<CabinaViewModel>(content);


            return Cabina;
        }

        public CabinaViewModel Create(CabinaViewModel cabina)
        {


            CabinaViewModel Cabina;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/cabina/", cabina);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Cabina = JsonConvert.DeserializeObject<CabinaViewModel>(content);



            return cabina;
        }

        public CabinaViewModel Edit(CabinaViewModel cabina)
        {


            CabinaViewModel Cabina;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/cabina/", cabina);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Cabina = JsonConvert.DeserializeObject<CabinaViewModel>(content);



            return Cabina;
        }

        public CabinaViewModel Delete(int id)
        {


            CabinaViewModel Cabina;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/cabina/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Cabina = JsonConvert.DeserializeObject<CabinaViewModel>(content);



            return Cabina;
        }
    }
}
