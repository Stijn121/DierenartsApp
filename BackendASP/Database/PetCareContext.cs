﻿using BackendASP.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace BackendASP.Database
{
    public class PetCareContext : DbContext
    {
        private readonly IConfiguration _configuration;


        public DbSet<PetType> PetTypes { get; set; }


        public PetCareContext(IConfiguration config)
        {
            _configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("PetCareDatabase"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetType>().HasData(
                new { Id = 1, Name = "hond", Plural = "honden", Image = "dog.png" },
                new { Id = 2, Name = "kat", Plural = "katten", Image = "black-cat.png" },
                new { Id = 3, Name = "konijn", Plural = "konijnen", Image = "rabbit.png" },
                new { Id = 4, Name = "cavia", Plural = "cavia's", Image = "guinea-pig.png" },
                new { Id = 5, Name = "hamster", Plural = "hamsters", Image = "hamster.png" },
                new { Id = 6, Name = "rat", Plural = "ratten", Image = "rat.png" },
                new { Id = 7, Name = "muis", Plural = "muizen", Image = "muis.png" },
                new { Id = 8, Name = "kleine hond", Plural = "kleine honden", Image = "dog.png", ParentId = 1 },
                new { Id = 9, Name = "grote hond", Plural = "grote honden", Image = "dog.png", ParentId = 1 }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
