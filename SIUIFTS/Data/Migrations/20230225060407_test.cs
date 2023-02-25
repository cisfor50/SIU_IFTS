using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIUIFTS.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    AlumnoID = table.Column<int>(type: "int", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaDeInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.AlumnoID);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    MateriaID = table.Column<int>(type: "int", nullable: false),
                    NombreMateria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.MateriaID);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    ProfesorID = table.Column<int>(type: "int", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaDeContratacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.ProfesorID);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    InscripcionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MateriaID = table.Column<int>(type: "int", nullable: false),
                    AlumnoID = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.InscripcionID);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Alumnos_AlumnoID",
                        column: x => x.AlumnoID,
                        principalTable: "Alumnos",
                        principalColumn: "AlumnoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Materias_MateriaID",
                        column: x => x.MateriaID,
                        principalTable: "Materias",
                        principalColumn: "MateriaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriaProfesor",
                columns: table => new
                {
                    MateriasMateriaID = table.Column<int>(type: "int", nullable: false),
                    ProfesoresProfesorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaProfesor", x => new { x.MateriasMateriaID, x.ProfesoresProfesorID });
                    table.ForeignKey(
                        name: "FK_MateriaProfesor_Materias_MateriasMateriaID",
                        column: x => x.MateriasMateriaID,
                        principalTable: "Materias",
                        principalColumn: "MateriaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriaProfesor_Profesores_ProfesoresProfesorID",
                        column: x => x.ProfesoresProfesorID,
                        principalTable: "Profesores",
                        principalColumn: "ProfesorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_AlumnoID",
                table: "Inscripciones",
                column: "AlumnoID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_MateriaID",
                table: "Inscripciones",
                column: "MateriaID");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaProfesor_ProfesoresProfesorID",
                table: "MateriaProfesor",
                column: "ProfesoresProfesorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "MateriaProfesor");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
