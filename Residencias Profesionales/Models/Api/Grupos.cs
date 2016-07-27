using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Residencias.Models.Api
{
    [Table("Grupos")]
    public class Grupos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nu_grupo { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Carrera")]
        public int nu_carrera { get; set; }
        public virtual Carreras carrera { get; set; }

        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        public ICollection<Inscripciones> inscripciones { get; set; }
    }
}
