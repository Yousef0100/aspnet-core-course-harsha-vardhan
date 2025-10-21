using S7_ModelBinding_Validations.Models;
using System.ComponentModel.DataAnnotations;

namespace S7_ModelBinding_Validations.CustomValidators;

public class ProductsAttribute : ValidationAttribute
{
    private readonly int _minProducts;

    public ProductsAttribute([Range(1, 10)]int minProducts = 1)
    {
        _minProducts = minProducts;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        List<Product> products = (value as List<Product>)!;

        if (products is null)
            return new ValidationResult($"{validationContext.DisplayName} can't be null or empty");

        products.RemoveAll(p => p is null);

        if (products.Count < _minProducts)
            return new ValidationResult($"{validationContext.DisplayName} must containt at least {_minProducts} product{(_minProducts == 1 ? "" : "s")}");

        return ValidationResult.Success;
    }

    //public override bool IsValid(object? value)
    //{

    //    //var products = value as List<Models.Product>;
    //    //if (products == null || products.Count == 0)
    //    //{
    //    //    ErrorMessage = "At least one product is required.";
    //    //    return false;
    //    //}
    //    //foreach (var product in products)
    //    //{
    //    //    if (product.Quantity <= 0)
    //    //    {
    //    //        ErrorMessage = "Product quantity must be greater than zero.";
    //    //        return false;
    //    //    }
    //    //    if (product.Price <= 0)
    //    //    {
    //    //        ErrorMessage = "Product price must be greater than zero.";
    //    //        return false;
    //    //    }
    //    //}
    //    //return true;
    //}
}
