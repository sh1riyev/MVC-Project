using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    public partial class SocialSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aebb8b80-e548-419a-bb3a-e9c8b1c92834",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a2b3dc6a-b718-48ad-997c-3c1b7a28ee9e", "a9d11be3-965d-4ba1-8997-1f8e8b1fbaec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd06bcc-5c10-4845-9bd0-905ab14a53f3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be6111d3-a8c9-4bb6-842f-cef95395e509", "AQAAAAIAAYagAAAAECXmXL0xTXlM1iHGVAXEcOXY/BKJ5ijf2s8yJZOVyr7Yu/qRxHpBWglcFvWQV+EaZQ==", "b3a56edd-c7ed-4136-b792-43ee909f028b" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "ActionBy", "CreateDate", "DeleteDate", "IsDeleted", "Key", "UpdateDate", "Value" },
                values: new object[,]
                {
                    { 6, null, new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8450), null, false, "Twitter", null, "https://x.com/home" },
                    { 7, null, new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8460), null, false, "Facebook", null, "https://facebook.com/home" },
                    { 8, null, new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8460), null, false, "Youtube", null, "https://youtube.com/home" },
                    { 9, null, new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8460), null, false, "Linkedin", null, "https://linkedin.com/home" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aebb8b80-e548-419a-bb3a-e9c8b1c92834",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5c028d0f-808b-447f-bf3d-38f0aed3d6fd", "c50436be-e814-4751-a569-84310affc586" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd06bcc-5c10-4845-9bd0-905ab14a53f3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "572eb3c3-0e8c-40c8-9a14-c54401e049c2", "AQAAAAIAAYagAAAAEKjgNSaxTULP8W+sp1USQuzniYBbCOcVwPsTKlT1czPr1bcU85vj7a9Ep6ic1Y/29g==", "1052b78e-466b-42a9-9637-0484a5935c76" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 11, 44, 21, 367, DateTimeKind.Local).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 11, 44, 21, 367, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 11, 44, 21, 367, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 11, 44, 21, 367, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 11, 44, 21, 367, DateTimeKind.Local).AddTicks(5540));
        }
    }
}
