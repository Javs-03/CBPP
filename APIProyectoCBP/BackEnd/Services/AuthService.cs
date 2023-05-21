using Microsoft.EntityFrameworkCore;
using Entities;

namespace BackEnd.Services
{
    public class AuthService
    {
        private readonly DBProyectoContext _dbContext;

        public AuthService()
        {
        }

        public AuthService(DBProyectoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Authenticate(string username, string password)
        {
            // Busca en la base de datos el usuario que tenga el nombre de usuario proporcionado:
            var user = _dbContext.Usuarios.SingleOrDefault(x => x.NombreUsuario == username);
        

            // Si el usuario no existe, devuelve false:
            if (user == null)
            {
                return false;
            }

            // Compara la contraseña proporcionada con la contraseña almacenada en la base de datos:

           /* if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }*/


            // Compara la contraseña proporcionada con la contraseña almacenada en la base de datos:
            if (user.Contrasena != password)
            {
                return false;
            }

            // Si la contraseña es correcta, devuelve true:
            return true;
        }

     /*   private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            // Verifica que la contraseña proporcionada coincida con la contraseña almacenada en la base de datos:
            using var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != storedHash[i]) return false;
            }
            return true;
        }*/
    }
}
