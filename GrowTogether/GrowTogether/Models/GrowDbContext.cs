using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowTogether.Models
{
    public class GrowDbContext : DbContext
    {
       
        public GrowDbContext(DbContextOptions<GrowDbContext> options) : base(options)
        { 
        }
        public GrowDbContext()
        {

        }
       

        public DbSet<Classes> Classes { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<User> User { get; set; }
        
    }
}
