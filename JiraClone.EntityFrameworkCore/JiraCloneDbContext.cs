using JiraClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JiraClone.EntityFrameworkCore
{
    public class JiraCloneDbContext : DbContext
    {

        public JiraCloneDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<issue> Issues { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
