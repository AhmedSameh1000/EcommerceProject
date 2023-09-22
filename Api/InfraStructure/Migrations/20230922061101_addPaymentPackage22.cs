using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class addPaymentPackage22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPackage_AspNetUsers_ReciverId",
                table: "PaymentPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPackage_AspNetUsers_UserId",
                table: "PaymentPackage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPackage",
                table: "PaymentPackage");

            migrationBuilder.RenameTable(
                name: "PaymentPackage",
                newName: "PaymentPackages");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPackage_UserId",
                table: "PaymentPackages",
                newName: "IX_PaymentPackages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPackage_ReciverId",
                table: "PaymentPackages",
                newName: "IX_PaymentPackages_ReciverId");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PaymentPackages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage",
                table: "PaymentPackages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "PaymentPackages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "PaymentPackages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PaymentPackages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PaymentPackages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "PaymentPackages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "PaymentPackages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "PaymentPackages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPackages",
                table: "PaymentPackages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPackages_AspNetUsers_ReciverId",
                table: "PaymentPackages",
                column: "ReciverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPackages_AspNetUsers_UserId",
                table: "PaymentPackages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPackages_AspNetUsers_ReciverId",
                table: "PaymentPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPackages_AspNetUsers_UserId",
                table: "PaymentPackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPackages",
                table: "PaymentPackages");

            migrationBuilder.RenameTable(
                name: "PaymentPackages",
                newName: "PaymentPackage");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPackages_UserId",
                table: "PaymentPackage",
                newName: "IX_PaymentPackage_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPackages_ReciverId",
                table: "PaymentPackage",
                newName: "IX_PaymentPackage_ReciverId");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PaymentPackage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductImage",
                table: "PaymentPackage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "PaymentPackage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "PaymentPackage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PaymentPackage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PaymentPackage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "PaymentPackage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "PaymentPackage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "PaymentPackage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPackage",
                table: "PaymentPackage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPackage_AspNetUsers_ReciverId",
                table: "PaymentPackage",
                column: "ReciverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPackage_AspNetUsers_UserId",
                table: "PaymentPackage",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
