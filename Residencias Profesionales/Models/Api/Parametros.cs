using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Residencias.Models.Api
{
    [Table("Parametros")]
    public class Parametros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nu_parametro { get; set; }

        public int nu_periodo { get; set; }

        public virtual Periodos periodo { get; set; }
    }
}