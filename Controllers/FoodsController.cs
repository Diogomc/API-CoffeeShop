using CoffeeShopApi.Context;
using CoffeeShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Controllers;
[ApiController]
[Route("[Controller]")]
public class FoodsController : ControllerBase
{
    private readonly AppDbContext _context;

    public FoodsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Foods>> Get()
    {
        var foods = _context.Foods;

        if (foods is null)
        {
            return NotFound("Produtos não encontrados");
        }

        return foods.ToList();
    }

    [HttpGet("{id:int}", Name = "TakeFood")]

    public ActionResult<Foods> GetFoodId(int id)
    {
        var foods = _context.Foods.FirstOrDefault(f => f.FoodId == id);

        if (foods is null)
        {
            return NotFound();
        }

        return foods;
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var foods = _context.Foods.FirstOrDefault(f => f.FoodId == id);
        if (id != foods.FoodId)
        {
            return NotFound("Foods not found");
        }
        _context.Foods.Remove(foods);
        _context.SaveChanges();

        return Ok(foods);
    }

    [HttpPost]

    public ActionResult Post(Foods food)
    {
        if (food is null)
        {
            return BadRequest("Food not found");
        }
        _context.Foods.Add(food);
        _context.SaveChanges();

        return new CreatedAtRouteResult("TakeFood", 
            new { id = food.FoodId }, food);

    }

    [HttpPut("{id:int}")]
    public ActionResult Put (int id, Foods food)
    {
        if(id != food.FoodId)
        {
            return NotFound("Food not found");
        }
        _context.Entry(food).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(food);
    }

}
