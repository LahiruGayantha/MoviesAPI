using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAPI.Migrations
{
    public partial class Identity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Adventure" },
                    { 5, "Animation" },
                    { 6, "Drama" },
                    { 7, "Romance" },
                    { 1, "Thriller" },
                    { 2, "Horror" },
                    { 3, "Crime" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Image", "IsShowing", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 6, null, false, new DateTime(2020, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greed" },
                    { 5, null, false, new DateTime(2020, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma" },
                    { 4, null, false, new DateTime(2020, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sonic the Hedgehog" },
                    { 3, null, false, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers: Infinity Wars" },
                    { 2, null, true, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers: Endgame" },
                    { 1, null, true, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers: X-Men" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Biography", "DateOfBirth", "Name", "Picture" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1965, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Cruise", null },
                    { 2, null, new DateTime(1985, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Larry Page", null },
                    { 3, null, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ronald Ragan", null },
                    { 4, null, new DateTime(1990, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Van Dam", null },
                    { 5, null, new DateTime(1962, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jim Carrey", null },
                    { 6, null, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Downey Jr.", null },
                    { 7, null, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris Evans", null }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "MovieId", "PersonId", "Charactor", "Order" },
                values: new object[,]
                {
                    { 3, 7, "Steve Rogers", 2 },
                    { 3, 6, "Tony Stark", 1 },
                    { 2, 6, "Tony Stark", 1 },
                    { 4, 5, "Dr. Ivo Robotnik", 1 },
                    { 1, 2, "Steve Rogers", 2 },
                    { 1, 1, "Tony Stark", 1 },
                    { 2, 7, "Steve Rogers", 2 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 7, 6 },
                    { 6, 6 },
                    { 7, 5 },
                    { 4, 4 },
                    { 4, 3 },
                    { 6, 3 },
                    { 4, 2 },
                    { 6, 2 },
                    { 4, 1 },
                    { 6, 5 },
                    { 6, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "MovieId", "PersonId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "MovieId", "PersonId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "MovieId", "PersonId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "MovieId", "PersonId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "MovieId", "PersonId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "MovieId", "PersonId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "MovieId", "PersonId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
