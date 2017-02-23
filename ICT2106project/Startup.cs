using ICT2106project.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ICT2106project.Startup))]
namespace ICT2106project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        // Method to create default user roles and admin roles for login
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Librarian";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  
                var user = new ApplicationUser();
                user.UserName = "librarian123";
                user.Email = "librarian@test.com";

                string userPWD = "Password123=";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Librarian");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Borrower"))
            {
                var role = new IdentityRole();
                role.Name = "Borrower";
                roleManager.Create(role);

            }
        }
    }
}
