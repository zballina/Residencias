using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Residencias.Models.Api;

namespace Residencias.Models
{
    public class IdentityUserResidencias : IdentityUser {
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Telefono { get; set; }
    }

    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUserResidencias
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Carreras> carreras { get; set; }
        public DbSet<Grupos> grupos { get; set; }
        public DbSet<Periodos> periodos { get; set; }
        public DbSet<Proyectos> proyectos { get; set; }
        public DbSet<AnteProyectos> anteProyectos { get; set; }
        public DbSet<AnteProyectosEntregables> anteProyectosEntregables { get; set; }
        public DbSet<AnteProyectosActividades> anteProyectosActividades { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Residencias.Models.Api.Parametros> Parametros { get; set; }

        public System.Data.Entity.DbSet<Residencias.Models.Api.Inscripciones> Inscripciones { get; set; }
    }
}