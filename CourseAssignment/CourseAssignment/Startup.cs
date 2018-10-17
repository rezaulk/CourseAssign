using CourseAssignment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(CourseAssignment.Startup))]
namespace CourseAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            DefaultUserandRoles();
            createMorningCoordinator();
        }

        public void DefaultUserandRoles()
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            var hasUser = _context.Users.Where(x => x.UserName == "hasanRobin@gmail.com").Any();

            if (!roleManager.RoleExists("EveningCoordinator"))
            {
                var role = new IdentityRole("EveningCoordinator");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.Email = "eveningCoordinator@wub.edu.bd";
                user.UserName = "eveningCoordinator@wub.edu.bd";

                string Password = "Evening123??";

                var newUser = userManager.Create(user, Password);
                if (newUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "EveningCoordinator");
                }

            }
           
            else if (hasUser == false)
            {
                var role = new IdentityRole("Teacher");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.Email = "hasanRobin@gmail.com";
                user.UserName = "hasanRobin@gmail.com";

                string Password = "Teacher12?";

                var newUser = userManager.Create(user, Password);
                if (newUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Teacher");
                    var teacherInfo = new Teacher();
                    teacherInfo.UserId = user.Id;

                    var year = 2011;
                    var month = 04;
                    var day = 21;
                    DateTime dt = new DateTime(year, month, day);

                    teacherInfo.joiningDate = dt;
                    teacherInfo.Name = "Kazi Hasan Robin";

                    _context.Teachers.Add(teacherInfo);
                    _context.SaveChanges();
                }


            }
        }

        public void createMorningCoordinator() {
            ApplicationDbContext _context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            if (!roleManager.RoleExists("MorningCoordinator"))
            {
                var role = new IdentityRole("MorningCoordinator");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.Email = "morningCoordinator@wub.edu.bd";
                user.UserName = "morningCoordinator@wub.edu.bd";

                string Password = "Morning123??";

                var newUser = userManager.Create(user, Password);
                if (newUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "MorningCoordinator");
                }

            }
        }
    }
}
