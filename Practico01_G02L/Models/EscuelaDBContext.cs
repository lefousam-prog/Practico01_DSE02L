using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Practico01_G02L.Models
{
    public class EscuelaDBContext: DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Nota> Notas { get; set; }

    }
}