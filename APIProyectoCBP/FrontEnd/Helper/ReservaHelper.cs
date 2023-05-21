using FrontEnd.Helpers;
using FrontEnd.Models;
using Newtonsoft.Json;


namespace FrontEnd.Helper
{
    public class ReservaHelper
    {
        private ServiceRepository ServiceRepository;

        public ReservaHelper()
        {
            ServiceRepository = new ServiceRepository();
        }

        public List<ReservaViewModel> GetAll()
        {
            List<ReservaViewModel> list;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/reserva/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            list = JsonConvert.DeserializeObject<List<ReservaViewModel>>(content);


            return list;
        }

        public ReservaViewModel Get(int id)
        {
            ReservaViewModel Reserva;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/reserva/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Reserva = JsonConvert.DeserializeObject<ReservaViewModel>(content);


            return Reserva;
        }

        public ReservaViewModel Create(ReservaViewModel reserva)
        {


            ReservaViewModel Reserva;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/reserva/", reserva);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Reserva = JsonConvert.DeserializeObject<ReservaViewModel>(content);



            return Reserva;
        }

        public ReservaViewModel Edit(ReservaViewModel reserva)
        {


            ReservaViewModel Reserva;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/reserva/", reserva);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Reserva = JsonConvert.DeserializeObject<ReservaViewModel>(content);



            return Reserva;
        }

        public ReservaViewModel Delete(int id)
        {


            ReservaViewModel Reserva;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/reserva/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Reserva = JsonConvert.DeserializeObject<ReservaViewModel>(content);



            return Reserva;
        }
    }
}
