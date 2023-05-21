using FrontEnd.Helpers;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helper
{
    public class RolHelper
    {
        private ServiceRepository ServiceRepository;

        public RolHelper()
        {
            ServiceRepository = new ServiceRepository();
        }



        public List<RolViewModel> GetAll()
        {
            List<RolViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/rol/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<RolViewModel>>(content);



            return lista;
        }

        public RolViewModel Get(int id)
        {
            RolViewModel Rol;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/rol/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Rol = JsonConvert.DeserializeObject<RolViewModel>(content);



            return Rol;
        }


        public RolViewModel Create(RolViewModel rol)
        {


            RolViewModel Rol;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/rol/", rol);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Rol = JsonConvert.DeserializeObject<RolViewModel>(content);



            return Rol;
        }




        public RolViewModel Edit(RolViewModel rol)
        {


            RolViewModel Rol;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/rol/", rol);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Rol = JsonConvert.DeserializeObject<RolViewModel>(content);



            return Rol;
        }



        public RolViewModel Delete(int id)
        {


            RolViewModel Rol;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/rol/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Rol = JsonConvert.DeserializeObject<RolViewModel>(content);



            return Rol;
        }

    }




}

