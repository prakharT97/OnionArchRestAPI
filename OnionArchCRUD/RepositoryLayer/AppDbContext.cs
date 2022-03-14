using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions con) : base(con) { 
        
            
        }
        
        public DbSet<User> tblUser { get; set; } 
    }
}
