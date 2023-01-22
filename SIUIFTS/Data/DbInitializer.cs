using SIUIFTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIUIFTS.Data
{
    public class DbInitializer
    {
        public static void Initialize(SIUIFTSContext contexto)
        {
            //metodo que se usa para crear automaticamente la base de datos
            contexto.Database.EnsureCreated();

            //busco estudiantes, si encuentro alguno salgo
            if (contexto.Alumnos.Any())
            {
                return;
            }
            //sino, cargo datos de prueba
            var alumnos = new Alumno[]
            {
            new Alumno{Nombre="Carlos",Apellido="Juarez",FechaDeInscripcion=DateTime.Parse("2020-03-01")},
            new Alumno{Nombre="Alejandro",Apellido="Acosta",FechaDeInscripcion=DateTime.Parse("2022-06-01")},
            new Alumno{Nombre="Romina",Apellido="Gomez",FechaDeInscripcion=DateTime.Parse("2021-03-01")},
            new Alumno{Nombre="Cristian",Apellido="Romero",FechaDeInscripcion=DateTime.Parse("2022-03-01")},
            new Alumno{Nombre="Luciana",Apellido="Salamanca",FechaDeInscripcion=DateTime.Parse("2022-06-01")},
            new Alumno{Nombre="Camila",Apellido="Gauna",FechaDeInscripcion=DateTime.Parse("2021-06-01")}
            };
            foreach (Alumno a in alumnos)
            {
                contexto.Alumnos.Add(a);
            }
            contexto.SaveChanges();

            var materias = new Materia[]
            {
            new Materia{MateriaID=1000,NombreMateria="PP1"},
            new Materia{MateriaID=1001,NombreMateria="Inglés"},
            new Materia{MateriaID=1002,NombreMateria="Diagramación Lógica"},
            new Materia{MateriaID=1003,NombreMateria="Estructura de Datos"},
            new Materia{MateriaID=1004,NombreMateria="Arquitectura de Computadoras"},
            new Materia{MateriaID=1005,NombreMateria="Base de Datos"},
            new Materia{MateriaID=1006,NombreMateria="Ingeniería de Software"}
            };
            foreach (Materia m in materias)
            {
                contexto.Materias.Add(m);
            }
            contexto.SaveChanges();

            var inscripciones = new Inscripcion[]
            {
            new Inscripcion{AlumnoID=1,MateriaID=1000,Nota=4},
            new Inscripcion{AlumnoID=1,MateriaID=1001,Nota=7},
            new Inscripcion{AlumnoID=1,MateriaID=1002,Nota=7},
            new Inscripcion{AlumnoID=2,MateriaID=1001,Nota=9},
            new Inscripcion{AlumnoID=2,MateriaID=1002,Nota=2},
            new Inscripcion{AlumnoID=2,MateriaID=1003,Nota=5},
            new Inscripcion{AlumnoID=3,MateriaID=1000},
            new Inscripcion{AlumnoID=4,MateriaID=1001},
            new Inscripcion{AlumnoID=4,MateriaID=1006,Nota=3},
            new Inscripcion{AlumnoID=5,MateriaID=1000,Nota=5},
            new Inscripcion{AlumnoID=6,MateriaID=1005},
            new Inscripcion{AlumnoID=7,MateriaID=1004,Nota=10},
            };
            foreach (Inscripcion i in inscripciones)
            {
                contexto.Inscripciones.Add(i);
            }
            contexto.SaveChanges();
        }
    }
}
