using System.Data.Entity;
using ContosoUniversity.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

namespace ContosoUniversity.DAL
{
    public class SchoolContext : DbContext
    {
        /// <summary>
        /// The name of the connection string (which you'll add to the Web.config file later) is passed in to the constructor.
        /// </summary>
        public SchoolContext() : base("SchoolContext")
        {
            //try
            //{
            //    using (var connection = new SqlConnection("Data Source=MASACH\\SQLEXPRESS;Initial Catalog=ContosoUniversity;Integrated Security=SSPI;"))
            //    {
            //        connection.Open();
              
            //    }
            //}
            //catch (System.Exception ex)
            //{
         
            //}
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}