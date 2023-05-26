using Microsoft.EntityFrameworkCore;


namespace FrontEnd.Models
{
    public class LoginDBContext : DbContext
    {
        public LoginDBContext(DbContextOptions<LoginDBContext> options)
        
                :base(options)
        
        { 
            
         

        }

        public  DbSet<UsuarioViewModel> UsuarioModel    { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) { 
        
            base.OnModelCreating(builder);
            builder.Entity<UsuarioViewModel>(entity => {
                entity.HasKey(k => k.IdUsuario);
                });
        }
    }
}   
