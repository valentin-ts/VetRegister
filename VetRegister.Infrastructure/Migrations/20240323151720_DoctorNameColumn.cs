using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetRegister.Infrastructure.Migrations
{
    public partial class DoctorNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Doctor Name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53ae2865-4a73-4974-ac06-eff5bf01b7f6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec56dd71-5c18-4e77-bd06-2ab892dd1890", "AQAAAAEAACcQAAAAEL2etau1/WluR7n2F0qEo31aL+8j1gQtC3AoI+zHJWqRwqbAilqPtU7uaqVf8VTZNg==", "16096588-a430-4e84-8c3f-12a2652edca5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a0140d8-aaa2-4848-ae99-cab1f77224c5", "AQAAAAEAACcQAAAAECI38CTw/G8K6jEtfPqGXW3weUc3y0E3eam4VHdPLT+imOMswxsPTLINqsswUkGWeA==", "d9b0bfba-ffc0-460b-971f-968a4a47b169" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c862997-7dff-4c65-9510-8e0b29e1e877",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22ba42d5-4108-44a0-83a0-6bbfb07467f7", "AQAAAAEAACcQAAAAEGReYsRQY6WSzTYcxRMPzljvBZkomLcYq/MIJM/8+DOyWWjJc7OVXTWAlz+N2Iz1Gw==", "5a2e4822-c501-4dff-b307-a74312935fc7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a5aa2db-538b-4153-95e6-a5396899a1dd", "AQAAAAEAACcQAAAAECEdrKLvGZrfi6gjr18bR+SgkY7C3cS1dwEty+nU05CGXyzBihjoMOAbRYSN7b/LCQ==", "c25a0ea6-7101-4097-818c-42917a5b4c49" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 17, 17, 19, 802, DateTimeKind.Local).AddTicks(5437));

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 17, 17, 19, 802, DateTimeKind.Local).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 17, 17, 19, 802, DateTimeKind.Local).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 17, 17, 19, 802, DateTimeKind.Local).AddTicks(5472));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Doctors");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53ae2865-4a73-4974-ac06-eff5bf01b7f6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2437ccb6-85a7-4819-a073-be3b16775d3d", "AQAAAAEAACcQAAAAELiwCpyYaJBe0+pG0Nrzq2AwPd1uzvucewfhFJwwEyg2luIGZ3IV3NHu7ZiXztb4KA==", "48cdffb3-9207-4249-9bf8-27cc70e3793d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da038136-f92e-423c-9540-caf91089ad43", "AQAAAAEAACcQAAAAEJeZq/9/AIqyPwssZdX7fH2Nd69htyiLY+Mt3BBcHrxT8qVKigew81TEVjZ1JP8rGQ==", "cc0eb712-f763-4828-8073-8278221c0eee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c862997-7dff-4c65-9510-8e0b29e1e877",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2e17cbe-d846-4d2c-866d-91a7e75f6a4d", "AQAAAAEAACcQAAAAEHx3ByXUeC8KbftWzwvh6w+h7kh2Qt00zzQOTF/fvC/qLOwT5nUiP0hOGtXYvlDQNA==", "a2e616d5-e8d4-4c53-820d-d68620df5bbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2c64f55-182b-4412-9fed-a5b5307ba388", "AQAAAAEAACcQAAAAEHP54votyqBbrd/Wlg7woUiZYuq2B45CnmurRNY4qDlKt8X8sqDthLrGj09aceMIeA==", "a22e7ece-6822-400b-9fb1-d8d70d9e0791" });

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 11, 20, 44, 987, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 11, 20, 44, 987, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 11, 20, 44, 987, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 11, 20, 44, 987, DateTimeKind.Local).AddTicks(9791));
        }
    }
}
