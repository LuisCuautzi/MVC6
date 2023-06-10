using System;
using System.Collections.Generic;

namespace Gen06_23_MVCV2.Models
{
    public partial class Instructore
    {
        public Instructore()
        {
            CursoInstructorAuxiliars = new HashSet<Curso>();
            CursoInstructorTitulars = new HashSet<Curso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string UrlFoto { get; set; }
        public DateTime HoraClase { get; set; }
        public int CodigoIntructor { get; set; }
        public string Genero { get; set; }

        public virtual ICollection<Curso> CursoInstructorAuxiliars { get; set; }
        public virtual ICollection<Curso> CursoInstructorTitulars { get; set; }
    }
}
