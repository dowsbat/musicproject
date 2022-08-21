using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // se vuelve primara por tener lo necesario llevar ID y se INT
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),// a partir de net 6 los string no soportan null
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);// Crea el PK de la Tabla y lo toma del DB context
                });

            migrationBuilder.InsertData(
                table: "Genres", // Inserta la tabla y los inserta
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Rock", true },
                    { 2, "Jazz", true },
                    { 3, "Metal", true },
                    { 4, "Alternative", true },
                    { 5, "Disco", true },
                    { 6, "Blues", true },
                    { 7, "Latin", true },
                    { 8, "Reggae", true },
                    { 9, "Pop", true },
                    { 10, "Classical", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {// Por si quiero revertir la migracion
            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
