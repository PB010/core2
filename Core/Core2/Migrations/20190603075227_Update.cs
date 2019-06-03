using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core2.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false),
                    DateOfDeath = table.Column<DateTimeOffset>(nullable: true),
                    Genre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "DateOfDeath", "FirstName", "Genre", "LastName" },
                values: new object[,]
                {
                    { new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"), new DateTimeOffset(new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Stephen", "Horror", "King" },
                    { new Guid("76053df4-6687-4353-8937-b45556748abe"), new DateTimeOffset(new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "George", "Fantasy", "RR Martin" },
                    { new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb3"), new DateTimeOffset(new DateTime(1960, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "Neil", "Fantasy", "Gaiman" },
                    { new Guid("578359b7-1967-41d6-8b87-64ab7605587e"), new DateTimeOffset(new DateTime(1958, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Tom", "Various", "Lanoye" },
                    { new Guid("f74d6899-9ed2-4137-9876-66b070553f8f"), new DateTimeOffset(new DateTime(1952, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), null, "Douglas", "Science fiction", "Adams" },
                    { new Guid("a1da1d8e-1988-4634-b538-a01709477b77"), new DateTimeOffset(new DateTime(1974, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Jens", "Thriller", "Lapidus" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"), new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"), "The Shining is a horror novel by American author Stephen King. Published in 1977, it is King's third published novel and first hardback bestseller: the success of the book firmly established King as a preeminent author in the horror genre. ", "The Shining" },
                    { new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"), new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"), "Misery is a 1987 psychological horror novel by Stephen King. This novel was nominated for the World Fantasy Award for Best Novel in 1988, and was later made into a Hollywood film and an off-Broadway play of the same name.", "Misery" },
                    { new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"), new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"), "It is a 1986 horror novel by American author Stephen King. The story follows the exploits of seven children as they are terrorized by the eponymous being, which exploits the fears and phobias of its victims in order to disguise itself while hunting its prey. 'It' primarily appears in the form of a clown in order to attract its preferred prey of young children.", "It" },
                    { new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"), new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"), "The Stand is a post-apocalyptic horror/fantasy novel by American author Stephen King. It expands upon the scenario of his earlier short story 'Night Surf' and outlines the total breakdown of society after the accidental release of a strain of influenza that had been modified for biological warfare causes an apocalyptic pandemic which kills off the majority of the world's human population.", "The Stand" },
                    { new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"), new Guid("76053df4-6687-4353-8937-b45556748abe"), "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin. It was first published on August 1, 1996.", "A Game of Thrones" },
                    { new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"), new Guid("76053df4-6687-4353-8937-b45556748abe"), "Forthcoming 6th novel in A Song of Ice and Fire.", "The Winds of Winter" },
                    { new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"), new Guid("76053df4-6687-4353-8937-b45556748abe"), "A Dance with Dragons is the fifth of seven planned novels in the epic fantasy series A Song of Ice and Fire by American author George R. R. Martin.", "A Dance with Dragons" },
                    { new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"), new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb3"), "American Gods is a Hugo and Nebula Award-winning novel by English author Neil Gaiman. The novel is a blend of Americana, fantasy, and various strands of ancient and modern mythology, all centering on the mysterious and taciturn Shadow.", "American Gods" },
                    { new Guid("01457142-358f-495f-aafa-fb23de3d67e9"), new Guid("578359b7-1967-41d6-8b87-64ab7605587e"), "Good-natured and often humorous, Speechless is at times a 'song of curses', as Lanoye describes the conflicts with his beloved diva of a mother and her brave struggle with decline and death.", "Speechless" },
                    { new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"), new Guid("f74d6899-9ed2-4137-9876-66b070553f8f"), "The Hitchhiker's Guide to the Galaxy is the first of five books in the Hitchhiker's Guide to the Galaxy comedy science fiction 'trilogy' by Douglas Adams.", "The Hitchhiker's Guide to the Galaxy" },
                    { new Guid("1325360c-8253-473a-a20f-55c269c20407"), new Guid("a1da1d8e-1988-4634-b538-a01709477b77"), "Easy Money or Snabba cash is a novel from 2006 by Jens Lapidus. It has been a success in term of sales, and the paperback was the fourth best seller of Swedish novels in 2007.", "Easy Money" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
