using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShopApi.Migrations
{
    /// <inheritdoc />
    public partial class MakeFoods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Foods(FoodName,Description,ImageUrl,Price,available,CategoryId)" +
                "VALUES('Espresso','A cup of espresso','espresso.jpg',2.99,1,1)");
            mb.Sql("INSERT INTO Foods(FoodName,Description,ImageUrl,Price,available,CategoryId)" +
                "VALUES('Strawberry Cake','A piece of delicious strawberry cake with cream','strawberryCake.jpg',5.99,1,2)");
            mb.Sql("INSERT INTO Foods(FoodName,Description,ImageUrl,Price,available,CategoryId)" +
                "VALUES('Soda Bread','A traditional irish bread','sodaBread.jpg',8.99,1,3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Foods");
        }
    }
}






