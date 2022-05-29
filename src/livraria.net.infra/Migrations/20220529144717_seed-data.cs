using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace livraria.net.infra.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, 75, new DateTime(2022, 5, 29, 11, 47, 17, 264, DateTimeKind.Local).AddTicks(4759), "Stephen King" },
                    { 2, 49, new DateTime(2022, 5, 29, 11, 47, 17, 265, DateTimeKind.Local).AddTicks(6385), "Joe Hill" },
                    { 3, 57, new DateTime(2022, 5, 29, 11, 47, 17, 265, DateTimeKind.Local).AddTicks(6535), "Dan Brown" },
                    { 4, 72, new DateTime(2022, 5, 29, 11, 47, 17, 265, DateTimeKind.Local).AddTicks(6537), "Ken Follett" },
                    { 5, 89, new DateTime(2022, 5, 29, 11, 47, 17, 265, DateTimeKind.Local).AddTicks(6538), "Sidney Sheldon" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Code", "CreatedAt", "FundationDate", "Name" },
                values: new object[,]
                {
                    { 1, "1111", new DateTime(2022, 5, 29, 11, 47, 17, 269, DateTimeKind.Local).AddTicks(6614), new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arqueiro" },
                    { 2, "2222", new DateTime(2022, 5, 29, 11, 47, 17, 277, DateTimeKind.Local).AddTicks(2686), new DateTime(1940, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Record" },
                    { 3, "3333", new DateTime(2022, 5, 29, 11, 47, 17, 277, DateTimeKind.Local).AddTicks(2741), new DateTime(1986, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suma" },
                    { 4, "4444", new DateTime(2022, 5, 29, 11, 47, 17, 277, DateTimeKind.Local).AddTicks(2749), new DateTime(1975, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocco" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Birthdate", "CreatedAt", "Email", "Gender", "Name", "Password", "Username" },
                values: new object[] { 1, 28, new DateTime(1993, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 29, 11, 47, 17, 278, DateTimeKind.Local).AddTicks(7691), "isabelabatista@livraria.net", 2, "Isabela Batista", "42119ca2398640f1a0322652cd91876f", "IsabelaBatista" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Chapters", "CreatedAt", "Isbn", "Name", "Pages", "PublisherId", "UserId" },
                values: new object[,]
                {
                    { 4, 2, 12, new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3262), "978-8580417135", "Mestre das chamas", 592, 1, null },
                    { 5, 2, 12, new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3263), "978-8595083219", "Tempo estranho", 448, 1, null },
                    { 6, 2, 12, new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3265), "978-8599296134", "A estrada da noite", 256, 1, null },
                    { 10, 3, 12, new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3270), "978-9722520508", "Anjos e demônios", 480, 1, null },
                    { 11, 3, 12, new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3271), "978-6555651041", "O código Da Vinci", 560, 1, null },
                    { 1, 5, 12, new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(1868), "9780688002206", "O Outro Lado da Meia-noite", 598, 2, null },
                    { 2, 5, 12, new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3255), "978-85-01-09431-5", "Um estranho no espelho", 352, 2, null },
                    { 3, 5, 12, new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3260), "978-85-01-09400-1", "O reverso da medalha", 592, 2, null },
                    { 7, 1, 12, new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3266), "978-8581050546", "A dança da morte", 1248, 3, null },
                    { 8, 1, 12, new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3268), "978-8581050485", "O iluminado", 464, 3, null },
                    { 9, 1, 12, new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3269), "978-8581052434", "Doutor sono", 480, 3, null },
                    { 12, 4, 12, new DateTime(2022, 5, 29, 11, 47, 17, 268, DateTimeKind.Local).AddTicks(3273), "978-8532527691", "Os pilares da terra", 944, 4, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
