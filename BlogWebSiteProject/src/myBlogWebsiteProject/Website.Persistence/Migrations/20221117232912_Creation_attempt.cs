using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Creationattempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmailAuthenticators",
                columns: new[] { "Id", "ActivationKey", "CreatedDate", "IsVerified", "UpdatedDate", "UserId" },
                values: new object[] { 1, "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 18, 2, 29, 12, 599, DateTimeKind.Local).AddTicks(7605), new byte[] { 70, 200, 205, 152, 44, 175, 234, 198, 124, 9, 142, 85, 164, 111, 149, 151, 33, 180, 166, 129, 71, 237, 251, 53, 56, 203, 135, 73, 186, 115, 175, 139, 88, 62, 131, 93, 139, 213, 91, 69, 138, 11, 153, 79, 223, 16, 235, 210, 109, 24, 143, 189, 68, 243, 201, 167, 55, 240, 19, 219, 63, 109, 246, 74 }, new byte[] { 28, 21, 189, 126, 60, 83, 58, 47, 36, 61, 209, 94, 154, 182, 6, 230, 48, 149, 170, 34, 22, 78, 104, 115, 154, 141, 60, 184, 16, 19, 29, 96, 160, 80, 1, 158, 148, 221, 161, 72, 172, 85, 157, 108, 145, 251, 98, 69, 37, 140, 239, 153, 159, 64, 184, 66, 217, 46, 64, 212, 60, 234, 154, 41, 219, 247, 15, 115, 211, 35, 23, 54, 162, 22, 74, 140, 225, 212, 148, 54, 112, 198, 12, 235, 221, 255, 7, 149, 137, 89, 62, 19, 168, 244, 62, 161, 66, 198, 128, 200, 121, 215, 44, 76, 128, 214, 42, 125, 112, 206, 200, 197, 153, 172, 5, 36, 54, 56, 34, 253, 66, 241, 120, 199, 12, 106, 78, 39 }, new DateTime(2022, 11, 18, 2, 29, 12, 599, DateTimeKind.Local).AddTicks(7614) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailAuthenticators",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 18, 2, 26, 5, 591, DateTimeKind.Local).AddTicks(5235), new byte[] { 8, 92, 150, 84, 17, 214, 137, 27, 218, 179, 153, 123, 55, 75, 45, 45, 232, 172, 112, 237, 88, 133, 185, 225, 216, 236, 157, 139, 149, 209, 36, 181, 149, 181, 84, 161, 191, 226, 187, 213, 20, 214, 73, 181, 206, 65, 177, 76, 116, 98, 175, 231, 16, 62, 39, 201, 176, 98, 93, 182, 213, 43, 152, 84 }, new byte[] { 97, 4, 184, 45, 150, 168, 4, 167, 226, 100, 165, 117, 25, 95, 167, 241, 179, 64, 192, 127, 205, 15, 227, 105, 60, 198, 13, 107, 9, 212, 10, 97, 170, 221, 223, 49, 31, 112, 135, 191, 254, 83, 140, 40, 105, 255, 174, 221, 255, 108, 113, 80, 213, 93, 70, 201, 201, 109, 87, 150, 4, 186, 175, 215, 131, 236, 191, 3, 41, 111, 32, 42, 11, 151, 42, 208, 16, 176, 196, 243, 52, 90, 79, 159, 121, 112, 122, 241, 212, 138, 216, 14, 85, 133, 103, 225, 214, 139, 139, 131, 236, 17, 18, 129, 33, 115, 110, 52, 212, 121, 131, 210, 23, 37, 11, 3, 93, 163, 185, 104, 231, 108, 255, 98, 223, 208, 73, 153 }, new DateTime(2022, 11, 18, 2, 26, 5, 591, DateTimeKind.Local).AddTicks(5247) });
        }
    }
}
