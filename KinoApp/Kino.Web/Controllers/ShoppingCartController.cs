using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using Stripe;
using Kino.Services.Interface;

namespace Kino.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(this._shoppingCartService.GetShoppingCartInfo(userId));
        }



        public IActionResult DeleteProductFromShoppingCart(Guid id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._shoppingCartService.DeleteProductFromShoppingCart(userId, id);

            if (result)
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
            else
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
        }

        private Boolean Order()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._shoppingCartService.Order(userId);

            return result;
        }

        public IActionResult PayOrder(string stripeEmail, string stripeToken)
        {
            var customerService = new CustomerService();
            var chargeService = new ChargeService();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = this._shoppingCartService.GetShoppingCartInfo(userId);

            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = chargeService.Create(new ChargeCreateOptions
            {
                Amount = (Convert.ToInt32(order.TotalPrice) * 100),
                Description = "CinemaShop Application Payment",
                Currency = "mkd",
                Customer = customer.Id
            });

            if (charge.Status == "succeeded")
            {
                var result = this.Order();

                if (result != null)
                {
                    return RedirectToAction("Index", "ShoppingCart");
                }
                else
                {
                    return RedirectToAction("Index", "ShoppingCart");
                }
            }

            return RedirectToAction("Index", "ShoppingCart");
        }

    }
}
