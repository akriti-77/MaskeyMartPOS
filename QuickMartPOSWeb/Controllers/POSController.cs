using Microsoft.AspNetCore.Mvc;
using QuickMartPOSWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QuickMartPOSWeb.Controllers
{
    public class POSController : Controller
    {
        private readonly QuickMartContext _context;
        private static Transaction currentTransaction = new Transaction();

        public POSController(QuickMartContext context)
        {
            _context = context;
        }

        public IActionResult POSInterface()
        {
            ViewBag.Inventory = _context.Products.ToList();
            ViewBag.CurrentTransaction = currentTransaction;
            ViewBag.DateTime = DateTime.Now;
            ViewBag.UserName = "Aakriti"; // Replace with actual user authentication
            ViewBag.Categories = _context.Products.Select(p => p.Category).Distinct().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(decimal cashAmount)
        {
            ViewBag.CashAmount = cashAmount;
            ViewBag.Change = cashAmount - currentTransaction.Total;
            ViewBag.Transaction = currentTransaction;
            currentTransaction = new Transaction(); // Reset for next transaction
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = _context.Products.Select(p => p.Category).Distinct().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {

                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("POSInterface");
            }
            ViewBag.Categories = _context.Products.Select(p => p.Category).Distinct().ToList();
            return View(product);
        }

        [HttpPost]
        public IActionResult AddToTransaction(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                var existingItem = currentTransaction.Items.FirstOrDefault(i => i.Product.Id == productId);
                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                }
                else
                {
                    currentTransaction.Items.Add(new TransactionItem { Product = product, Quantity = quantity });
                }
            }
            return Json(currentTransaction);
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            currentTransaction = new Transaction();
            return Json(currentTransaction);
        }

        [HttpPost]
        public IActionResult Refund(int transactionId)
        {
            // In a real application, you would process the refund here
            return Json(new { success = true, message = "Refund processed successfully" });
        }
    }
}