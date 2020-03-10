using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HiringGenie.Api.Migrations
{
    public partial class addinginterviewfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Job_JobId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_AspNetUsers_PostedBy",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Application_ApplicationId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_AspNetUsers_InterviewerId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Scheduler_SchedulerId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_AspNetUsers_PostedBy",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scheduler",
                table: "Scheduler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interview",
                table: "Interview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "IsSlotAccepted",
                table: "Scheduler");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Interview");

            migrationBuilder.RenameTable(
                name: "Scheduler",
                newName: "Schedulers");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "Interview",
                newName: "Interviews");

            migrationBuilder.RenameTable(
                name: "Application",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_Job_PostedBy",
                table: "Jobs",
                newName: "IX_Jobs_PostedBy");

            migrationBuilder.RenameColumn(
                name: "IsSelected",
                table: "Interviews",
                newName: "IsComplete");

            migrationBuilder.RenameIndex(
                name: "IX_Interview_SchedulerId",
                table: "Interviews",
                newName: "IX_Interviews_SchedulerId");

            migrationBuilder.RenameIndex(
                name: "IX_Interview_InterviewerId",
                table: "Interviews",
                newName: "IX_Interviews_InterviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Interview_ApplicationId",
                table: "Interviews",
                newName: "IX_Interviews_ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_PostedBy",
                table: "Applications",
                newName: "IX_Applications_PostedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Application_JobId",
                table: "Applications",
                newName: "IX_Applications_JobId");

            migrationBuilder.AddColumn<int>(
                name: "SchedulerStatus",
                table: "Schedulers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Compensation",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PositionClosed",
                table: "Jobs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "SchedulerId",
                table: "Interviews",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<int>(
                name: "InterviewStatus",
                table: "Interviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsWithdrawn",
                table: "Applications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedulers",
                table: "Schedulers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_PostedBy",
                table: "Applications",
                column: "PostedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Applications_ApplicationId",
                table: "Interviews",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_AspNetUsers_InterviewerId",
                table: "Interviews",
                column: "InterviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Schedulers_SchedulerId",
                table: "Interviews",
                column: "SchedulerId",
                principalTable: "Schedulers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_PostedBy",
                table: "Jobs",
                column: "PostedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_PostedBy",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Applications_ApplicationId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_AspNetUsers_InterviewerId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Schedulers_SchedulerId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_PostedBy",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedulers",
                table: "Schedulers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SchedulerStatus",
                table: "Schedulers");

            migrationBuilder.DropColumn(
                name: "Compensation",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PositionClosed",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "InterviewStatus",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "IsWithdrawn",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Schedulers",
                newName: "Scheduler");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "Interviews",
                newName: "Interview");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_PostedBy",
                table: "Job",
                newName: "IX_Job_PostedBy");

            migrationBuilder.RenameColumn(
                name: "IsComplete",
                table: "Interview",
                newName: "IsSelected");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_SchedulerId",
                table: "Interview",
                newName: "IX_Interview_SchedulerId");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_InterviewerId",
                table: "Interview",
                newName: "IX_Interview_InterviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_ApplicationId",
                table: "Interview",
                newName: "IX_Interview_ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_PostedBy",
                table: "Application",
                newName: "IX_Application_PostedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_JobId",
                table: "Application",
                newName: "IX_Application_JobId");

            migrationBuilder.AddColumn<bool>(
                name: "IsSlotAccepted",
                table: "Scheduler",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "SchedulerId",
                table: "Interview",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Interview",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scheduler",
                table: "Scheduler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interview",
                table: "Interview",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Job_JobId",
                table: "Application",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_AspNetUsers_PostedBy",
                table: "Application",
                column: "PostedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Application_ApplicationId",
                table: "Interview",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_AspNetUsers_InterviewerId",
                table: "Interview",
                column: "InterviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Scheduler_SchedulerId",
                table: "Interview",
                column: "SchedulerId",
                principalTable: "Scheduler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_AspNetUsers_PostedBy",
                table: "Job",
                column: "PostedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
