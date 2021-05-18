using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
    public class Context: DbContext
    {
        internal object _object;

        public DbSet<About> Abouts { get; set; } 
        public DbSet<Category> Categories  { get; set; } 
        public DbSet<Content> Contents  { get; set; } 
        public DbSet<Heading> Headings  { get; set; } 
        public DbSet<Writer> Writers  { get; set; } 

    }
}
