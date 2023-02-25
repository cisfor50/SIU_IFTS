using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIUIFTS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIUIFTS.Data
{
    public class SIUIFTSContext : IdentityDbContext
    {
        public SIUIFTSContext(DbContextOptions<SIUIFTSContext> options)
            : base(options)
        {
        }
        //creo una propiedad DbSet para el conjunto de entidades
        //un conjunto de entidades se corresponde a una tabla de base de datos.
        //una entidad corresponde a una fila de la tabla
        //los nombres de las propiedades DbSet se usan para los nombres de las tablas
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materia>().ToTable("Materias");
            modelBuilder.Entity<Inscripcion>().ToTable("Inscripciones");
            modelBuilder.Entity<Alumno>().ToTable("Alumnos");
            modelBuilder.Entity<Profesor>().ToTable("Profesores");
            base.OnModelCreating(modelBuilder);
        }
    }
}
