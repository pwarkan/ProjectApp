using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class MockData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "ManufacturedMonth", "ManufacturedYear", "Model", "RegistrationPlate", "VIN" },
                values: new object[,]
                {
                    { 1, "Rolls-Royce", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phantom", "L-255N", "JN1BJ0HP5FM865848" },
                    { 2, "Nissan", new DateTime(1970, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NX", "M-564N", "WAUSF98E06A178440" },
                    { 3, "Cadillac", new DateTime(1970, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DeVille", "M-712W", "3C6TD4DT1CG744582" },
                    { 4, "Honda", new DateTime(1970, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Odyssey", "E-8986", "WAUSH98E27A557225" },
                    { 5, "Dodge", new DateTime(1970, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caravan", "E-968W", "4JGCB2FB9AA509989" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "neberdt0@sciencedirect.com", "Neal", "Mawditt", "", "+867166746215" },
                    { 2, "sorrey1@princeton.edu", "Sydney", "Jeavon", "", "+529112499711" },
                    { 3, "oshakelade2@buzzfeed.com", "Octavia", "Kuhlmey", "", "+866517274856" },
                    { 4, "mflack3@kickstarter.com", "Maighdiln", "Bierling", "", "+3528413440113" },
                    { 5, "fhealks4@wunderground.com", "Flossy", "Wooddisse", "", "+2565212255733" }
                });

            migrationBuilder.InsertData(
                table: "ClientCars",
                columns: new[] { "CarId", "ClientId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 3, 2 },
                    { 5, 3 },
                    { 2, 4 },
                    { 1, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientCars",
                keyColumns: new[] { "CarId", "ClientId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ClientCars",
                keyColumns: new[] { "CarId", "ClientId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ClientCars",
                keyColumns: new[] { "CarId", "ClientId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ClientCars",
                keyColumns: new[] { "CarId", "ClientId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ClientCars",
                keyColumns: new[] { "CarId", "ClientId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
