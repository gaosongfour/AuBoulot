using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuBoulot.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    SimpleName = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobOpportunity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MaxSalary = table.Column<int>(nullable: false),
                    MinSalary = table.Column<int>(nullable: false),
                    ParentCompanyId = table.Column<Guid>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    WorkAddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOpportunity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOpportunity_Company_ParentCompanyId",
                        column: x => x.ParentCompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOpportunity_Address_WorkAddressId",
                        column: x => x.WorkAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Direction = table.Column<int>(nullable: false),
                    Evalution = table.Column<int>(nullable: false),
                    JobOpportunityId = table.Column<Guid>(nullable: true),
                    NextActivityId = table.Column<Guid>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_JobOpportunity_JobOpportunityId",
                        column: x => x.JobOpportunityId,
                        principalTable: "JobOpportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_Activity_NextActivityId",
                        column: x => x.NextActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_JobOpportunityId",
                table: "Activity",
                column: "JobOpportunityId",
                unique: true,
                filter: "[JobOpportunityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_NextActivityId",
                table: "Activity",
                column: "NextActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOpportunity_ParentCompanyId",
                table: "JobOpportunity",
                column: "ParentCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOpportunity_WorkAddressId",
                table: "JobOpportunity",
                column: "WorkAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "JobOpportunity");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
