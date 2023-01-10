using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicalTrack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    DrugId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DrugInfo = table.Column<Dictionary<string, string>>(type: "hstore", nullable: true),
                    DrugCount = table.Column<int>(type: "integer", nullable: true),
                    DrugPurpose = table.Column<Dictionary<string, string>>(type: "hstore", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.DrugId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientName = table.Column<Dictionary<string, string>>(type: "hstore", nullable: false),
                    PatientAge = table.Column<int>(type: "integer", nullable: false),
                    PatientCondition = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScheduleDay = table.Column<int>(type: "integer", nullable: true),
                    ScheduleTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    ScheduleConfirm = table.Column<bool[]>(type: "boolean[]", nullable: true),
                    SchedulePatientId = table.Column<int>(type: "integer", nullable: false),
                    ScheduleDrugId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Drugs_ScheduleDrugId",
                        column: x => x.ScheduleDrugId,
                        principalTable: "Drugs",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Patients_SchedulePatientId",
                        column: x => x.SchedulePatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestResultBp = table.Column<int>(type: "integer", nullable: false),
                    TestResultSugars = table.Column<int>(type: "integer", nullable: false),
                    TestResultWeight = table.Column<int>(type: "integer", nullable: false),
                    TestResultOxygen = table.Column<int>(type: "integer", nullable: false),
                    TestPatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Tests_Patients_TestPatientId",
                        column: x => x.TestPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ScheduleDrugId",
                table: "Schedules",
                column: "ScheduleDrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SchedulePatientId",
                table: "Schedules",
                column: "SchedulePatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TestPatientId",
                table: "Tests",
                column: "TestPatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
