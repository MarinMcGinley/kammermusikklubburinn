using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Composers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Composers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcertSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertSeasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pieces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComposerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pieces_Composers_ComposerId",
                        column: x => x.ComposerId,
                        principalTable: "Composers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcertSeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concerts_ConcertSeasons_ConcertSeasonId",
                        column: x => x.ConcertSeasonId,
                        principalTable: "ConcertSeasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PieceInConcert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PieceId = table.Column<int>(type: "int", nullable: false),
                    ConcertId = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceInConcert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PieceInConcert_Concerts_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PieceInConcert_Pieces_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Pieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformerInGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformerId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false),
                    PieceInConcertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformerInGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformerInGroup_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformerInGroup_Performers_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Performers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformerInGroup_PieceInConcert_PieceInConcertId",
                        column: x => x.PieceInConcertId,
                        principalTable: "PieceInConcert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_ConcertSeasonId",
                table: "Concerts",
                column: "ConcertSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformerInGroup_InstrumentId",
                table: "PerformerInGroup",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformerInGroup_PerformerId",
                table: "PerformerInGroup",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformerInGroup_PieceInConcertId",
                table: "PerformerInGroup",
                column: "PieceInConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_PieceInConcert_ConcertId",
                table: "PieceInConcert",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_PieceInConcert_PieceId",
                table: "PieceInConcert",
                column: "PieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_ComposerId",
                table: "Pieces",
                column: "ComposerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerformerInGroup");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Performers");

            migrationBuilder.DropTable(
                name: "PieceInConcert");

            migrationBuilder.DropTable(
                name: "Concerts");

            migrationBuilder.DropTable(
                name: "Pieces");

            migrationBuilder.DropTable(
                name: "ConcertSeasons");

            migrationBuilder.DropTable(
                name: "Composers");
        }
    }
}
