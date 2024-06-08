using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    public partial class AboutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActionBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aebb8b80-e548-419a-bb3a-e9c8b1c92834",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ca196f6f-7284-4e34-8326-eab57685f50d", "0a7121b9-a25b-4255-97c4-49f2dda30c00" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd06bcc-5c10-4845-9bd0-905ab14a53f3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b0cebd7-7eda-48cb-a047-57c5fd24e420", "AQAAAAIAAYagAAAAEKoBVcWrewKZSyxxz7RDwqwbXPyvWmZLq3RfFTmqbfVpGOY5g8hYTnwfiIxqxLhbJQ==", "3947067a-adf1-45c8-a4c4-96ee785fd146" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

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
    }
}
