namespace SportsStore.Models;

public class Product
{
    [Key]
    public long PorductId { get; set; }

    [Required]
    [DisplayName("Product Name")]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Price { get; set; }
}