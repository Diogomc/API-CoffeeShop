using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoffeeShopApi.Models;


[Table("Categories")]
public class Category
{
    public Category()
    {
        Foods = new Collection<Foods>();
    }

    [Key]
    [Required]
    public int CategoryId { get; set; }
    [Required]
    [StringLength(60)]
    public string? CategoryName { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    [JsonIgnore]
    public ICollection<Foods> Foods { get; set; }

}
