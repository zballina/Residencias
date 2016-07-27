using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Residencias.Models.Api
{
    [Table("AnteProyectosEntregables")]
    public class AnteProyectosEntregables
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nu_entregable { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string entregable { get; set; }

        [Display(Name = "Anteproyecto")]
        public int nu_anteproyecto { get; set; }

        public virtual AnteProyectos anteproyecto { get; set; }
    }
}
