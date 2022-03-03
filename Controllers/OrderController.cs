using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission7.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission7.Controllers
{
    public class OrderController : Controller
    {
        //to bring in the database, set up a constructor
        //create IORepo, EFORepo

        private IOrderRepository repo { get; set; }
        private Basket basket { get; set; }

        public OrderController(IOrderRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        //bring in the info for the database
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            //what to do if basket is empty
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            //if its not empty, go into the order object, and add lines that are from the basket items that has been built,
            if (ModelState.IsValid)
            {
                order.Lines = basket.Items.ToArray();
                repo.SaveOrder(order); //save the order
                basket.ClearBasket(); //then, since the order has been processed, we can clear the basket

                return RedirectToPage("/OrderConfirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
