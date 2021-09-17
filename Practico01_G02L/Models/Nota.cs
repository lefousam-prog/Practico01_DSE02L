using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Practico01_G02L.Models
{
    public class Nota
    {
        [Key]
        public int Idnota { get; set; }
        public int IdAlumno { get; set; }
        public int IdMateria { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal Periodo { get; set; }

    }
}