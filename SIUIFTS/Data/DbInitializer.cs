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
            new Alumno{AlumnoID=3412342, Nombre="Carlos",Apellido="Juarez",FechaDeInscripcion=DateTime.Parse("2020-03-01")},
            new Alumno{AlumnoID=1456744,Nombre="Alejandro",Apellido="Acosta",FechaDeInscripcion=DateTime.Parse("2022-06-01")},
            new Alumno{AlumnoID=894534,Nombre="Romina",Apellido="Gomez",FechaDeInscripcion=DateTime.Parse("2021-03-01")},
            new Alumno{AlumnoID=4674,Nombre="Cristian",Apellido="Romero",FechaDeInscripcion=DateTime.Parse("2022-03-01")},
            new Alumno{AlumnoID=56784,Nombre="Luciana",Apellido="Salamanca",FechaDeInscripcion=DateTime.Parse("2022-06-01")},
            new Alumno{AlumnoID=1,Nombre="Camila",Apellido="Gauna",FechaDeInscripcion=DateTime.Parse("2021-06-01")}
            };
            foreach (Alumno a in alumnos)
            {
                contexto.Alumnos.Add(a);
            }
            contexto.SaveChanges();

            var materias = new Materia[]
            {
            new Materia{MateriaID=1000,NombreMateria="PP1",Turno="Mañana"},
            new Materia{MateriaID=1001,NombreMateria="Inglés",Turno="Tarde"},
            new Materia{MateriaID=1002,NombreMateria="Diagramación Lógica",Turno="Noche"},
            new Materia{MateriaID=1003,NombreMateria="Estructura de Datos",Turno="Noche"},
            new Materia{MateriaID=1004,NombreMateria="Arquitectura de Computadoras",Turno="Mañana"},
            new Materia{MateriaID=1005,NombreMateria="Base de Datos",Turno="Tarde"},
            new Materia{MateriaID=1006,NombreMateria="Ingeniería de Software",Turno="Tarde"}
            };
            foreach (Materia m in materias)
            {
                contexto.Materias.Add(m);
            }
            contexto.SaveChanges();

            var inscripciones = new Inscripcion[]
            {
            new Inscripcion{AlumnoID=3412342,MateriaID=1000,Nota=10},
            new Inscripcion{AlumnoID=1456744,MateriaID=1001,Nota=4},
            new Inscripcion{AlumnoID=1,MateriaID=1002},
            new Inscripcion{AlumnoID=894534,MateriaID=1001},
            };
            foreach (Inscripcion i in inscripciones)
            {
                contexto.Inscripciones.Add(i);
            }
            contexto.SaveChanges();

            var profesores = new Profesor[]
            {
                new Profesor{ProfesorID=1,Nombre="Carlos",Apellido="Juarez",FechaDeContratacion=DateTime.Parse("2020-03-01")},
                new Profesor{ProfesorID=2,Nombre="Leonardo",Apellido="Gutiérrez",FechaDeContratacion=DateTime.Parse("2021-12-01")},
                new Profesor{ProfesorID=3,Nombre="Daniela",Apellido="López",FechaDeContratacion=DateTime.Parse("2023-01-01")},
            };
            foreach (Profesor p in profesores)
            {
                contexto.Profesores.Add(p);
            }
            contexto.SaveChanges();
        }
    }
}
