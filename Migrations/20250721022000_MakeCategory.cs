using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShopApi.Migrations
{
    /// <inheritdoc />
    public partial class MakeCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categories (CategoryName, ImageUrl) VALUES ('Coffees', 'coffees.jpg')");
            mb.Sql("INSERT INTO Categories (CategoryName, ImageUrl) VALUES ('Cakes', 'cakes.jpg')");
            mb.Sql("INSERT INTO Categories (CategoryName, ImageUrl) VALUES ('Bakery', 'bakery.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM CATEGORIES");
        }
    }
}
