using Microsoft.EntityFrameworkCore.Migrations;

namespace VetRegister.Data.Migrations
{
    public partial class PersonProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcedureId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false),
                    IsDoctor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_PersonId",
                table: "Exams",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ProcedureId",
                table: "Exams",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_PersonId",
                table: "Animals",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonId",
                table: "Persons",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Persons_PersonId",
                table: "Animals",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Persons_PersonId",
                table: "Exams",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Procedures_ProcedureId",
                table: "Exams",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Persons_PersonId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Persons_PersonId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Procedures_ProcedureId",
                table: "Exams");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Exams_PersonId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ProcedureId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Animals_PersonId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ProcedureId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Animals");
        }
    }
}
