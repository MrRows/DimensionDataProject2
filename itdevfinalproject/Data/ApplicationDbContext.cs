using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using itdevfinalproject.Models;

namespace itdevfinalproject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<itdevfinalproject.Models.Company> Company { get; set; }
        public DbSet<itdevfinalproject.Models.Employee> Employee { get; set; }
        public DbSet<itdevfinalproject.Models.Job> Job { get; set; }
        public DbSet<itdevfinalproject.Models.WorkExperience> WorkExperience { get; set; }
    }
}
