using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Residencias.Models.Api {

    [Table("Inscripciones")]
    public class Inscripciones {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nu_inscripcion { get; set; }

        public int nu_grupo { get; set; }
        public virtual Grupos grupo { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}