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
    public class LoanController : Controller
    {
        //private LoanGateway loanGateway = new LoanGateway();
        private DataGateway<Loan> DataGateway = new DataGateway<Loan>();

        public LoanController()
        {
            DataGateway = new LoanGateway();
        }
        // GET: Loan
        public ActionResult Index()
        {
            // Creating loan from checkout
            if (TempData.ContainsKey("Cart"))
            {
                Loan loan = new Loan();
                loan.books = TempData["Cart"] as List<Book>;

                loan.dateOfLoan = DateTime.Today;
                loan.loanQuantity = loan.books.Count;
                loan.loanStatus = "On Loan";
                DataGateway.Insert(loan);
            }
            return View(DataGateway.SelectAll());
        }
    }
}
