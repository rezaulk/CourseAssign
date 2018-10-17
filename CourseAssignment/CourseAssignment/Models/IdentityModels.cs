using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CourseAssignment.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Batch> Batches { get; set; }

        public DbSet<Semester> Semesters { get;  set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<AcademicPlan> AcademicPlans { get; set; }

        public DbSet<ClassTime> ClassTimes { get; set; }

        public DbSet<RoutineHistory> RoutineHistories { get; set; }

        public DbSet<CourseTaken> CourseTaken { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<FridayClassTimes> FridayClassTimes { get; set; }

        public DbSet<TempSelectCourse> TempSelectedCourses { get; set; }

        public DbSet<CourseScheduleInfo> CourseScheduleInfoes { get; set; }

        public DbSet<SubjectSelectedByTeacherInCourse> SubjectSelectedByTeacherInCourses { get; set; }

        public DbSet<SubjectForCOurse> SubjectForCourses { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<CourseAssignment.Models.WeekDay> WeekDays { get; set; }
    }
}