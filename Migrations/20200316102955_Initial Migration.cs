using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AFIAPITest.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    PolicyReference = table.Column<string>(maxLength: 9, nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "Id", "DOB", "Email", "Firstname", "PolicyReference", "Surname" },
                values: new object[] { 1L, new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "JaneDoe@gmail.com", "Jane", "AA-123456", "Doe" });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "Id", "DOB", "Email", "Firstname", "PolicyReference", "Surname" },
                values: new object[] { 2L, new DateTime(1989, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fred.Blogs@BLogsMail.com", "Fred", "AA-123456", "Bloggs" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");
        }
    }
}
