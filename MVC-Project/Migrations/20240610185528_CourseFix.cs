using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    public partial class CourseFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aebb8b80-e548-419a-bb3a-e9c8b1c92834",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "346ac87f-20d3-488a-9a98-7e8f770d1d5d", "3b1ec37a-22c8-486c-98ae-3e598e93d3bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd06bcc-5c10-4845-9bd0-905ab14a53f3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b933e5ae-bfec-4e72-815e-18ae6ee79c69", "AQAAAAIAAYagAAAAEKNrVthnKQH2SA6AV2MrDKJmPm51LYETj4O9ZQloAYVSAcpAydsmXkdqs9e56O9imQ==", "9b7c365b-e435-424d-9a82-4588d9852994" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 22, 55, 28, 708, DateTimeKind.Local).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 22, 55, 28, 708, DateTimeKind.Local).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 22, 55, 28, 708, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 22, 55, 28, 708, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 22, 55, 28, 708, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 22, 55, 28, 708, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 22, 55, 28, 708, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 22, 55, 28, 708, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 22, 55, 28, 708, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 22, 55, 28, 708, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 22, 55, 28, 708, DateTimeKind.Local).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 22, 55, 28, 708, DateTimeKind.Local).AddTicks(9790));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aebb8b80-e548-419a-bb3a-e9c8b1c92834",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f8b48e97-45ec-4690-bbe4-35057620aa24", "4b03d8f4-abdc-4281-91f7-e8061a52afba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd06bcc-5c10-4845-9bd0-905ab14a53f3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e29bff17-41a8-4b3a-b851-bd76730a9b1e", "AQAAAAIAAYagAAAAEDeoI2eSfmOkAr4esPfN5T61Qy3+2IA+leW4X+DC/z62ilA+8dDZJaee9h1YMnwssg==", "bb27d417-6cf1-4c20-a8e0-28e5d98d6396" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 21, 17, 53, 493, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 21, 17, 53, 493, DateTimeKind.Local).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 21, 17, 53, 493, DateTimeKind.Local).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 21, 17, 53, 493, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 21, 17, 53, 493, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 21, 17, 53, 493, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 21, 17, 53, 493, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 21, 17, 53, 493, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 21, 17, 53, 493, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 21, 17, 53, 493, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 21, 17, 53, 493, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 21, 17, 53, 493, DateTimeKind.Local).AddTicks(7480));
        }
    }
}
