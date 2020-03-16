using System;
using Microsoft.EntityFrameworkCore;

namespace AFIAPITest.Models
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().HasData(new Registration
            {
                Id = 1,
                Firstname = "Jane",
                Surname = "Doe",
                PolicyReference = "AA-123456",
                Email = "JaneDoe@gmail.com",
                DOB = new DateTime(1979, 04, 25)


            }, new Registration
            {
                Id = 2,
                Firstname = "Fred",
                Surname = "Bloggs",
                PolicyReference = "AA-123456",
                Email = "Fred.Blogs@BLogsMail.com",
                DOB = new DateTime(1989, 12, 11)
            });
        }

        public DbSet<Registration> Registrations { get; set; }
    }
}
