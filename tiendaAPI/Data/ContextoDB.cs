using Microsoft.EntityFrameworkCore;
using tiendaAPI.Entidades.Modelos;

namespace tiendaAPI.Data
{
    public class ContextoDB(DbContextOptions<ContextoDB> options) : DbContext(options)
    {
        //Estas dbSet se serán tablas, pero que se hacen a raíz, o, siguiendo los valores de los modelos
        //
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Proveedores
            modelBuilder.Entity<Proveedor>()
                .HasIndex(p => p.Codigo)
                .IsUnique();
            /*HasIndex siginica que utilizará esa propiedad como índice, y, que además, tiene que ser única*/


            //Productos
            modelBuilder.Entity<Producto>()
                .HasOne(p=>p.Proveedor)
                .WithMany(p => p.Productos)
                .HasForeignKey(p => p.CodigoProveedor)
                .OnDelete(DeleteBehavior.Restrict); //Para que no sea estricto al borrar
            /*El HasOne significa que tendrá un Único proveedor, que es P, en donde P es igual a la propiedad de NAVEGACIÓN
             P.Proveedor, y que puede tener, muchos productos
            HasForeignKey, significa que, en el modelo, la propiedad CodigoProveedor trabaja como clave foránea*/

            modelBuilder.Entity<Producto>()
                .HasIndex(p => new { p.CodigoProveedor, p.CodigoProducto })
                .IsUnique(); // índice único secundario

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.Id);


            //Categories
            modelBuilder.Entity<Categoria>()
            .HasIndex(c => c.Nombre)
            .IsUnique();

        }
    }
}
