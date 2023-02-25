using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIUIFTS.Models
{
    public class Alumno
    {
        //AlumnoID es la PK de la tabla de base de datos que se corresponde a esta clase.
        //dni //permite especificar la clave principal para el curso en lugar de hacer que la base de datos la genere
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlumnoID { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeInscripcion { get; set; }

        //Propiedad de navegación que contiene referencias a muchas entidades relacionadas.
        //Cuando se usa ICollection<T>, EF crea una colección HashSet<T> de forma predeterminada.
        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
