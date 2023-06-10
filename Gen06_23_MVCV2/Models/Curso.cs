using System;
using System.Collections.Generic;

namespace Gen06_23_MVCV2.Models
{
    public partial class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double Duracion { get; set; }
        public string Ilustracion { get; set; }
        public int CategoriaId { get; set; }
        public int InstructorTitularId { get; set; }
        public int InstructorAuxiliarId { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Instructore InstructorAuxiliar { get; set; }
        public virtual Instructore InstructorTitular { get; set; }
    }
}
