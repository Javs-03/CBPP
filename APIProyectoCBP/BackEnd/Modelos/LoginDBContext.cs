using Microsoft.EntityFrameworkCore;


namespace BackEnd.Modelos
{
    public class LoginDBContext : DbContext
    {
        public LoginDBContext(DbContextOptions<LoginDBContext> options)

                : base(options)

        {



        }

        public DbSet<UsuarioModel> UsuarioModel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<UsuarioModel>(entity =>
            {
                entity.HasKey(k => k.IdUsuario);
            });
        }
    }
}
