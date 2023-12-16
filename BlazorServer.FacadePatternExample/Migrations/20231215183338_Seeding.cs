using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.FacadePatternExample.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Country", "CustomerSince", "Description", "IsActive", "Name" },
                values: new object[] { 1, "123 Fake St", "USA", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", true, "Fred" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[] { 1, "Fiction", true, "Fiction" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[] { 2, "Romantic", true, "Romantic" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[] { 3, "Sci-Fi", true, "Sci-Fi" });

            migrationBuilder.InsertData(
                table: "shippingProviders",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[] { 1, "United States Postal Service", true, "USPS" });

            migrationBuilder.InsertData(
                table: "shippingProviders",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[] { 2, "United Postal Service", true, "UPS" });

            migrationBuilder.InsertData(
                table: "shippingProviders",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[] { 3, "Fedex", true, "FEDEX" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "shippingProviders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "shippingProviders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "shippingProviders",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
