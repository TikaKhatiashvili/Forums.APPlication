using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Forums.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Namefour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("359e8684-ea02-41b2-b2a7-e2328ff59cfc"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("83556f70-60f4-41b1-bc5a-d69bedf5b277"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("29738ebb-795a-4175-be6d-7804d7da6acc"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("7bef7d61-bd07-4bd4-b751-750e2a49c5d7"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("d992b1b9-3548-4311-a31c-e6a802865c6a"));

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CommentsAreAllowed", "Content", "CreatedDate", "ImageUrl", "LastCommentDate", "Title" },
                values: new object[,]
                {
                    { new Guid("1ae2f862-c948-458e-88dd-b1ac4e047648"), true, "This is the content of the second topic.", new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 2, 2, 13, 16, 0, 722, DateTimeKind.Local).AddTicks(2273), "Second Topic" },
                    { new Guid("1c03c62e-b299-483a-ac61-cfa2fa0878c9"), true, "This is the content of the first topic.", new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 2, 2, 13, 16, 0, 722, DateTimeKind.Local).AddTicks(2271), "First Topic" },
                    { new Guid("922477dc-b396-439d-aefa-8a251a671c43"), true, "This is the content of the third topic.", new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 2, 2, 13, 16, 0, 722, DateTimeKind.Local).AddTicks(2275), "Third Topic" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentDate", "Content", "TopicId" },
                values: new object[,]
                {
                    { new Guid("c5bd2734-c5ba-4928-994b-12260cac0297"), new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is the content of the SECOND COMENT.", new Guid("1ae2f862-c948-458e-88dd-b1ac4e047648") },
                    { new Guid("d8aac92c-411a-4b8e-af15-8cb9a70e7044"), new DateTime(2026, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is the content of the first COMENT.", new Guid("1c03c62e-b299-483a-ac61-cfa2fa0878c9") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c5bd2734-c5ba-4928-994b-12260cac0297"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d8aac92c-411a-4b8e-af15-8cb9a70e7044"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("922477dc-b396-439d-aefa-8a251a671c43"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("1ae2f862-c948-458e-88dd-b1ac4e047648"));

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: new Guid("1c03c62e-b299-483a-ac61-cfa2fa0878c9"));

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CommentsAreAllowed", "Content", "CreatedDate", "ImageUrl", "LastCommentDate", "Title" },
                values: new object[,]
                {
                    { new Guid("29738ebb-795a-4175-be6d-7804d7da6acc"), true, "This is the content of the third topic.", new DateTime(2026, 1, 30, 15, 18, 36, 492, DateTimeKind.Local).AddTicks(9647), null, new DateTime(2026, 1, 30, 15, 18, 36, 492, DateTimeKind.Local).AddTicks(9648), "Third Topic" },
                    { new Guid("7bef7d61-bd07-4bd4-b751-750e2a49c5d7"), true, "This is the content of the first topic.", new DateTime(2026, 1, 30, 15, 18, 36, 492, DateTimeKind.Local).AddTicks(9641), null, new DateTime(2026, 1, 30, 15, 18, 36, 492, DateTimeKind.Local).AddTicks(9643), "First Topic" },
                    { new Guid("d992b1b9-3548-4311-a31c-e6a802865c6a"), true, "This is the content of the second topic.", new DateTime(2026, 1, 30, 15, 18, 36, 492, DateTimeKind.Local).AddTicks(9645), null, new DateTime(2026, 1, 30, 15, 18, 36, 492, DateTimeKind.Local).AddTicks(9646), "Second Topic" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentDate", "Content", "TopicId" },
                values: new object[,]
                {
                    { new Guid("359e8684-ea02-41b2-b2a7-e2328ff59cfc"), new DateTime(2026, 1, 31, 15, 18, 36, 492, DateTimeKind.Local).AddTicks(9732), "This is the content of the first COMENT.", new Guid("7bef7d61-bd07-4bd4-b751-750e2a49c5d7") },
                    { new Guid("83556f70-60f4-41b1-bc5a-d69bedf5b277"), new DateTime(2026, 2, 1, 15, 18, 36, 492, DateTimeKind.Local).AddTicks(9738), "This is the content of the SECOND COMENT.", new Guid("d992b1b9-3548-4311-a31c-e6a802865c6a") }
                });
        }
    }
}
