using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnb.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddListingAddressAndPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerNight",
                table: "Listings",
                newName: "PricePerNight_Amount");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Listings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Address_CityId",
                table: "Listings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Address_Latitude",
                table: "Listings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Address_Longitude",
                table: "Listings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PricePerNight_Currency",
                table: "Listings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Address_CityId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Address_Latitude",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Address_Longitude",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "PricePerNight_Currency",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "PricePerNight_Amount",
                table: "Listings",
                newName: "PricePerNight");
        }
    }
}
