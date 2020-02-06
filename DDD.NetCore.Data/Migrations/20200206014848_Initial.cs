using Microsoft.EntityFrameworkCore.Migrations;

namespace DDD.NetCore.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CERVEJA",
                columns: table => new
                {
                    PK_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_NOME = table.Column<string>(maxLength: 50, nullable: false),
                    VL_TEORALCOOLICO = table.Column<float>(nullable: false),
                    VL_PRECO = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CERVEJA", x => x.PK_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_REVENDEDOR",
                columns: table => new
                {
                    PK_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_NOME = table.Column<string>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_REVENDEDOR", x => x.PK_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CERVEJA");

            migrationBuilder.DropTable(
                name: "TB_REVENDEDOR");
        }
    }
}
