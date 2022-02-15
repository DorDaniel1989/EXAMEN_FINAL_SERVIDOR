using Microsoft.EntityFrameworkCore;
using ApiExamen.Modelos;

    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
        public static string connString{get; private set;} ="Server=(localdb)\\mssqllocaldb;Database=Final1DB;Trusted_Connection=True;MultipleActiveResultSets=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(connString);

        public DbSet<Pintxo> Pintxos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
    }
