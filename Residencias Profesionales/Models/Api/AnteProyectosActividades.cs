using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Residencias.Models.Api
{
    [Table("AnteProyectosActividades")]
    public class AnteProyectosActividades
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nu_actividad { get; set; }

        [Required]
        [Display(Name = "Nombre de la Actividad")]
        public string actividad { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fe_inicio { get; set; }

        [Display(Name = "Fecha de Terminación")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fe_final { get; set; }

        [Display(Name = "Anteproyecto")]
        public int nu_anteproyecto { get; set; }

        public virtual AnteProyectos anteproyecto { get; set; }
    }
}