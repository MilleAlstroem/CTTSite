﻿using CTTSite.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System;

namespace CTTSite.EFDbContext
{
    public class ItemDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CTTDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        }   
        public DbSet<Item> Items { get; set; }

        public DbSet<CartItem> CartItems { get; set; }
    }
}
