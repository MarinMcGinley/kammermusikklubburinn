using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OneMoreMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformerInGroup_Instrument_InstrumentId",
                table: "PerformerInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformerInGroup_Performer_PerformerId",
                table: "PerformerInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformerInGroup_PieceInConcert_PieceInConcertId",
                table: "PerformerInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Piece_Composer_ComposerId",
                table: "Piece");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceInConcert_Concerts_ConcertId",
                table: "PieceInConcert");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceInConcert_Piece_PieceId",
                table: "PieceInConcert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PieceInConcert",
                table: "PieceInConcert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Piece",
                table: "Piece");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerformerInGroup",
                table: "PerformerInGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Performer",
                table: "Performer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instrument",
                table: "Instrument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Composer",
                table: "Composer");

            migrationBuilder.RenameTable(
                name: "PieceInConcert",
                newName: "PiecesInConcert");

            migrationBuilder.RenameTable(
                name: "Piece",
                newName: "Pieces");

            migrationBuilder.RenameTable(
                name: "PerformerInGroup",
                newName: "PerformersInGroup");

            migrationBuilder.RenameTable(
                name: "Performer",
                newName: "Performers");

            migrationBuilder.RenameTable(
                name: "Instrument",
                newName: "Instruments");

            migrationBuilder.RenameTable(
                name: "Composer",
                newName: "Composers");

            migrationBuilder.RenameIndex(
                name: "IX_PieceInConcert_PieceId",
                table: "PiecesInConcert",
                newName: "IX_PiecesInConcert_PieceId");

            migrationBuilder.RenameIndex(
                name: "IX_PieceInConcert_ConcertId",
                table: "PiecesInConcert",
                newName: "IX_PiecesInConcert_ConcertId");

            migrationBuilder.RenameIndex(
                name: "IX_Piece_ComposerId",
                table: "Pieces",
                newName: "IX_Pieces_ComposerId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformerInGroup_PieceInConcertId",
                table: "PerformersInGroup",
                newName: "IX_PerformersInGroup_PieceInConcertId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformerInGroup_PerformerId",
                table: "PerformersInGroup",
                newName: "IX_PerformersInGroup_PerformerId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformerInGroup_InstrumentId",
                table: "PerformersInGroup",
                newName: "IX_PerformersInGroup_InstrumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PiecesInConcert",
                table: "PiecesInConcert",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pieces",
                table: "Pieces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerformersInGroup",
                table: "PerformersInGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Performers",
                table: "Performers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instruments",
                table: "Instruments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Composers",
                table: "Composers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformersInGroup_Instruments_InstrumentId",
                table: "PerformersInGroup",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformersInGroup_Performers_PerformerId",
                table: "PerformersInGroup",
                column: "PerformerId",
                principalTable: "Performers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformersInGroup_PiecesInConcert_PieceInConcertId",
                table: "PerformersInGroup",
                column: "PieceInConcertId",
                principalTable: "PiecesInConcert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Composers_ComposerId",
                table: "Pieces",
                column: "ComposerId",
                principalTable: "Composers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PiecesInConcert_Concerts_ConcertId",
                table: "PiecesInConcert",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PiecesInConcert_Pieces_PieceId",
                table: "PiecesInConcert",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformersInGroup_Instruments_InstrumentId",
                table: "PerformersInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformersInGroup_Performers_PerformerId",
                table: "PerformersInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformersInGroup_PiecesInConcert_PieceInConcertId",
                table: "PerformersInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Composers_ComposerId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_PiecesInConcert_Concerts_ConcertId",
                table: "PiecesInConcert");

            migrationBuilder.DropForeignKey(
                name: "FK_PiecesInConcert_Pieces_PieceId",
                table: "PiecesInConcert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PiecesInConcert",
                table: "PiecesInConcert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pieces",
                table: "Pieces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerformersInGroup",
                table: "PerformersInGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Performers",
                table: "Performers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instruments",
                table: "Instruments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Composers",
                table: "Composers");

            migrationBuilder.RenameTable(
                name: "PiecesInConcert",
                newName: "PieceInConcert");

            migrationBuilder.RenameTable(
                name: "Pieces",
                newName: "Piece");

            migrationBuilder.RenameTable(
                name: "PerformersInGroup",
                newName: "PerformerInGroup");

            migrationBuilder.RenameTable(
                name: "Performers",
                newName: "Performer");

            migrationBuilder.RenameTable(
                name: "Instruments",
                newName: "Instrument");

            migrationBuilder.RenameTable(
                name: "Composers",
                newName: "Composer");

            migrationBuilder.RenameIndex(
                name: "IX_PiecesInConcert_PieceId",
                table: "PieceInConcert",
                newName: "IX_PieceInConcert_PieceId");

            migrationBuilder.RenameIndex(
                name: "IX_PiecesInConcert_ConcertId",
                table: "PieceInConcert",
                newName: "IX_PieceInConcert_ConcertId");

            migrationBuilder.RenameIndex(
                name: "IX_Pieces_ComposerId",
                table: "Piece",
                newName: "IX_Piece_ComposerId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformersInGroup_PieceInConcertId",
                table: "PerformerInGroup",
                newName: "IX_PerformerInGroup_PieceInConcertId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformersInGroup_PerformerId",
                table: "PerformerInGroup",
                newName: "IX_PerformerInGroup_PerformerId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformersInGroup_InstrumentId",
                table: "PerformerInGroup",
                newName: "IX_PerformerInGroup_InstrumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PieceInConcert",
                table: "PieceInConcert",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Piece",
                table: "Piece",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerformerInGroup",
                table: "PerformerInGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Performer",
                table: "Performer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instrument",
                table: "Instrument",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Composer",
                table: "Composer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformerInGroup_Instrument_InstrumentId",
                table: "PerformerInGroup",
                column: "InstrumentId",
                principalTable: "Instrument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformerInGroup_Performer_PerformerId",
                table: "PerformerInGroup",
                column: "PerformerId",
                principalTable: "Performer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformerInGroup_PieceInConcert_PieceInConcertId",
                table: "PerformerInGroup",
                column: "PieceInConcertId",
                principalTable: "PieceInConcert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Piece_Composer_ComposerId",
                table: "Piece",
                column: "ComposerId",
                principalTable: "Composer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceInConcert_Concerts_ConcertId",
                table: "PieceInConcert",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceInConcert_Piece_PieceId",
                table: "PieceInConcert",
                column: "PieceId",
                principalTable: "Piece",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
