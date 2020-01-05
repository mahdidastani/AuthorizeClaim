using ClaimSample.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClaimSample.DataLayer.Context
{
  public  class ClaimContext : DbContext
    {
        public ClaimContext(DbContextOptions<ClaimContext> options):base(options)
        {

        }

        public DbSet<User> users { get; set; }
    }
}
