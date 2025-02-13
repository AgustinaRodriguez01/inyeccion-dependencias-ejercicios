﻿using inyeccion_dependencias_ejercicios.Model;
using Microsoft.EntityFrameworkCore;

namespace inyeccion_dependencias_ejercicios.DataContext
{
    public class DataContextNorthwind : DbContext
    {
        public DataContextNorthwind(DbContextOptions<DataContextNorthwind> options) : base(options)
        {

        }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
