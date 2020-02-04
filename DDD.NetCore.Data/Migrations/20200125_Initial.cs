using System;
using System.Collections.Generic;
using System.Text;
using DDD.NetCore.Domain.Entities;
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
                    PkId = table.Column<int>(nullable: false),
                    DsNome = table.Column<string>(maxLength: 50, nullable: false),
                    VlTeorAlcoolico = table.Column<float>(type: "numeric(10,4)", nullable: false),
                    VlPreco = table.Column<float>(type: "numeric(12,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CERVEJA", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "TB_REVENDEDOR",
                columns: table => new
                {
                    PkId = table.Column<int>(nullable: false),
                    DsNome = table.Column<string>(maxLength: 70, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_REVENDEDOR", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "TB_CERVEJAREVENDEDOR",
                columns: table => new
                {
                    PkId = table.Column<int>(nullable: false),
                    FkCerveja = table.Column<int>(nullable: false),
                    FkRevendedor = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CERVEJAREVENDEDOR", x => x.PkId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "TB_CERVEJA");
            migrationBuilder.DropTable(name: "TB_REVENDEDOR");
            migrationBuilder.DropTable(name: "TB_CERVEJAREVENDEDOR");
        }
    }
}
