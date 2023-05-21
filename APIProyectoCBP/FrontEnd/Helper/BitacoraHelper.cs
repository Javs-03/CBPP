using FrontEnd.Helpers;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helper
{
    public class BitacoraHelper
    {
        private ServiceRepository ServiceRepository;

        public BitacoraHelper()
        {
            ServiceRepository = new ServiceRepository();
        }

        public List<BitacoraViewModel> GetAll()
        {
            List<BitacoraViewModel> lista;

            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/bitacora/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<BitacoraViewModel>>(content);


            return lista;
        }


        public BitacoraViewModel Get(int id)
        {
            BitacoraViewModel Bitacora;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/bitacora/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Bitacora = JsonConvert.DeserializeObject<BitacoraViewModel>(content);



            return Bitacora;
        }

        public BitacoraViewModel Create(BitacoraViewModel bitacora)
        {


            BitacoraViewModel Bitacora;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/bitacora/", bitacora);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Bitacora = JsonConvert.DeserializeObject<BitacoraViewModel>(content);



            return Bitacora;
        }

        public BitacoraViewModel Edit(BitacoraViewModel bitacora)
        {


            BitacoraViewModel Bitacora;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/bitacora/", bitacora);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Bitacora = JsonConvert.DeserializeObject<BitacoraViewModel>(content);



            return Bitacora;
        }

        public BitacoraViewModel Delete(int id)
        {


            BitacoraViewModel Bitacora;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/bitacora/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Bitacora = JsonConvert.DeserializeObject<BitacoraViewModel>(content);



            return Bitacora;
        }


    }
}
