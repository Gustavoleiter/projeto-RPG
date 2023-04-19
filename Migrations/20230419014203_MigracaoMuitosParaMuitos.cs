using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemHabilidades",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemHabilidades", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" },
                    { 4, 2537, "Olhar da penitencia" },
                    { 5, 3799, "Exorcizar" }
                });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 116, 130, 218, 11, 41, 230, 150, 248, 30, 212, 236, 234, 147, 196, 222, 236, 129, 37, 78, 3, 103, 80, 216, 189, 168, 185, 169, 254, 5, 228, 247, 9, 189, 201, 90, 29, 241, 211, 82, 118, 44, 38, 92, 133, 187, 130, 133, 165, 176, 193, 1, 106, 74, 73, 101, 247, 122, 106, 238, 52, 184, 102, 26, 252 }, new byte[] { 194, 130, 28, 162, 31, 102, 220, 92, 159, 191, 69, 152, 196, 46, 26, 208, 174, 231, 252, 38, 66, 72, 144, 4, 37, 114, 32, 205, 156, 204, 101, 87, 236, 81, 152, 30, 153, 249, 144, 50, 83, 230, 131, 116, 88, 151, 112, 36, 66, 167, 131, 12, 240, 88, 125, 173, 117, 118, 111, 4, 52, 173, 139, 235, 75, 13, 195, 107, 66, 148, 14, 253, 18, 48, 81, 68, 154, 2, 157, 61, 155, 65, 73, 4, 6, 254, 162, 245, 14, 28, 138, 29, 106, 141, 205, 74, 138, 66, 245, 162, 5, 112, 120, 253, 219, 45, 235, 238, 48, 38, 128, 110, 76, 141, 149, 212, 8, 228, 208, 207, 208, 227, 65, 134, 213, 129, 204, 31 } });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidades",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 4, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemHabilidades_HabilidadeId",
                table: "PersonagemHabilidades",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonagemHabilidades");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "Personagens");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 79, 12, 1, 179, 55, 218, 214, 152, 71, 31, 175, 11, 54, 20, 105, 204, 189, 246, 32, 5, 52, 52, 77, 223, 141, 96, 33, 94, 217, 155, 225, 234, 131, 205, 112, 39, 217, 12, 21, 80, 106, 22, 136, 55, 233, 184, 11, 250, 250, 237, 173, 39, 201, 35, 163, 20, 58, 231, 9, 109, 189, 70, 99, 201 }, new byte[] { 198, 227, 177, 91, 118, 10, 3, 175, 200, 3, 138, 149, 136, 147, 11, 50, 136, 237, 53, 197, 105, 177, 78, 231, 177, 79, 83, 54, 17, 89, 6, 201, 96, 133, 154, 226, 97, 177, 184, 112, 154, 106, 18, 106, 248, 190, 28, 161, 239, 74, 236, 224, 3, 188, 36, 116, 122, 159, 140, 82, 73, 45, 135, 40, 43, 178, 136, 153, 159, 101, 213, 100, 9, 55, 192, 209, 12, 242, 141, 139, 158, 126, 185, 220, 232, 234, 192, 228, 146, 63, 75, 2, 224, 62, 199, 208, 8, 54, 86, 186, 80, 46, 31, 0, 178, 246, 126, 153, 146, 66, 237, 211, 185, 210, 153, 127, 68, 123, 137, 115, 105, 2, 178, 215, 114, 8, 40, 191 } });
        }
    }
}
