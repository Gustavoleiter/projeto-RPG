using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "Armas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 6,
                column: "Nome",
                value: "Gustaf");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 79, 12, 1, 179, 55, 218, 214, 152, 71, 31, 175, 11, 54, 20, 105, 204, 189, 246, 32, 5, 52, 52, 77, 223, 141, 96, 33, 94, 217, 155, 225, 234, 131, 205, 112, 39, 217, 12, 21, 80, 106, 22, 136, 55, 233, 184, 11, 250, 250, 237, 173, 39, 201, 35, 163, 20, 58, 231, 9, 109, 189, 70, 99, 201 }, new byte[] { 198, 227, 177, 91, 118, 10, 3, 175, 200, 3, 138, 149, 136, 147, 11, 50, 136, 237, 53, 197, 105, 177, 78, 231, 177, 79, 83, 54, 17, 89, 6, 201, 96, 133, 154, 226, 97, 177, 184, 112, 154, 106, 18, 106, 248, 190, 28, 161, 239, 74, 236, 224, 3, 188, 36, 116, 122, 159, 140, 82, 73, 45, 135, 40, 43, 178, 136, 153, 159, 101, 213, 100, 9, 55, 192, 209, 12, 242, 141, 139, 158, 126, 185, 220, 232, 234, 192, 228, 146, 63, 75, 2, 224, 62, 199, 208, 8, 54, 86, 186, 80, 46, 31, 0, 178, 246, 126, 153, 146, 66, 237, 211, 185, 210, 153, 127, 68, 123, 137, 115, 105, 2, 178, 215, 114, 8, 40, 191 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas");

            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "Armas");

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 6,
                column: "Nome",
                value: "Celeborn");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 231, 53, 190, 80, 242, 168, 176, 11, 104, 175, 33, 236, 32, 186, 30, 126, 16, 170, 31, 215, 231, 32, 178, 108, 32, 117, 202, 178, 149, 8, 133, 19, 219, 15, 133, 15, 176, 1, 117, 159, 113, 234, 45, 163, 206, 240, 42, 222, 145, 103, 73, 61, 99, 35, 229, 208, 102, 1, 154, 251, 57, 195, 50, 192 }, new byte[] { 55, 167, 87, 160, 176, 153, 65, 122, 252, 38, 70, 169, 186, 38, 71, 47, 132, 100, 92, 194, 50, 158, 197, 143, 239, 90, 35, 137, 137, 142, 98, 197, 19, 164, 248, 170, 144, 87, 212, 2, 181, 68, 170, 218, 96, 41, 22, 239, 4, 210, 163, 111, 72, 23, 53, 116, 173, 120, 32, 114, 39, 153, 91, 184, 249, 69, 179, 87, 82, 20, 213, 220, 115, 114, 137, 4, 27, 211, 96, 52, 219, 241, 80, 176, 190, 174, 190, 15, 56, 33, 246, 54, 92, 62, 175, 206, 99, 49, 219, 210, 247, 184, 237, 219, 61, 116, 229, 175, 62, 230, 189, 209, 132, 159, 172, 131, 221, 224, 136, 253, 175, 92, 232, 45, 148, 226, 217, 90 } });
        }
    }
}
