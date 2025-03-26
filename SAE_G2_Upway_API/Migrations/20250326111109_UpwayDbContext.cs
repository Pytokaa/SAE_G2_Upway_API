using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAE_G2_Upway_API.Migrations
{
    /// <inheritdoc />
    public partial class UpwayDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "vel_typecadre",
                schema: "upway",
                table: "t_e_velo_vel",
                newName: "typecadre");

            migrationBuilder.RenameColumn(
                name: "vel_prixneuf",
                schema: "upway",
                table: "t_e_velo_vel",
                newName: "prixneuf");

            migrationBuilder.RenameColumn(
                name: "vel_poids",
                schema: "upway",
                table: "t_e_velo_vel",
                newName: "poids");

            migrationBuilder.RenameColumn(
                name: "vel_nbkms",
                schema: "upway",
                table: "t_e_velo_vel",
                newName: "nbkms");

            migrationBuilder.RenameColumn(
                name: "adr_ville",
                schema: "upway",
                table: "t_e_adresse_adr",
                newName: "ville");

            migrationBuilder.RenameColumn(
                name: "adr_rue",
                schema: "upway",
                table: "t_e_adresse_adr",
                newName: "rue");

            migrationBuilder.RenameColumn(
                name: "adr_cp",
                schema: "upway",
                table: "t_e_adresse_adr",
                newName: "cp");

            migrationBuilder.AlterColumn<int>(
                name: "vel_annee",
                schema: "upway",
                table: "t_e_velo_vel",
                type: "integer",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "rue",
                schema: "upway",
                table: "t_e_adresse_adr",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "typecadre",
                schema: "upway",
                table: "t_e_velo_vel",
                newName: "vel_typecadre");

            migrationBuilder.RenameColumn(
                name: "prixneuf",
                schema: "upway",
                table: "t_e_velo_vel",
                newName: "vel_prixneuf");

            migrationBuilder.RenameColumn(
                name: "poids",
                schema: "upway",
                table: "t_e_velo_vel",
                newName: "vel_poids");

            migrationBuilder.RenameColumn(
                name: "nbkms",
                schema: "upway",
                table: "t_e_velo_vel",
                newName: "vel_nbkms");

            migrationBuilder.RenameColumn(
                name: "ville",
                schema: "upway",
                table: "t_e_adresse_adr",
                newName: "adr_ville");

            migrationBuilder.RenameColumn(
                name: "rue",
                schema: "upway",
                table: "t_e_adresse_adr",
                newName: "adr_rue");

            migrationBuilder.RenameColumn(
                name: "cp",
                schema: "upway",
                table: "t_e_adresse_adr",
                newName: "adr_cp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "vel_annee",
                schema: "upway",
                table: "t_e_velo_vel",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "adr_rue",
                schema: "upway",
                table: "t_e_adresse_adr",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
