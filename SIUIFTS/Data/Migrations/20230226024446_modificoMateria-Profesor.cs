using Microsoft.EntityFrameworkCore.Migrations;

namespace SIUIFTS.Data.Migrations
{
    public partial class modificoMateriaProfesor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaProfesor");

            migrationBuilder.AddColumn<string>(
                name: "Profesor",
                table: "Materias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfesorID",
                table: "Materias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materias_ProfesorID",
                table: "Materias",
                column: "ProfesorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Profesores_ProfesorID",
                table: "Materias",
                column: "ProfesorID",
                principalTable: "Profesores",
                principalColumn: "ProfesorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Profesores_ProfesorID",
                table: "Materias");

            migrationBuilder.DropIndex(
                name: "IX_Materias_ProfesorID",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "Profesor",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "ProfesorID",
                table: "Materias");

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
                name: "IX_MateriaProfesor_ProfesoresProfesorID",
                table: "MateriaProfesor",
                column: "ProfesoresProfesorID");
        }
    }
}
