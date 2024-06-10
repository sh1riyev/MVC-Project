using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    public partial class SocialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSocial_Social_SocialId",
                table: "InstructorSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Social",
                table: "Social");

            migrationBuilder.RenameTable(
                name: "Social",
                newName: "Socials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Socials",
                table: "Socials",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aebb8b80-e548-419a-bb3a-e9c8b1c92834",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "80832ed6-7a1a-47dd-a29b-2df181bdab04", "5f282644-74be-4375-a358-1b5a7a4b154f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd06bcc-5c10-4845-9bd0-905ab14a53f3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bdb023d-34f7-42ea-97b8-e1a0e14ba2b9", "AQAAAAIAAYagAAAAEGlBmTlqHud339uYdNg07phyJ1VK7I9JY2yKNB0CCCIi6p80O/9lSVuiXLu7es0NyQ==", "162a417a-7c0a-40dc-82b1-b7217293b57e" });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 17, 30, 536, DateTimeKind.Local).AddTicks(7510));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 17, 30, 536, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 17, 30, 536, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 17, 30, 536, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 17, 30, 536, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 17, 30, 536, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 17, 30, 536, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 17, 30, 536, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 17, 30, 536, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.InsertData(
                table: "Socials",
                columns: new[] { "Id", "ActionBy", "CreateDate", "DeleteDate", "Image", "IsDeleted", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 6, 10, 12, 17, 30, 536, DateTimeKind.Local).AddTicks(7600), null, "fab fa-facebook-f", false, "Facebook", null },
                    { 2, null, new DateTime(2024, 6, 10, 12, 17, 30, 536, DateTimeKind.Local).AddTicks(7600), null, "fab fa-twitter", false, "Twitter", null },
                    { 3, null, new DateTime(2024, 6, 10, 12, 17, 30, 536, DateTimeKind.Local).AddTicks(7600), null, "fab fa-instagram", false, "Instagram", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSocial_Socials_SocialId",
                table: "InstructorSocial",
                column: "SocialId",
                principalTable: "Socials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSocial_Socials_SocialId",
                table: "InstructorSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Socials",
                table: "Socials");

            migrationBuilder.DeleteData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "Socials",
                newName: "Social");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Social",
                table: "Social",
                column: "Id");

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

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2024, 6, 10, 12, 3, 45, 103, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSocial_Social_SocialId",
                table: "InstructorSocial",
                column: "SocialId",
                principalTable: "Social",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
