using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Practico01_G02L.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fechanacimiento { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        [Display(Name = "Grado")]
        public int Idgrado { get; set; }

        [Display(Name = "Sección")]
        public int IdSeccion { get; set; }


    }
}