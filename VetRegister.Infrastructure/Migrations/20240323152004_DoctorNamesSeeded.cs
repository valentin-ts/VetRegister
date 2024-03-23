using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetRegister.Infrastructure.Migrations
{
    public partial class DoctorNamesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53ae2865-4a73-4974-ac06-eff5bf01b7f6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35039c1e-f5b5-448b-b464-43cd1c4ef58b", "AQAAAAEAACcQAAAAEA4CK4V8Nm+bE4qPjm6s2BHRkkxRMUayqnvhikkfJZ53+GiooyhlDT1t7+5Cmjd8Vw==", "d9cac6eb-e441-43c4-bab2-420e587e8775" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8ae8450-9d45-41fc-b440-e30cf6627a56", "AQAAAAEAACcQAAAAEBYNahSnfiS2lMM4lrbw5RwXULFuVt20/uPm6qP6sVpiDJN19aQbF6PYdG9WNYrleg==", "f2623f00-4eb5-46c1-bf4c-3e42e064fd45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c862997-7dff-4c65-9510-8e0b29e1e877",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6086046e-4418-4237-9588-95483a39e08b", "AQAAAAEAACcQAAAAENkKoKg1Z6tI3p0MnO9ZabaUH6EbQaRoGrX4cNLyvyqL+f9+sOVGK3u2scy6lcd+aQ==", "5aa6ee22-e1e3-40bb-bbaa-a802e97b6d39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dcfb6ed-d59c-4c5d-a0d0-8e0cd4409a53", "AQAAAAEAACcQAAAAEIsAUZ9k29BaUmJH+X7aTtXVzPeYPRZMB4a1lSWR9dxD9wYQMI9WdjHadzja47qLQg==", "f0b75736-cfa0-4381-945d-81f863cc4380" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Doctor 1 Name");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Doctor 2 Name");

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 17, 20, 4, 533, DateTimeKind.Local).AddTicks(3178));

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 17, 20, 4, 533, DateTimeKind.Local).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 17, 20, 4, 533, DateTimeKind.Local).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 17, 20, 4, 533, DateTimeKind.Local).AddTicks(3213));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
