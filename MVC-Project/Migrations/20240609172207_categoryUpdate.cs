using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    public partial class categoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48b43127-5350-4a94-b901-742b2c6c98d7",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6cdad15-c6ac-4af2-911b-8065ca4477e2",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6321108-f942-4e92-92d7-a882c0b67b1f",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aebb8b80-e548-419a-bb3a-e9c8b1c92834",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "10724b46-e655-4aec-b1f3-d75bcf58a96f", "e9afa7c8-9340-49af-813b-f12bc53ef1e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd06bcc-5c10-4845-9bd0-905ab14a53f3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c8bcf33-7f6a-4533-8de0-bc31fd1d0454", "AQAAAAIAAYagAAAAEFJnnjSSr7QnOHHTKYa5fWZzDhlSGi+vlzDZIUnStBnfBI3jssf5gr62VVQyZg8gKQ==", "9fb473e0-ac71-453d-a94d-448f9e7e140a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48b43127-5350-4a94-b901-742b2c6c98d7",
                column: "ConcurrencyStamp",
                value: "bcac5fea-a30b-4d13-abc5-b81398e9d072");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6cdad15-c6ac-4af2-911b-8065ca4477e2",
                column: "ConcurrencyStamp",
                value: "2534153b-8e26-456e-ada9-6868ad10019e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6321108-f942-4e92-92d7-a882c0b67b1f",
                column: "ConcurrencyStamp",
                value: "428019ba-b5ac-4c18-92a6-eb859e710738");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aebb8b80-e548-419a-bb3a-e9c8b1c92834",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "302da264-cf26-4567-a289-a19c79f35f4d", "94dbca53-7f6d-44b9-a3d7-6069e89b382b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd06bcc-5c10-4845-9bd0-905ab14a53f3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e3cef04-18ff-46b0-8a4e-8206f01ab638", "AQAAAAEAACcQAAAAEIUkfNDgb1HyrkpOS4sWUkFaCA38qtDLU/K06+P1Yy5nqV4Uf4a6asdEpQp1/yaf7A==", "ddd8a0b6-a407-42f8-b2a8-d0d76387e0e5" });
        }
    }
}
