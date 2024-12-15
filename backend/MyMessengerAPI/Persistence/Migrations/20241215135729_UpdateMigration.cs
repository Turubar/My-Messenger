using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Avatars_AvatarId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_AvatarId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "AvatarId",
                table: "Profiles");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Avatars",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Avatars_ProfileId",
                table: "Avatars",
                column: "ProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Avatars_Profiles_ProfileId",
                table: "Avatars",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avatars_Profiles_ProfileId",
                table: "Avatars");

            migrationBuilder.DropIndex(
                name: "IX_Avatars_ProfileId",
                table: "Avatars");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Avatars");

            migrationBuilder.AddColumn<Guid>(
                name: "AvatarId",
                table: "Profiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AvatarId",
                table: "Profiles",
                column: "AvatarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Avatars_AvatarId",
                table: "Profiles",
                column: "AvatarId",
                principalTable: "Avatars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
