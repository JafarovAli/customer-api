﻿using CustomerApi.Entites;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
}
