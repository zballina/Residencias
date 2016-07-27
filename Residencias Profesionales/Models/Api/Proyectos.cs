using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Residencias.Models.Api
{
    [Table("Proyectos")]
    public class Proyectos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nu_anteproyecto { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        [Display(Name = "Objetivo")]
        public string objetivo { get; set; }

        [Required]
        [Display(Name = "Opción Elegida")]
        public short opcion_elegida { get; set; }

        [Required]
        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fe_inicio { get; set; }

        [Required]
        [Display(Name = "Fecha de finalización")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fe_final { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        [Required]
        [Display(Name = "Equipo necesario para realizar el proyecto")]
        public string equipo { get; set; }

        [Required(ErrorMessage = "El costo del proyecto es requerido")]
        [Display(Name = "Costo del proyecto")]
        [DataType(DataType.Currency)]
        public double costo { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre_empresa { get; set; }

        [Required]
        [Display(Name = "Domicilio")]
        public string domicilio_empresa { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string telefono_empresa { get; set; }

        [Required]
        [Display(Name = "Reponsable de Área y/o Encargado")]
        public string responsable_empresa { get; set; }

        [Required]
        [Display(Name = "Correo electrónico")]
        [DataType(DataType.EmailAddress)]
        public string email_empresa { get; set; }

        [Required]
        [Display(Name = "Nombre del Asesor/a Externo/a")]
        public string asesor_empresa { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }
    }
}
