using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMovementTypeToEnumAndCreateTransference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transference_Billeteras_destinationWalletId",
                table: "Transference");

            migrationBuilder.DropForeignKey(
                name: "FK_Transference_Billeteras_sourceWalletId",
                table: "Transference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transference",
                table: "Transference");

            migrationBuilder.RenameTable(
                name: "Transference",
                newName: "Transferences");

            migrationBuilder.RenameIndex(
                name: "IX_Transference_sourceWalletId",
                table: "Transferences",
                newName: "IX_Transferences_sourceWalletId");

            migrationBuilder.RenameIndex(
                name: "IX_Transference_destinationWalletId",
                table: "Transferences",
                newName: "IX_Transferences_destinationWalletId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transferences",
                table: "Transferences",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferences_Billeteras_destinationWalletId",
                table: "Transferences",
                column: "destinationWalletId",
                principalTable: "Billeteras",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferences_Billeteras_sourceWalletId",
                table: "Transferences",
                column: "sourceWalletId",
                principalTable: "Billeteras",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferences_Billeteras_destinationWalletId",
                table: "Transferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferences_Billeteras_sourceWalletId",
                table: "Transferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transferences",
                table: "Transferences");

            migrationBuilder.RenameTable(
                name: "Transferences",
                newName: "Transference");

            migrationBuilder.RenameIndex(
                name: "IX_Transferences_sourceWalletId",
                table: "Transference",
                newName: "IX_Transference_sourceWalletId");

            migrationBuilder.RenameIndex(
                name: "IX_Transferences_destinationWalletId",
                table: "Transference",
                newName: "IX_Transference_destinationWalletId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transference",
                table: "Transference",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transference_Billeteras_destinationWalletId",
                table: "Transference",
                column: "destinationWalletId",
                principalTable: "Billeteras",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transference_Billeteras_sourceWalletId",
                table: "Transference",
                column: "sourceWalletId",
                principalTable: "Billeteras",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
