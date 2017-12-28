using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuBoulot.Web.Migrations
{
    public partial class addDataAnnotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_JobOpportunity_JobOpportunityId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOpportunity_Company_ParentCompanyId",
                table: "JobOpportunity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_JobOpportunityId",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "Evalution",
                table: "Activity",
                newName: "Duration");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "JobOpportunity",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentCompanyId",
                table: "JobOpportunity",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "JobOpportunity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "SimpleName",
                table: "Company",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Activity",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JobOpportunityId",
                table: "Activity",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualDateTime",
                table: "Activity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedDateTime",
                table: "Activity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Activity",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_JobOpportunityId",
                table: "Activity",
                column: "JobOpportunityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_JobOpportunity_JobOpportunityId",
                table: "Activity",
                column: "JobOpportunityId",
                principalTable: "JobOpportunity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOpportunity_Company_ParentCompanyId",
                table: "JobOpportunity",
                column: "ParentCompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_JobOpportunity_JobOpportunityId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOpportunity_Company_ParentCompanyId",
                table: "JobOpportunity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_JobOpportunityId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "JobOpportunity");

            migrationBuilder.DropColumn(
                name: "ActualDateTime",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "EstimatedDateTime",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Activity",
                newName: "Evalution");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "JobOpportunity",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentCompanyId",
                table: "JobOpportunity",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "SimpleName",
                table: "Company",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Activity",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<Guid>(
                name: "JobOpportunityId",
                table: "Activity",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Activity_JobOpportunityId",
                table: "Activity",
                column: "JobOpportunityId",
                unique: true,
                filter: "[JobOpportunityId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_JobOpportunity_JobOpportunityId",
                table: "Activity",
                column: "JobOpportunityId",
                principalTable: "JobOpportunity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOpportunity_Company_ParentCompanyId",
                table: "JobOpportunity",
                column: "ParentCompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
