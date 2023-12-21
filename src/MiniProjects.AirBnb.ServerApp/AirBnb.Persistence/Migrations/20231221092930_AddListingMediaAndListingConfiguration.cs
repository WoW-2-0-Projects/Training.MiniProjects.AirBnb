using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnb.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddListingMediaAndListingConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ListingId",
                table: "ListingMedias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ListingMedias_ListingId",
                table: "ListingMedias",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingMedias_Listings_ListingId",
                table: "ListingMedias",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingMedias_Listings_ListingId",
                table: "ListingMedias");

            migrationBuilder.DropIndex(
                name: "IX_ListingMedias_ListingId",
                table: "ListingMedias");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "ListingMedias");
        }
    }
}
