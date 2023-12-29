using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnb.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddListingAndListingCateogryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingCategory_StorageFiles_Id",
                table: "ListingCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListingCategory",
                table: "ListingCategory");

            migrationBuilder.RenameTable(
                name: "ListingCategory",
                newName: "ListingCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListingCategories",
                table: "ListingCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    BuiltDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "numeric", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_ListingCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ListingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listings_CategoryId",
                table: "Listings",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingCategories_StorageFiles_Id",
                table: "ListingCategories",
                column: "Id",
                principalTable: "StorageFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingCategories_StorageFiles_Id",
                table: "ListingCategories");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListingCategories",
                table: "ListingCategories");

            migrationBuilder.RenameTable(
                name: "ListingCategories",
                newName: "ListingCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListingCategory",
                table: "ListingCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingCategory_StorageFiles_Id",
                table: "ListingCategory",
                column: "Id",
                principalTable: "StorageFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
