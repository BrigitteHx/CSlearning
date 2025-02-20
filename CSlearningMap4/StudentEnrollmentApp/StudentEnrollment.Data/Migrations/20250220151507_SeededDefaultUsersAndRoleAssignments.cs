using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEnrollment.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUsersAndRoleAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68eb6747-d546-43ca-a963-2e3bcc793294", "AQAAAAIAAYagAAAAEDBQiIJkAESZR3v8juN/iTQVE/Xc7rIhTGRfIJUuxbG4duGKj0axD8xHtizU/cEVQg==", "642e51c1-332c-42a1-8034-6ed31676ca38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90f4d85d-d165-409e-93d6-67f3f889653d", "AQAAAAIAAYagAAAAEKHY4TNT9WHZTNGIAz0a+oPQvdX7m0XcfU4v231+A4H5/van9KfqbCz0lXKx43L/Rg==", "ed4f2aed-78b8-4966-9ea0-d4f2d678f9db" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7554c239-1bd4-4d9f-af7d-639cdd7253b2", "AQAAAAIAAYagAAAAELvpIiSUXaoJXasNRQg6K+yR9O8QdcCSCYX2TY0VREmcqcXpmLGjUEKTtP4K8pXNng==", "bd6c865e-a5ba-480e-aaaa-c4932e2d5221" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b583371-e23b-4537-a2b8-6c4cca94144e", "AQAAAAIAAYagAAAAEETCloXBDbl2nYZR33uMT/VUskAz/bXci8+LlNSDi718ZeFqlu1oM7LS6+snSY2POg==", "d8af3085-7b0f-4a9d-889c-535c72328ee4" });
        }
    }
}
