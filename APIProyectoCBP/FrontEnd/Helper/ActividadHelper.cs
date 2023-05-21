using FrontEnd.Helpers;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helper
{
    public class ActividadHelper
    {
        private ServiceRepository ServiceRepository;


        public ActividadHelper()
        {
            ServiceRepository = new ServiceRepository();
        }

        public List<ActividadViewModel> GetAll()
        {
            List<ActividadViewModel> lista;

            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/actividad/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<ActividadViewModel>>(content);


            return lista;
        }


        public ActividadViewModel Get(int id)
        {
            ActividadViewModel Actividad;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/actividad/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Actividad = JsonConvert.DeserializeObject<ActividadViewModel>(content);



            return Actividad;
        }

        public ActividadViewModel Create(ActividadViewModel actividad)
        {


            ActividadViewModel Actividad;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/actividad/", actividad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Actividad = JsonConvert.DeserializeObject<ActividadViewModel>(content);



            return Actividad;
        }

        public ActividadViewModel Edit(ActividadViewModel actividad)
        {


            ActividadViewModel Actividad;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/actividad/", actividad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Actividad = JsonConvert.DeserializeObject<ActividadViewModel>(content);



            return Actividad;
        }

        public ActividadViewModel Delete(int id)
        {


            ActividadViewModel Actividad;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/actividad/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Actividad = JsonConvert.DeserializeObject<ActividadViewModel>(content);



            return Actividad;
        }

    }
}
