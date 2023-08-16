namespace ProductManagementApi;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [Range(0, 9999999999, ErrorMessage = "Stock quantity is required and must be a non-negative value.")]
    public int StockQuantity { get; set; }

    [Required]
    [Range(0.01, 9999999999.999999, ErrorMessage = "Required field with a minimum value of 0.01.")]
    public decimal Price { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Product name is required and must be at least 3 characters long.")]
    public string Name { get; set; }
    [MaxLength(500, ErrorMessage = "Product description cannot exceed 500 characters.")]
    public string? Description { get; set; }
   
    public DateTime CreateDate { get; set; }
}