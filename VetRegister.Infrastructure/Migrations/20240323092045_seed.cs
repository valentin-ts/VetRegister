using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetRegister.Infrastructure.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "53ae2865-4a73-4974-ac06-eff5bf01b7f6", 0, "2437ccb6-85a7-4819-a073-be3b16775d3d", "owner2@vet.com", false, false, null, "owner2@vet.com", "owner2@vet.com", "AQAAAAEAACcQAAAAELiwCpyYaJBe0+pG0Nrzq2AwPd1uzvucewfhFJwwEyg2luIGZ3IV3NHu7ZiXztb4KA==", null, false, "48cdffb3-9207-4249-9bf8-27cc70e3793d", false, "owner2@vet.com" },
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "da038136-f92e-423c-9540-caf91089ad43", "doctor1@vet.com", false, false, null, "doctor1@vet.com", "doctor1@vet.com", "AQAAAAEAACcQAAAAEJeZq/9/AIqyPwssZdX7fH2Nd69htyiLY+Mt3BBcHrxT8qVKigew81TEVjZ1JP8rGQ==", null, false, "cc0eb712-f763-4828-8073-8278221c0eee", false, "doctor1@vet.com" },
                    { "9c862997-7dff-4c65-9510-8e0b29e1e877", 0, "a2e17cbe-d846-4d2c-866d-91a7e75f6a4d", "doctor2@vet.com", false, false, null, "doctor2@vet.com", "doctor2@vet.com", "AQAAAAEAACcQAAAAEHx3ByXUeC8KbftWzwvh6w+h7kh2Qt00zzQOTF/fvC/qLOwT5nUiP0hOGtXYvlDQNA==", null, false, "a2e616d5-e8d4-4c53-820d-d68620df5bbb", false, "doctor2@vet.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "d2c64f55-182b-4412-9fed-a5b5307ba388", "owner1@vet.com", false, false, null, "owner1@vet.com", "owner1@vet.com", "AQAAAAEAACcQAAAAEHP54votyqBbrd/Wlg7woUiZYuq2B45CnmurRNY4qDlKt8X8sqDthLrGj09aceMIeA==", null, false, "a22e7ece-6822-400b-9fb1-d8d70d9e0791", false, "owner1@vet.com" }
                });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Clinic1", "0880000001" },
                    { 2, "Clinic2", "0880000002" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" },
                    { 3, "Fish" },
                    { 4, "Bird" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "ClinicId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 2, 2, "9c862997-7dff-4c65-9510-8e0b29e1e877" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "Owner1 Address", "0880000003", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, "Owner2 Address", "0880000004", "53ae2865-4a73-4974-ac06-eff5bf01b7f6" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "DateOfBirth", "GenderIsMale", "Name", "OwnerId", "SpecieId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Dog1", 1, 1 },
                    { 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Cat1", 1, 2 },
                    { 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Fish1", 2, 3 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bird1", 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Procedures",
                columns: new[] { "Id", "AnimalId", "CreatedOn", "Description", "DoctorId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 23, 11, 20, 44, 987, DateTimeKind.Local).AddTicks(9756), "Operation", 1 },
                    { 2, 2, new DateTime(2024, 3, 23, 11, 20, 44, 987, DateTimeKind.Local).AddTicks(9787), "Vaccination", 1 },
                    { 3, 3, new DateTime(2024, 3, 23, 11, 20, 44, 987, DateTimeKind.Local).AddTicks(9789), "Blood Test", 2 },
                    { 4, 4, new DateTime(2024, 3, 23, 11, 20, 44, 987, DateTimeKind.Local).AddTicks(9791), "Nail Trimming", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c862997-7dff-4c65-9510-8e0b29e1e877");

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53ae2865-4a73-4974-ac06-eff5bf01b7f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
