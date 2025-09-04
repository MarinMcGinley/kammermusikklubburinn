using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GroupAsTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformerInGroup_Group_GroupId",
                table: "PerformerInGroup");

            migrationBuilder.DropTable(
                name: "GroupInConcert");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Concert");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "PerformerInGroup",
                newName: "PieceInConcertId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformerInGroup_GroupId",
                table: "PerformerInGroup",
                newName: "IX_PerformerInGroup_PieceInConcertId");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "PieceInConcert",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformerInGroup_PieceInConcert_PieceInConcertId",
                table: "PerformerInGroup",
                column: "PieceInConcertId",
                principalTable: "PieceInConcert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformerInGroup_PieceInConcert_PieceInConcertId",
                table: "PerformerInGroup");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "PieceInConcert");

            migrationBuilder.RenameColumn(
                name: "PieceInConcertId",
                table: "PerformerInGroup",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformerInGroup_PieceInConcertId",
                table: "PerformerInGroup",
                newName: "IX_PerformerInGroup_GroupId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Concert",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupInConcert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcertId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupInConcert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupInConcert_Concert_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupInConcert_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupInConcert_ConcertId",
                table: "GroupInConcert",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupInConcert_GroupId",
                table: "GroupInConcert",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformerInGroup_Group_GroupId",
                table: "PerformerInGroup",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
