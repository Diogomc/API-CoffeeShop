using CoffeeShopApi.Context;
using CoffeeShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Controllers;
[ApiController]
[Route("[Controller]")]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> Get()
    {
        var categories = _context.Categories;

        if (categories is null)
        {
            return NotFound("Categories not found");
        }

        return categories;
    }

    [HttpGet("{id:int}", Name = "TakeCategory")]
    public ActionResult Get(int id)
    {
        var categories = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

        if (categories is null)
        {
            return NotFound("Category not found");
        }

        return Ok(categories);
    }

    [HttpDelete("{id:int}")]

    public ActionResult Delete(int id)
    {
        var categories = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

        if (categories is null)
        {
            return NotFound("Category not found");
        }
        _context.Categories.Remove(categories);
        _context.SaveChanges();

        return Ok(categories);

    }

    [HttpPost]
    public ActionResult Post(Category category)
    {
        if (category is null)
        {
            return BadRequest("Category not found");
        }
        _context.Categories.Add(category);
        _context.SaveChanges();

        return new CreatedAtRouteResult("TakeCategory", new { id = category.CategoryId }, category);

    }

    [HttpPut("{id:int}")]

    public ActionResult Put (int id, Category category)
    {
        if(id != category.CategoryId)
        {
            return NotFound("Category was not found");
        }

        _context.Entry(category).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(category);
    }


}
