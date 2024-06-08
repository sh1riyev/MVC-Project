using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    public partial class InformationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Information",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActionBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Information", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aebb8b80-e548-419a-bb3a-e9c8b1c92834",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c79c853c-fcdc-4f49-96df-9f2b91583a7d", "4e7e3b0a-8483-4269-be1a-957ecdb7b45a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd06bcc-5c10-4845-9bd0-905ab14a53f3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2592908c-ffca-413a-b318-2aa81f3518f1", "AQAAAAIAAYagAAAAEDndwSISoRVix2LLXdsY912+2DUlecXHdyHObox9DIvQObSuVcsS3oB+6K++XnH6LQ==", "03893de3-2abe-45dd-b26d-19557ecff1d1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Information");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aebb8b80-e548-419a-bb3a-e9c8b1c92834",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "551293a4-7464-4e4d-a51b-618a11c0bd14", "8a4972d2-b31a-44fd-afd2-0a68ab3bface" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd06bcc-5c10-4845-9bd0-905ab14a53f3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0db05963-620d-4fec-a4ae-dceff2bc2199", "AQAAAAIAAYagAAAAEBue2GAjq0NtoG0BMPzIULBFrLA68HUkhXEWjfATAk8YkRlN6pp6l7asim9jnNYh0A==", "164ca0ed-0094-412c-8b50-951b88110a20" });
        }
    }
}
