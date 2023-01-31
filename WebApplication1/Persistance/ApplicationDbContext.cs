using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Domain;


namespace Application.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
                base(options)
        { }


        public DbSet<Employee> Employees { get; set; }

    }
}