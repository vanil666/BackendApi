using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApi.Migrations
{
    /// <inheritdoc />
    public partial class CA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CarCateg__19093A2B04FC472C", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK__CarCatego__Paren__59FA5E80",
                        column: x => x.ParentCategoryID,
                        principalTable: "CarCategories",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CCAC714EEAE8", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsExchangeable = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Listings__BF3EBEF04AC97539", x => x.ListingID);
                    table.ForeignKey(
                        name: "FK__Listings__UserID__3D5E1FD2",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserReviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewerID = table.Column<int>(type: "int", nullable: false),
                    ReviewedUserID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserRevi__74BC79AEAA5E7EED", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK__UserRevie__Revie__52593CB8",
                        column: x => x.ReviewerID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__UserRevie__Revie__534D60F1",
                        column: x => x.ReviewedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingID = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cars__68A0340E987F0CA0", x => x.CarID);
                    table.ForeignKey(
                        name: "FK__Cars__ListingID__403A8C7D",
                        column: x => x.ListingID,
                        principalTable: "Listings",
                        principalColumn: "ListingID");
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ListingID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Favorite__CE74FAF5E442F3AA", x => x.FavoriteID);
                    table.ForeignKey(
                        name: "FK__Favorites__Listi__4D94879B",
                        column: x => x.ListingID,
                        principalTable: "Listings",
                        principalColumn: "ListingID");
                    table.ForeignKey(
                        name: "FK__Favorites__UserI__4CA06362",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ListingCategories",
                columns: table => new
                {
                    ListingCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ListingC__CEC5D22908B635D0", x => x.ListingCategoryID);
                    table.ForeignKey(
                        name: "FK__ListingCa__Categ__5DCAEF64",
                        column: x => x.CategoryID,
                        principalTable: "CarCategories",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK__ListingCa__Listi__5CD6CB2B",
                        column: x => x.ListingID,
                        principalTable: "Listings",
                        principalColumn: "ListingID");
                });

            migrationBuilder.CreateTable(
                name: "ListingImages",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingID = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ListingI__7516F4ECDFB0D065", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK__ListingIm__Listi__4316F928",
                        column: x => x.ListingID,
                        principalTable: "Listings",
                        principalColumn: "ListingID");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingID = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__E7FEA477E1DBAD69", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK__Locations__Listi__5629CD9C",
                        column: x => x.ListingID,
                        principalTable: "Listings",
                        principalColumn: "ListingID");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderID = table.Column<int>(type: "int", nullable: false),
                    ReceiverID = table.Column<int>(type: "int", nullable: false),
                    ListingID = table.Column<int>(type: "int", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Messages__C87C037C1C003C8E", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK__Messages__Listin__48CFD27E",
                        column: x => x.ListingID,
                        principalTable: "Listings",
                        principalColumn: "ListingID");
                    table.ForeignKey(
                        name: "FK__Messages__Receiv__47DBAE45",
                        column: x => x.ReceiverID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Messages__Sender__46E78A0C",
                        column: x => x.SenderID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCategories_ParentCategoryID",
                table: "CarCategories",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "UQ__CarCateg__8517B2E010E38D26",
                table: "CarCategories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ListingID",
                table: "Cars",
                column: "ListingID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ListingID",
                table: "Favorites",
                column: "ListingID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserID",
                table: "Favorites",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ListingCategories_CategoryID",
                table: "ListingCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ListingCategories_ListingID",
                table: "ListingCategories",
                column: "ListingID");

            migrationBuilder.CreateIndex(
                name: "IX_ListingImages_ListingID",
                table: "ListingImages",
                column: "ListingID");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_UserID",
                table: "Listings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ListingID",
                table: "Locations",
                column: "ListingID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ListingID",
                table: "Messages",
                column: "ListingID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverID",
                table: "Messages",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderID",
                table: "Messages",
                column: "SenderID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_ReviewedUserID",
                table: "UserReviews",
                column: "ReviewedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_ReviewerID",
                table: "UserReviews",
                column: "ReviewerID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534F47513C1",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "ListingCategories");

            migrationBuilder.DropTable(
                name: "ListingImages");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "UserReviews");

            migrationBuilder.DropTable(
                name: "CarCategories");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
