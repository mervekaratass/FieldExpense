using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                   
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExpenseCategoryId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseRequests_ExpenseCategories_ExpenseCategoryId",
                        column: x => x.ExpenseCategoryId,
                        principalTable: "ExpenseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpenseRequests_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpenseRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseRequestId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionStatus = table.Column<int>(type: "int", nullable: false),
                    BankReferenceCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankTransactions_ExpenseRequests_ExpenseRequestId",
                        column: x => x.ExpenseRequestId,
                        principalTable: "ExpenseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Personel", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "FirstName", "IBAN", "LastName", "PasswordHash", "PasswordSalt", "Phone", "RoleId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ayse@gmail.com", "Ayşe", "TR480010200438320021981234", "Karamanlı", new byte[] { 125, 77, 57, 201, 162, 177, 220, 32, 208, 50, 123, 66, 137, 47, 71, 12, 169, 3, 233, 9, 53, 89, 38, 114, 104, 121, 190, 138, 116, 253, 226, 243, 206, 152, 98, 122, 249, 131, 135, 43, 61, 122, 222, 155, 239, 189, 173, 183, 63, 132, 218, 29, 36, 197, 214, 89, 240, 43, 89, 27, 109, 62, 80, 117 }, new byte[] { 202, 177, 188, 92, 106, 56, 116, 83, 160, 44, 8, 42, 73, 57, 232, 55, 41, 168, 189, 157, 87, 208, 21, 137, 89, 244, 12, 91, 154, 203, 110, 65, 130, 104, 137, 120, 32, 192, 31, 132, 154, 26, 19, 95, 144, 33, 50, 97, 109, 118, 92, 61, 149, 45, 102, 213, 232, 1, 121, 215, 137, 67, 157, 18, 171, 105, 239, 222, 228, 243, 239, 38, 133, 228, 18, 195, 153, 98, 114, 6, 61, 210, 163, 45, 230, 188, 38, 112, 107, 100, 55, 77, 26, 243, 88, 57, 76, 136, 189, 47, 158, 125, 62, 191, 96, 215, 183, 200, 142, 200, 40, 76, 178, 47, 132, 54, 52, 188, 199, 44 }, "1234567890", 1, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "murat@gmail.com", "Murat", "TR330006100519786457841234", "Karamanlı", new byte[] { 125, 77, 57, 201, 162, 177, 220, 32, 208, 50, 123, 66, 137, 47, 71, 12, 169, 3, 233, 9, 53, 89, 38, 114, 104, 121, 190, 138, 116, 253, 226, 243, 206, 152, 98, 122, 249, 131, 135, 43, 61, 122, 222, 155, 239, 189, 173, 183, 63, 132, 218, 29, 36, 197, 214, 89, 240, 43, 89, 27, 109, 62, 80, 117 }, new byte[] { 202, 177, 188, 92, 106, 56, 116, 83, 160, 44, 8, 42, 73, 57, 232, 55, 41, 168, 189, 157, 87, 208, 21, 137, 89, 244, 12, 91, 154, 203, 110, 65, 130, 104, 137, 120, 32, 192, 31, 132, 154, 26, 19, 95, 144, 33, 50, 97, 109, 118, 92, 61, 149, 45, 102, 213, 232, 1, 121, 215, 137, 67, 157, 18, 171, 105, 239, 222, 228, 243, 239, 38, 133, 228, 18, 195, 153, 98, 114, 6, 61, 210, 163, 45, 230, 188, 38, 112, 107, 100, 55, 77, 26, 243, 88, 57, 76, 136, 189, 47, 158, 125, 62, 191, 96, 215, 183, 200, 142, 200, 40, 76, 178, 47, 132, 54, 52, 188, 199, 44 }, "0987654321", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_BankReferenceCode",
                table: "BankTransactions",
                column: "BankReferenceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_ExpenseRequestId",
                table: "BankTransactions",
                column: "ExpenseRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRequests_ExpenseCategoryId",
                table: "ExpenseRequests",
                column: "ExpenseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRequests_PaymentMethodId",
                table: "ExpenseRequests",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRequests_UserId",
                table: "ExpenseRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "ExpenseRequests");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
