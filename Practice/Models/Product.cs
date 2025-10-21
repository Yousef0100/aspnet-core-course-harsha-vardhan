using System.ComponentModel.DataAnnotations;

namespace S7_ModelBinding_Validations.Models;

public class Product
{
    [Display(Name = "Product ID")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Range(0, double.MaxValue, ErrorMessage = "{0} should be a valid amount")]
    [Display(Name = "Product Price")]
    public double? Price { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} should be at least {1}")]
    [Display(Name = "Product Quantity")]
    public int Quantity { get; set; }
}
