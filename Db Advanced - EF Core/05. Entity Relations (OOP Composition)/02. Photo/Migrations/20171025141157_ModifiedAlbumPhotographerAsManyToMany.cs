using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace _02.Photo.Migrations
{
    public partial class ModifiedAlbumPhotographerAsManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Photographers_PhotographerId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_PhotographerId",
                table: "Albums");

            migrationBuilder.CreateTable(
                name: "PhotographerAlbum",
                columns: table => new
                {
                    PhotographerId = table.Column<int>(type: "int", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographerAlbum", x => new { x.PhotographerId, x.AlbumId });
                    table.ForeignKey(
                        name: "FK_PhotographerAlbum_Photographers_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Photographers",
                        principalColumn: "PhotographerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotographerAlbum_Albums_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Albums",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotographerAlbum_AlbumId",
                table: "PhotographerAlbum",
                column: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotographerAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_PhotographerId",
                table: "Albums",
                column: "PhotographerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Photographers_PhotographerId",
                table: "Albums",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "PhotographerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
