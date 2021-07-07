using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAdmin.API.Migrations
{
    public partial class Migration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyDate", "Description", "ProductStatus", "ProductType", "ShortName", "Value" },
                values: new object[,]
                {
                    { new Guid("01acf2fe-9220-447e-a3d1-f008e71a9423"), new DateTime(2011, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "apartamento con gran amplitud apesar de dimensiones teccnicas, paredes blancas y vista a las montañas", 0, 3, "apartamento en barrio alqueria", 111000000L },
                    { new Guid("5fd19bf5-e24d-4a51-849d-58e44e3c725c"), new DateTime(2012, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gran lote con casa casi lista para ser demolida y reconstruida", 0, 2, "Casa en alqueria la fragua", 222000000L },
                    { new Guid("513888e3-a5c8-4731-b19d-240623882d49"), new DateTime(2013, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Muebles de casa recien demolida listos para encontrar un nuevo hogar", 1, 0, "Muebles para casa", 33000000L },
                    { new Guid("3b300beb-3ef8-4426-b9c5-88eaf15ed981"), new DateTime(2014, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primer renault 6 de colombia con placas clasicas, naturalemnte en perfecto estado", 0, 1, "Renault 6 clasico", 44000000L },
                    { new Guid("9d125853-285b-4a7e-b795-f022c10fe326"), new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Linto apartamento solo habitado por una pareja de hermanos, grande y queda cerca a dos centros comerciales, el eden y multiplaza", 1, 3, "Apartamento calle 13 con boyaca", 555000000L },
                    { new Guid("895d042a-f4fe-4bb0-9c7a-e2cb773f9f1a"), new DateTime(2016, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fina a las afuera de bogota por el norte, solia estar dedicada a la industria lechera, gangazo", 0, 2, "Finca lechera", 660000000L },
                    { new Guid("a9f2d78a-3f24-4451-a113-e9e144034863"), new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hermosa camioneta gran vitara modelo 20 color rojo, la vendemos por que nos vamos del pais, oferta imperdible", 0, 1, "Camioneta gran vitara", 7000000L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
