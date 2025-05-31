using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProject.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class initialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BedType",
                table: "Rooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "101, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleType",
                table: "Ambulances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Ambulances",
                columns: new[] { "AmbulanceId", "DriverName", "MobileNumber", "VehicleNumber", "VehicleType" },
                values: new object[,]
                {
                    { new Guid("1b84996d-e7c2-4c96-aa39-f111eb5304a5"), "Amit Joshi", "9334455667", "UP21 ST 5566", "Normal" },
                    { new Guid("1ce30ccb-f4b4-473a-8222-233a3d27351e"), "Manoj Tiwari", "9001122334", "UP21 MN 6789", "Normal" },
                    { new Guid("1f7fc946-ab0a-4c06-8571-3f022559b218"), "Ravi Kumar", "9876543210", "UP21 AB 1234", "Normal" },
                    { new Guid("4a105e1f-397d-465a-832c-8ecdd9d90bc2"), "Rajeev Ranjan", "9123409876", "UP21 KL 2345", "AdvancedLifeSupport" },
                    { new Guid("4f4ba941-9355-4335-9cc5-a05226aea4cd"), "Sunil Mehra", "9123456789", "UP21 CD 5678", "BasicLifeSupport" },
                    { new Guid("529cdd00-5d9e-475b-af22-e8852ee599ae"), "Anil Sharma", "9012345678", "UP21 EF 9012", "AdvancedLifeSupport" },
                    { new Guid("57d695f7-4cc6-48c6-bd78-1a5bc96b3a53"), "Karan Verma", "9223344556", "UP21 QR 3344", "AdvancedLifeSupport" },
                    { new Guid("6d7af7dd-7b34-4019-8d25-c73217c0da74"), "Vikram Singh", "9988776655", "UP21 GH 3456", "Normal" },
                    { new Guid("841383af-86ff-45e7-ab96-d3b60b1e097f"), "Suresh Yadav", "9876501234", "UP21 IJ 7890", "Neonatal" },
                    { new Guid("9ae9403f-961d-4552-bc15-8f2273639640"), "Deepak Chauhan", "9112233445", "UP21 OP 1122", "BasicLifeSupport" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DeptName", "HODName", "PhoneExtensionNo" },
                values: new object[,]
                {
                    { 1, "Cardiology", "Dr. Anil Mehra", "111" },
                    { 2, "Neurology", "Dr. Seema Verma", "222" },
                    { 3, "Orthopedics", "Dr. Rajesh Khanna", "333" },
                    { 4, "Pediatrics", "Dr. Neha Sharma", "444" },
                    { 5, "General Medicine", "Dr. Vivek Gupta", "555" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "BedType", "Price", "RoomNumber" },
                values: new object[,]
                {
                    { 101, "Single", 1000m, "A101" },
                    { 102, "Double", 2000m, "A102" },
                    { 103, "General", 500m, "A103" },
                    { 104, "ICU", 5000m, "A104" },
                    { 105, "Single", 1000m, "B101" },
                    { 106, "Double", 2000m, "B102" },
                    { 107, "General", 500m, "B103" },
                    { 108, "ICU", 5000m, "B104" },
                    { 109, "Single", 1000m, "C101" },
                    { 110, "Double", 2000m, "C102" },
                    { 111, "General", 500m, "C103" },
                    { 112, "ICU", 5000m, "C104" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "AadharNo", "Age", "DepartmentId", "EmailId", "Gender", "MobileNumber", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("048a035c-adc0-4eee-a9c5-ed320cfa4c27"), "901234567890", 39, 4, "nikhil.bansal@hospital.com", "Male", "9445566778", "Dr. Nikhil Bansal", "Child Specialist" },
                    { new Guid("62989037-c514-420a-aaad-0534383cffa3"), "234567890123", 38, 2, "priya.sharma@hospital.com", "Female", "9123456789", "Dr. Priya Sharma", "Neurologist" },
                    { new Guid("64537262-c51a-41c1-9994-06cb1d2d5d78"), "678901234567", 40, 1, "kavita.nair@hospital.com", "Female", "9112233445", "Dr. Kavita Nair", "Cardiology Consultant" },
                    { new Guid("7c8ed9e7-0e96-4b45-91b5-cba7b99a1d0f"), "012345678901", 41, 5, "anuja.desai@hospital.com", "Female", "9556677889", "Dr. Anuja Desai", "General Medicine Consultant" },
                    { new Guid("8a8affcc-c224-4f3b-a49e-6446c9e8329d"), "456789012345", 42, 4, "sneha.verma@hospital.com", "Female", "9988776655", "Dr. Sneha Verma", "Pediatrician" },
                    { new Guid("8f647e4c-f09b-4aa5-90ae-2f16d883b65f"), "890123456789", 44, 3, "meena.joshi@hospital.com", "Female", "9334455667", "Dr. Meena Joshi", "Orthopedic Consultant" },
                    { new Guid("9d911f68-d7e1-40fb-8255-254f23105bc3"), "345678901234", 50, 3, "arvind.patel@hospital.com", "Male", "9012345678", "Dr. Arvind Patel", "Orthopedic Surgeon" },
                    { new Guid("aad9f233-2c61-4dc3-9b45-c5da6815ad7d"), "123456789012", 45, 1, "ramesh.kumar@hospital.com", "Male", "9876543210", "Dr. Ramesh Kumar", "Senior Cardiologist" },
                    { new Guid("d1c1c324-b11c-42b5-9db0-ebea2b566d89"), "567890123456", 47, 5, "manish.gupta@hospital.com", "Male", "9876501234", "Dr. Manish Gupta", "General Physician" },
                    { new Guid("d26f37a7-8ff1-45b5-84e0-61e032de441f"), "789012345678", 36, 2, "rohit.sinha@hospital.com", "Male", "9223344556", "Dr. Rohit Sinha", "Neurosurgeon" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "AadharId", "AdmissionDateTime", "Disease", "FirstName", "Gender", "InitialDeposit", "LastName", "MobileNumber", "Symptoms", "roomId" },
                values: new object[,]
                {
                    { new Guid("549f3201-112c-4c33-b7d8-f1c320ba2ea6"), "456789012345", new DateTime(2025, 5, 23, 11, 45, 0, 0, DateTimeKind.Unspecified), "Migraine", "Pooja", "Female", 3000m, "Singh", "9988776655", "Severe headache, nausea", 104 },
                    { new Guid("75d56a79-8d58-456a-a3ab-57aa863bac9e"), "345678901234", new DateTime(2025, 5, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), "Hypertension", "Ravi", "Male", 4500m, "Kumar", "9012345678", "Headache, dizziness", 103 },
                    { new Guid("96ab69ce-d9d9-4743-bbe9-e357d886fb9a"), "234567890123", new DateTime(2025, 5, 21, 14, 15, 0, 0, DateTimeKind.Unspecified), "Asthma", "Neha", "Female", 4000m, "Verma", "9123456789", "Shortness of breath, wheezing", 102 },
                    { new Guid("af6ae5c7-1520-479c-add6-b90c84633ae5"), "567890123456", new DateTime(2025, 5, 24, 16, 0, 0, 0, DateTimeKind.Unspecified), "COVID-19", "Suresh", "Male", 6000m, "Yadav", "9876501234", "Fever, cough, breathlessness", 105 },
                    { new Guid("c513f843-93ea-4761-9113-3eb19b910122"), "123456789012", new DateTime(2025, 5, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), "Diabetes", "Amit", "Male", 5000m, "Sharma", "9876543210", "Fatigue, frequent urination", 101 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ambulances",
                keyColumn: "AmbulanceId",
                keyValue: new Guid("1b84996d-e7c2-4c96-aa39-f111eb5304a5"));

            migrationBuilder.DeleteData(
                table: "Ambulances",
                keyColumn: "AmbulanceId",
                keyValue: new Guid("1ce30ccb-f4b4-473a-8222-233a3d27351e"));

            migrationBuilder.DeleteData(
                table: "Ambulances",
                keyColumn: "AmbulanceId",
                keyValue: new Guid("1f7fc946-ab0a-4c06-8571-3f022559b218"));

            migrationBuilder.DeleteData(
                table: "Ambulances",
                keyColumn: "AmbulanceId",
                keyValue: new Guid("4a105e1f-397d-465a-832c-8ecdd9d90bc2"));

            migrationBuilder.DeleteData(
                table: "Ambulances",
                keyColumn: "AmbulanceId",
                keyValue: new Guid("4f4ba941-9355-4335-9cc5-a05226aea4cd"));

            migrationBuilder.DeleteData(
                table: "Ambulances",
                keyColumn: "AmbulanceId",
                keyValue: new Guid("529cdd00-5d9e-475b-af22-e8852ee599ae"));

            migrationBuilder.DeleteData(
                table: "Ambulances",
                keyColumn: "AmbulanceId",
                keyValue: new Guid("57d695f7-4cc6-48c6-bd78-1a5bc96b3a53"));

            migrationBuilder.DeleteData(
                table: "Ambulances",
                keyColumn: "AmbulanceId",
                keyValue: new Guid("6d7af7dd-7b34-4019-8d25-c73217c0da74"));

            migrationBuilder.DeleteData(
                table: "Ambulances",
                keyColumn: "AmbulanceId",
                keyValue: new Guid("841383af-86ff-45e7-ab96-d3b60b1e097f"));

            migrationBuilder.DeleteData(
                table: "Ambulances",
                keyColumn: "AmbulanceId",
                keyValue: new Guid("9ae9403f-961d-4552-bc15-8f2273639640"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("048a035c-adc0-4eee-a9c5-ed320cfa4c27"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("62989037-c514-420a-aaad-0534383cffa3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("64537262-c51a-41c1-9994-06cb1d2d5d78"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("7c8ed9e7-0e96-4b45-91b5-cba7b99a1d0f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("8a8affcc-c224-4f3b-a49e-6446c9e8329d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("8f647e4c-f09b-4aa5-90ae-2f16d883b65f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("9d911f68-d7e1-40fb-8255-254f23105bc3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("aad9f233-2c61-4dc3-9b45-c5da6815ad7d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("d1c1c324-b11c-42b5-9db0-ebea2b566d89"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("d26f37a7-8ff1-45b5-84e0-61e032de441f"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("549f3201-112c-4c33-b7d8-f1c320ba2ea6"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("75d56a79-8d58-456a-a3ab-57aa863bac9e"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("96ab69ce-d9d9-4743-bbe9-e357d886fb9a"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("af6ae5c7-1520-479c-add6-b90c84633ae5"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: new Guid("c513f843-93ea-4761-9113-3eb19b910122"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 105);

            migrationBuilder.AlterColumn<int>(
                name: "BedType",
                table: "Rooms",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "101, 1");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleType",
                table: "Ambulances",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
