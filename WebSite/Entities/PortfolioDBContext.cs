﻿using Microsoft.EntityFrameworkCore;

namespace WebSite.Entities
{

    public class PortfolioDBContext : DbContext
    {
        public DbSet<Option> Options { get; set; }
        public DbSet<Navigate> Navigations { get; set; }

        public PortfolioDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=My_portfolio;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Option[] options = new Option[]
            {
                new Option(){Id = 1, Name = "Title", Value="My portfolio", Relation = ""},
                new Option(){Id = 2, Name = "Description", Value="My portfolio description", Relation = ""},
                new Option(){Id = 3, Name = "Logo", Value="/img/logo.png", Relation = ""},
                new Option(){Id = 4, Name = "Email", Value="mortfolio@gmail.com", Relation = ""},
                new Option(){Id = 5, Name = "Facebook", Value="https://www.facebook.com/", Key = "bi bi-facebook", Relation = "social_links", Order = 1},
                new Option(){Id = 6, Name = "Twitter", Value="https://twitter.com/", Key = "bi bi-twitter", Relation = "social_links", Order = 2},
                new Option(){Id = 7, Name = "Instagram", Value="https://www.instagram.com/", Key = "bi bi-instagram", Relation = "social_links", Order = 3},
                new Option(){Id = 8, Name = "Linkedin", Value="https://www.linkedin.com/", Key = "bi bi-linkedin", Relation = "social_links", Order = 4},
            };

            Navigate[] navigates = new Navigate[]
            {
                new Navigate(){ Id = 1, Title = "Home", Href= "/", Order = 1 },
                new Navigate(){ Id = 2, Title = "About", Href= "/about", Order = 2 },
                new Navigate(){ Id = 3, Title = "Me", Href= "about/me", Order = 3 },
                new Navigate(){ Id = 4, Title = "Services", Href= "about/services", Order = 4 },
                new Navigate(){ Id = 5, Title = "Works", Href= "about/works", Order = 5 },
                new Navigate(){ Id = 6, Title = "Contact", Href= "about/contactUs", Order = 6 },
                new Navigate(){ Id = 7, Title = "Blog", Href= "/blog", Order = 7 }
            };

            modelBuilder.Entity<Option>().HasData(options);
            modelBuilder.Entity<Navigate>().HasData(navigates);
        }
    }
}
