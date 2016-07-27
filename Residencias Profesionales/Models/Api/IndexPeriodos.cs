using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Residencias.Models.Api {
    public class IndexPeriodos {

        public int nu_periodo { get; set; }

        [Display(Name = "Nombre del Periodo")]
        public string nombre { get; set; }

        public IndexPeriodos(Periodos periodo) {
            nu_periodo = periodo.nu_periodo;

            if (periodo.fe_inicio.Year == periodo.fe_final.Year) {
                nombre = string.Format("{0} - {1} {2}",
                    CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(periodo.fe_inicio.Month),
                    CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(periodo.fe_final.Month),
                    periodo.fe_final.Year);
            } else {
                nombre = string.Format("{0} {1} - {2} {3}",
                    CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(periodo.fe_inicio.Month),
                    periodo.fe_inicio.Year,
                    CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(periodo.fe_final.Month),
                    periodo.fe_final.Year);
            }
        }
    }
}