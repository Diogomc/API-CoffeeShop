using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoffeeShopApi.Models;

[Table("Foods")]
public class Foods
{
    [Key]
    [Required]
    public int FoodId { get; set; }
    [Required]
    [StringLength(60)]
    public string? FoodName { get; set; }
    [Required]
    [StringLength(220)]
    public string? Description { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }
    [Required]
    [Range(1,100)]
    public decimal Price { get; set; }
    [Required]
    public bool available { get; set; }

    public int CategoryId { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }
}
