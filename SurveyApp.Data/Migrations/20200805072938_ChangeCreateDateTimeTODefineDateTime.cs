using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyApp.Data.Migrations
{
    public partial class ChangeCreateDateTimeTODefineDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Surveys");

            migrationBuilder.AddColumn<DateTime>(
                name: "DefineDateTime",
                table: "Surveys",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefineDateTime",
                table: "Surveys");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Surveys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
