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

namespace ICT2106project.Controllers
{
    public class BookController : Controller
    {
        //private BookGateway bookGateway = new BookGateway();
        private DataGateway<Book> DataGateway = new DataGateway<Book>();

        public BookController()
        {
            DataGateway = new BookGateway();
        }
        // GET: Book
        public ActionResult Index()
        {
            return View(DataGateway.SelectAll());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = DataGateway.SelectById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookTitle,bookAuthor,bookGenre,bookDesc,bookISBN10,bookISBN13,bookType,bookImage,bookLocation,bookQuantity,bookAvailability,dateOfLoan")] Book book)
        {
            if (ModelState.IsValid)
            {
                DataGateway.Insert(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = DataGateway.SelectById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookTitle,bookAuthor,bookGenre,bookDesc,bookISBN10,bookISBN13,bookType,bookImage,bookLocation,bookQuantity,bookAvailability,dateOfLoan")] Book book)
        {
            if (ModelState.IsValid)
            {
                DataGateway.Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = DataGateway.SelectById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DataGateway.Delete(id);
            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
