using FrontEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FrontEnd.Repository;

namespace FrontEnd.Repository
{
    public class AuthenticateLogin : ILogin
    {
        private readonly LoginDBContext _dbContext;

        public AuthenticateLogin(LoginDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UsuarioViewModel> AuthenticateUser(string username, string password) 
        {
            var succeeded = await _dbContext.UsuarioModel.FirstOrDefaultAsync(authUser => authUser.NombreUsuario == username && authUser.Contrasena == password);
            return succeeded;
        }

        public async Task<IEnumerable<UsuarioViewModel>> getuser() 
        {
            return await _dbContext.UsuarioModel.ToListAsync();
        }
    }
}
