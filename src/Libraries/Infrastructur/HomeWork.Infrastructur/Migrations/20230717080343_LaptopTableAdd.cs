using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWork.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LaptopTableAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenSizeInches = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMSizeGB = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Color", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Model", "RAMSizeGB", "ScreenSizeInches", "Status" },
                values: new object[] { 1, "Black", new DateTimeOffset(new DateTime(2023, 7, 17, 14, 3, 42, 884, DateTimeKind.Unspecified).AddTicks(171), new TimeSpan(0, 6, 0, 0, 0)), "1", null, null, "Walton", 64, "6 inhci", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laptops");
        }
    }
}
