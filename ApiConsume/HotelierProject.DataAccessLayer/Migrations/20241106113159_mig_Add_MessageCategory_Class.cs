using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelierProject.DataAccessLayer.Migrations
{
    public partial class mig_Add_MessageCategory_Class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageCategoryId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MessageCategory",
                columns: table => new
                {
                    MessageCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageCategory", x => x.MessageCategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MessageCategoryId",
                table: "Contacts",
                column: "MessageCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_MessageCategory_MessageCategoryId",
                table: "Contacts",
                column: "MessageCategoryId",
                principalTable: "MessageCategory",
                principalColumn: "MessageCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_MessageCategory_MessageCategoryId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "MessageCategory");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_MessageCategoryId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "MessageCategoryId",
                table: "Contacts");
        }
    }
}
