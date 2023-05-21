using FrontEnd.Helpers;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrontEnd.Helper
{
	public class UsuarioHelper
	{
		private ServiceRepository ServiceRepository;

		public UsuarioHelper()
		{
			ServiceRepository = new ServiceRepository();
		}



		public List<UsuarioViewModel> GetAll()
		{
			List<UsuarioViewModel> list;


			HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/usuario/");
			var content = responseMessage.Content.ReadAsStringAsync().Result;
			list = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(content);


			return list;
		}

		public UsuarioViewModel Get(int id)
		{
			UsuarioViewModel Usuario;


			HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/usuario/" + id.ToString());
			var content = responseMessage.Content.ReadAsStringAsync().Result;
			Usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);



			return Usuario;
		}


		public UsuarioViewModel Create(UsuarioViewModel usuario)
		{


			UsuarioViewModel Usuario;


			HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/usuario/", usuario);
			var content = responseMessage.Content.ReadAsStringAsync().Result;
			Usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);



			return Usuario;
		}




		public UsuarioViewModel Edit(UsuarioViewModel usuario)
		{


			UsuarioViewModel Usuario;


			HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/usuario/", usuario);
			var content = responseMessage.Content.ReadAsStringAsync().Result;
			Usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);



			return Usuario;
		}



		public UsuarioViewModel Delete(int id)
		{


			UsuarioViewModel Usuario;


			HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/usuario/" + id.ToString());
			var content = responseMessage.Content.ReadAsStringAsync().Result;
			Usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);



			return Usuario;
		}

	}




}
