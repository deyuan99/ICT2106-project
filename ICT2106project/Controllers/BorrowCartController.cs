using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ICT2106project.DAL;
using ICT2106project.Models;
using System.Collections;

namespace ICT2106project.Controllers
{
    public class BorrowCartController : Controller
    {
        private BookGateway bookGateway = new BookGateway();
        static List<Book> cart = new List<Book>();

        // GET: BorrowCart
        public ActionResult Index()
        {
            return View(cart);
        }
        
        // BorrowCart/Add
        public ActionResult Add(int id)
        {
            try
            {
                // Adding book to borrow cart
                Book book = bookGateway.SelectById(id);
                /*Book cartBook = new Book();
                cartBook.bookTitle = book.bookTitle;
                cartBook.bookAuthor = book.bookAuthor;
                cartBook.bookGenre = book.bookGenre;
                cartBook.bookDesc = book.bookDesc;
                cartBook.bookISBN10 = book.bookISBN10;
                cartBook.bookISBN13 = book.bookISBN13;
                cartBook.bookType = book.bookType;
                cartBook.bookImage = book.bookImage;
                cartBook.bookLocation = book.bookLocation;
                cartBook.bookQuantity = book.bookQuantity;
                cartBook.bookAvailability = book.bookAvailability;*/

                //cart.Add(cartBook);
                cart.Add(book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // BorrowCart/Delete
        public ActionResult Delete(int id)
        {
            cart.RemoveAt(id-1);
            return RedirectToAction("Index");
        }

        // BorrowCart/DeleteAll
        public void DeleteAll()
        {
            cart = new List<Book>();
        }

        // BorrowCart/Checkout
        public ActionResult Checkout()
        {
            TempData["Cart"] = cart;
            cart = new List<Book>();
            return RedirectToAction("Index", "Loan");
        }

    }
}
