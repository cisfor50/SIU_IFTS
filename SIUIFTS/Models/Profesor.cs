using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIUIFTS.Models
{
    public class Profesor
    {
        //permite especificar la clave principal para el profesor en lugar de hacer que la base de datos la genere
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfesorID { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeContratacion { get; set; }

       //un profesor puede dar varias materias
        public ICollection<Materia> Materias { get; set; }
    }
}
