using NQH_project2_2210900105.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace NQH_project2_2210900105.Controllers
{
    public class CartController : Controller
    {
        private webcuahangthethaoEntities db = new webcuahangthethaoEntities();

        private List<CartItem> GetCart()
        {
            var cart = Session["Cart"] as List<CartItem>;
            if (cart == null)
            {
                cart = new List<CartItem>();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ActionResult AddToCart(int? id) // Make 'id' nullable
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.PRODUCT.Find(id.Value); // Use 'id.Value' to get the actual integer value
            if (product == null)
            {
                return HttpNotFound();
            }

            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(p => p.ProductId == id.Value);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.product_id,
                    ProductName = product.product_name,
                    ProductPrice = product.product_price,
                    Quantity = 1,
                    ProductImage = product.product_image
                });
            }

            return RedirectToAction("Index", "Cart");
        }


        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }
        public ActionResult Checkout()
        {
            var cart = GetCart(); // Retrieves cart from the session

            // Check if the cart is empty
            if (cart.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty.");
                return RedirectToAction("Index"); // Redirect back to the product list
            }

            // Retrieve the member ID from session (ensure user is logged in)
            var member = Session["Account"] as MEMBER; // Assuming "Account" stores MEMBER session data
            if (member == null)
            {
                ModelState.AddModelError("", "You must be logged in to place an order.");
                return RedirectToAction("Login", "Account"); // Redirect to login if not logged in
            }

            // Create a new order and assign the member_id and calculate the total price
            var order = new ORDERS
            {
                member_id = member.member_id, // Associate order with the logged-in member
                order_date = DateTime.Now,
                total_price = cart.Sum(item => item.ProductPrice * item.Quantity) // Calculate the total price of the cart
            };

            db.ORDERS.Add(order); // Add the new order to the database
            db.SaveChanges(); // Save the order to the database to generate an order ID

            // Add each cart item as order details
            foreach (var item in cart)
            {
                var orderDetail = new ORDER_DETAIL
                {
                    order_id = order.order_id, // Associate order details with the new order
                    product_id = item.ProductId,
                    quantity = item.Quantity,
                    product_price = item.ProductPrice
                };
                db.ORDER_DETAIL.Add(orderDetail);
            }

            db.SaveChanges(); // Save order details to the database

            // Clear the cart after checkout
            Session["Cart"] = null;

            // Redirect to the order confirmation page
            return RedirectToAction("OrderConfirmation", new { id = order.order_id });
        }
        public ActionResult OrderConfirmation(int id)
        {
            // Find the order by ID
            var order = db.ORDERS.Find(id);
            if (order == null)
            {
                return HttpNotFound(); // Return a 404 if the order doesn't exist
            }

            // Pass the order to the view to display the details
            return View(order);
        }


    }
}
