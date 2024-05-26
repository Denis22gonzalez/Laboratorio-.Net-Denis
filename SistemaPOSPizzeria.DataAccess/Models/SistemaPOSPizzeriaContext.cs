using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SistemaPOSPizzeria.DataAccess.Models
{
    public partial class SistemaPOSPizzeriaContext : DbContext
    {
        public SistemaPOSPizzeriaContext()
        {
        }

        public SistemaPOSPizzeriaContext(DbContextOptions<SistemaPOSPizzeriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCatalogoEstadosPedido> TbCatalogoEstadosPedidos { get; set; }
        public virtual DbSet<TbCliente> TbClientes { get; set; }
        public virtual DbSet<TbClientesDireccione> TbClientesDirecciones { get; set; }
        public virtual DbSet<TbPedido> TbPedidos { get; set; }
        public virtual DbSet<TbPedidosDetalle> TbPedidosDetalles { get; set; }
        public virtual DbSet<TbProducto> TbProductos { get; set; }
        public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

        //Se expande el dbcontext con las nuevas entidades
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Direccion> Direcciones { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<CabeceraDetalle> CabeceraDetalles { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-093O2IQ; Database=SistemaPOSPizzeria; User=sa; Password=Denis2021;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TbCatalogoEstadosPedido>(entity =>
            {
                entity.HasKey(e => e.EstadoPedidoId)
                    .HasName("PK__tbCatalo__C803A6B5779CA033");

                entity.ToTable("tbCatalogo_Estados_Pedido");

                entity.Property(e => e.EstadoPedidoId).HasColumnName("Estado_Pedido_Id");

                entity.Property(e => e.EstadoPedidoDescripcion)
                    .HasMaxLength(100)
                    .HasColumnName("Estado_Pedido_Descripcion");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("PK__tbClient__EB683C54E66537CB");

                entity.ToTable("tbClientes");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_Id");

                entity.Property(e => e.ClienteApellido)
                    .HasMaxLength(100)
                    .HasColumnName("Cliente_Apellido");

                entity.Property(e => e.ClienteCorreo)
                    .HasMaxLength(200)
                    .HasColumnName("Cliente_Correo");

                entity.Property(e => e.ClienteNombre)
                    .HasMaxLength(100)
                    .HasColumnName("Cliente_Nombre");

                entity.Property(e => e.ClienteTelefono)
                    .HasMaxLength(15)
                    .HasColumnName("Cliente_Telefono");
            });

            modelBuilder.Entity<TbClientesDireccione>(entity =>
            {
                entity.HasKey(e => e.ClienteDireccionId)
                    .HasName("PK__tbClient__17568F958943DFF7");

                entity.ToTable("tbClientes_Direcciones");

                entity.Property(e => e.ClienteDireccionId).HasColumnName("Cliente_Direccion_Id");

                entity.Property(e => e.ClienteDireccionDescripcion)
                    .HasMaxLength(400)
                    .HasColumnName("Cliente_Direccion_Descripcion");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_Id");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.TbClientesDirecciones)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_Cliente_Id");
            });

            modelBuilder.Entity<TbPedido>(entity =>
            {
                entity.HasKey(e => e.PedidoId)
                    .HasName("PK__tbPedido__04683A5A163C1AE2");

                entity.ToTable("tbPedidos");

                entity.Property(e => e.PedidoId).HasColumnName("Pedido_Id");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_Id");

                entity.Property(e => e.EstadoPedidoId).HasColumnName("Estado_Pedido_Id");

                entity.Property(e => e.PedidoFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Pedido_Fecha");

                entity.Property(e => e.PedidoTotal)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Pedido_Total");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.TbPedidos)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_Cliente_Id_Pedido");

                entity.HasOne(d => d.EstadoPedido)
                    .WithMany(p => p.TbPedidos)
                    .HasForeignKey(d => d.EstadoPedidoId)
                    .HasConstraintName("FK_Estado_Pedido_Id");
            });

            modelBuilder.Entity<TbPedidosDetalle>(entity =>
            {
                entity.HasKey(e => e.PedidoDetalleId)
                    .HasName("PK__tbPedido__7AC4BD95B486EFCA");

                entity.ToTable("tbPedidos_Detalle");

                entity.Property(e => e.PedidoDetalleId).HasColumnName("Pedido_Detalle_Id");

                entity.Property(e => e.PedidoDetalleCantidad).HasColumnName("Pedido_Detalle_Cantidad");

                entity.Property(e => e.PedidoDetalleSubtotal)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Pedido_Detalle_Subtotal");

                entity.Property(e => e.PedidoId).HasColumnName("Pedido_Id");

                entity.Property(e => e.ProductoId).HasColumnName("Producto_Id");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.TbPedidosDetalles)
                    .HasForeignKey(d => d.PedidoId)
                    .HasConstraintName("FK_Pedido_Id");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.TbPedidosDetalles)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_Producto_Id");
            });

            modelBuilder.Entity<TbProducto>(entity =>
            {
                entity.HasKey(e => e.ProductoId)
                    .HasName("PK__tbProduc__9F1B14DD4DA0A073");

                entity.ToTable("tbProductos");

                entity.Property(e => e.ProductoId).HasColumnName("Producto_Id");

                entity.Property(e => e.ProductoDescripcion)
                    .HasMaxLength(200)
                    .HasColumnName("Producto_Descripcion");

                entity.Property(e => e.ProductoImagen)
                    .HasMaxLength(400)
                    .HasColumnName("Producto_Imagen");

                entity.Property(e => e.ProductoNombre)
                    .HasMaxLength(200)
                    .HasColumnName("Producto_Nombre");

                entity.Property(e => e.ProductoPrecio)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Producto_Precio");

                entity.Property(e => e.ProductoStok).HasColumnName("Producto_Stok");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioId)
                    .HasName("PK__tbUsuari__771110D564C8CE77");

                entity.ToTable("tbUsuarios");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");

                entity.Property(e => e.UsuarioNombre)
                    .HasMaxLength(100)
                    .HasColumnName("Usuario_Nombre");

                entity.Property(e => e.UsuarioPassword)
                    .HasMaxLength(1000)
                    .HasColumnName("Usuario_Password");
            });

            //nuevos modelos
            modelBuilder.Entity<Pedido>()
      .HasKey(e => e.pedido_Id);
            modelBuilder.Entity<Cliente>()
      .HasKey(e => e.Cliente_Id);


            modelBuilder.Entity<Direccion>()
       .HasKey(e=> e.Cliente_Direccion_Id);
            modelBuilder.Entity<CabeceraDetalle>()
        .HasKey(e => e.PedidoDetalleId);
            modelBuilder.Entity<Producto>()
      .HasKey(e => e.Producto_Id);

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
