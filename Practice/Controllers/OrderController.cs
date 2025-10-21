using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using S7_ModelBinding_Validations.Models;

namespace S7_ModelBinding_Validations.Controllers;

public class OrderController : Controller
{
    [HttpPost("/order")]
    public IActionResult Create([Bind(nameof(Order.OrderDate), nameof(Order.TotalPrice), nameof(Order.Products))]Order order)
    {
        if (!ModelState.IsValid) {
            HttpContext.Response.StatusCode = 400;

            var errors =
                ModelState
                    .Where(m => m.Value?.ValidationState != ModelValidationState.Valid)
                    .ToDictionary(
                        entry => entry.Key,
                        entry => entry.Value!.Errors.Select(e => e.ErrorMessage).ToList()
                    );

            return Json(errors);
        }

        order.OrderId = new Random().Next(1, 99999);

        //return Json(new { OrderState = "Order Placed Successfully", OrderId = order.OrderId });
        return Json(new { OrderStatus = "Order Placed Successfully", OrderDetails = order });
    }
}
