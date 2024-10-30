using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class DataEntryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "30bca869-beaf-45b1-844b-b84aa5aedbde");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "7187bfae-d8b7-458c-874b-85b0fa6ec79d");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "9734e2d9-f90b-445f-a9f6-20bbd15df99f");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "AspNetUserTokens",
            //    type: "nvarchar(128)",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LoginProvider",
            //    table: "AspNetUserTokens",
            //    type: "nvarchar(128)",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "CreatedAt",
            //    table: "AspNetUsers",
            //    type: "datetime2",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ProviderKey",
            //    table: "AspNetUserLogins",
            //    type: "nvarchar(128)",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LoginProvider",
            //    table: "AspNetUserLogins",
            //    type: "nvarchar(128)",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "DataEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelamin = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Kelurahan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kabupaten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodePos = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NoHP = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    KTPFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlamatLengkap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provinsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoRekeningTabungan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlamatEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JumlahPenghasilan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JumlahPermohonan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaksimalPermohonan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusPerkawinan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JumlahPenghasilanLainnya = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JangkaWaktu = table.Column<int>(type: "int", nullable: false),
                    TujuanPembiayaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NPWPFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlipGajiFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaInstansi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoInstansi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Golongan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasaKerja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NamaAtasan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlamatKantor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAngsuran = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cabang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JangkaWaktuPengajuan = table.Column<int>(type: "int", nullable: false),
                    Capem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DokumenChecklists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DokumenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEntryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DokumenChecklists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DokumenChecklists_DataEntries_DataEntryId",
                        column: x => x.DataEntryId,
                        principalTable: "DataEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DokumenChecklists_DataEntryId",
                table: "DokumenChecklists",
                column: "DataEntryId");
        }

        /// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "DokumenChecklists");

        //    migrationBuilder.DropTable(
        //        name: "DataEntries");

        //    migrationBuilder.AlterColumn<string>(
        //        name: "Name",
        //        table: "AspNetUserTokens",
        //        type: "nvarchar(450)",
        //        nullable: false,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(128)",
        //        oldMaxLength: 128);

        //    migrationBuilder.AlterColumn<string>(
        //        name: "LoginProvider",
        //        table: "AspNetUserTokens",
        //        type: "nvarchar(450)",
        //        nullable: false,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(128)",
        //        oldMaxLength: 128);

        //    migrationBuilder.AlterColumn<string>(
        //        name: "CreatedAt",
        //        table: "AspNetUsers",
        //        type: "nvarchar(max)",
        //        nullable: false,
        //        oldClrType: typeof(DateTime),
        //        oldType: "datetime2");

        //    migrationBuilder.AlterColumn<string>(
        //        name: "ProviderKey",
        //        table: "AspNetUserLogins",
        //        type: "nvarchar(450)",
        //        nullable: false,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(128)",
        //        oldMaxLength: 128);

        //    migrationBuilder.AlterColumn<string>(
        //        name: "LoginProvider",
        //        table: "AspNetUserLogins",
        //        type: "nvarchar(450)",
        //        nullable: false,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(128)",
        //        oldMaxLength: 128);

        //    migrationBuilder.InsertData(
        //        table: "AspNetRoles",
        //        columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
        //        values: new object[,]
        //        {
        //            { "30bca869-beaf-45b1-844b-b84aa5aedbde", null, "client", "client" },
        //            { "7187bfae-d8b7-458c-874b-85b0fa6ec79d", null, "admin", "admin" },
        //            { "9734e2d9-f90b-445f-a9f6-20bbd15df99f", null, "seller", "seller" }
        //        });
        //}
    }
}
