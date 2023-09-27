using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBID.Models;
using Microsoft.EntityFrameworkCore;

namespace IBID.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> op) : base(op) {}

        public DbSet<ProdutoModel> Produtos {get; set;}
     }
}