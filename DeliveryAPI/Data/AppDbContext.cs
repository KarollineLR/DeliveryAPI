using Microsoft.EntityFrameworkCore;
using DeliveryAPI.Models;

namespace PedidoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {


        }
        public DbSet<Pedidos> Pedidos { get; set; }

    }
}

