using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class AddBewerber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into BewerberSet (Vorname, Discriminator) Values ('Marcor', 'Bewerber')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
