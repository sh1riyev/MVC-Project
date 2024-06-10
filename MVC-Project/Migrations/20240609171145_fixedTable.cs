using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    public partial class fixedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseImage_Courses_CourseId",
                table: "CourseImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ActionBy",
                table: "CourseImage");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "CourseImage");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "CourseImage");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "CourseImage");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "CourseImage",
                newName: "IsMain");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseImage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CourseImage_Courses_CourseId",
                table: "CourseImage",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseImage_Courses_CourseId",
                table: "CourseImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "IsMain",
                table: "CourseImage",
                newName: "IsDeleted");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "CourseImage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ActionBy",
                table: "CourseImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "CourseImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "CourseImage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "CourseImage",
                type: "datetime2",
                nullable: true);

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
                values: new object[] { "e01623b1-681a-4d08-b919-07284f8f1c45", "180d33bf-d31e-41f6-9d15-2c49c03de7b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd06bcc-5c10-4845-9bd0-905ab14a53f3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0afc01df-d10d-4f04-b9dd-1fa7354c4599", "AQAAAAIAAYagAAAAEIJ5Moo6IjXasGF8wLVh+VtqXogat2oy0RKlYxdqSLUcaFv7KqUMKMhwOJ89PGrPEw==", "9d5a6d1e-ae9a-4f7a-9fdc-eff9f4acd40b" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseImage_Courses_CourseId",
                table: "CourseImage",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
