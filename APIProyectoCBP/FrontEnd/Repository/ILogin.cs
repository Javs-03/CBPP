using FrontEnd.Models;

namespace FrontEnd.Repository
{
    public interface ILogin
    {
        Task<IEnumerable<UsuarioViewModel>> getuser();
        Task<UsuarioViewModel> AuthenticateUser(string username, string password);
    }
}
