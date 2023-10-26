using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int> // bunları dbset içinde aşagıdaki gibi çagırmayacaz
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-LKHTLE8\\SQLEXPRESS; database=TraversalDb; integrated security=true");
            
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<About2> About2s { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Featureds { get; set; }
        public DbSet<Feature2> Featured1s { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<SubAbout> SubAbouts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rezervation> Rezervations { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        //public DbSet<Announcement> Announcements { get; set; }
        //public DbSet<Account> Accounts { get; set; }
        //public DbSet<City> Cities { get; set; }
    }
}

