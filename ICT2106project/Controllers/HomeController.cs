using ICT2106project.DAL;
using ICT2106project.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICT2106project.Controllers
{
    public class HomeController : Controller
    {
        private DataGateway<Book> DataGateway = new DataGateway<Book>();

        public HomeController()
        {
            DataGateway = new BookGateway();
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (isWhatUser().Equals("Librarian"))
                {
                    ViewBag.displayMenu = "Librarian";
                }
                else if (isWhatUser().Equals("Borrower"))
                {
                    ViewBag.displayMenu = "Borrower";
                }

                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged in";
            }

            // For displaying popular books
            Book book1 = DataGateway.SelectById(1);
            Book book2 = DataGateway.SelectById(2);
            Book book3 = DataGateway.SelectById(3);
            List<Book> list = new List<Book>();
            list.Add(book1);
            list.Add(book2);
            list.Add(book3);

            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // For checking if user is an Admin(Librarian)
        public String isWhatUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Librarian")
                {
                    return "Librarian";
                }
                else if (s[0].ToString() == "Borrower") {
                    return "Borrower";
                }
                else
                {
                    return "0";
                }
            }
            return "";
        }
    }
}