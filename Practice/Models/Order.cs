using System.ComponentModel.DataAnnotations;
using S7_ModelBinding_Validations.CustomValidators;
using S7_ModelBinding_Validations.Misc;

namespace S7_ModelBinding_Validations.Models;

public class Order : IValidatableObject
{
    [Display(Name = "Order ID")]
    public int? OrderId { get; set; }

    [Required(ErrorMessage = "{0} can't be blank")]
    [Display(Name = "Order Date")]
    public DateTime? OrderDate { get; set; }

    //[Required(ErrorMessage = "{0} is required")]
    [Display(Name = "Total Price")]
    [Range(1, double.MaxValue, ErrorMessage = "{0} should be a valid amount")]
    public double? TotalPrice { get; set; }

    [Products(1)]
    public List<Product> Products { get; set; }


    public Order () {
        Products = new List<Product>();
    }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
        //yield return new ValidationResult(
        //    $"display name !!! {validationContext.DisplayName}",
        //    new[] { "OrderId" }
        //);

        object[] memberNames = new[] { nameof(TotalPrice) };

        if (TotalPrice is null) {
            yield return new ValidationResult(
                validationContext.FormatErrorMessage("{0} is required", memberNames),
                new[] { nameof(TotalPrice) }
            );

            yield break;
        }


        double? calcTotal = Products.Sum(p => p.Price * p.Quantity);

        memberNames = [nameof(TotalPrice), TotalPrice, calcTotal!];

        if (calcTotal != TotalPrice)
            yield return new ValidationResult(
                validationContext.FormatErrorMessage("{0} ({1}) doesn't match with the actual sum of product prices ({2})", memberNames),
                new[] { nameof(TotalPrice) }
            );
    }
}
