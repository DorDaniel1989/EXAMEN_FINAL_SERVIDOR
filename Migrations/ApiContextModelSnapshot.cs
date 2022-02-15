﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Final1.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ApiExamen.Modelos.Comanda", b =>
                {
                    b.Property<int>("IdComanda")
                        .HasColumnType("int");

                    b.Property<int>("NumMesa")
                        .HasColumnType("int");

                    b.HasKey("IdComanda");

                    b.ToTable("Comandas");
                });

            modelBuilder.Entity("ApiExamen.Modelos.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ComandaId")
                        .HasColumnType("int");

                    b.Property<int>("PintxoId")
                        .HasColumnType("int");

                    b.HasKey("PedidoId");

                    b.HasIndex("ComandaId");

                    b.HasIndex("PintxoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("ApiExamen.Modelos.Pintxo", b =>
                {
                    b.Property<int>("PintxoId")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("precio")
                        .HasColumnType("int");

                    b.HasKey("PintxoId");

                    b.ToTable("Pintxos");
                });

            modelBuilder.Entity("ApiExamen.Modelos.Pedido", b =>
                {
                    b.HasOne("ApiExamen.Modelos.Comanda", "Comanda")
                        .WithMany("Pedidos")
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiExamen.Modelos.Pintxo", "Pintxo")
                        .WithMany("Pedidos")
                        .HasForeignKey("PintxoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comanda");

                    b.Navigation("Pintxo");
                });

            modelBuilder.Entity("ApiExamen.Modelos.Comanda", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("ApiExamen.Modelos.Pintxo", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
