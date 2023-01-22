using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIUIFTS.Models
{
    //public enum Nota
    //{
    //    Desaprobado = 0,
    //    Aprobado = 1,
    //    Regularizo = 2,
    //    Ausente = 3
    //}

    public class Inscripcion
    {
        public int InscripcionID { get; set; }
        public int MateriaID { get; set; }
        public int AlumnoID { get; set; }
        //Nulleable porque puede que no se le haya asignado ninguna materia
        public int? Nota { get; set; }
        public Materia Materia { get; set; }
        public Alumno Alumno { get; set; }
    }
}
