using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIUIFTS.Models
{
    public class Materia
    {
        //permite especificar la clave principal para el curso en lugar de hacer que la base de datos la genere
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MateriaID { get; set; }
        public string NombreMateria { get; set; }
       // public int Credits { get; set; }

        //relación de uno a muchos
        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
