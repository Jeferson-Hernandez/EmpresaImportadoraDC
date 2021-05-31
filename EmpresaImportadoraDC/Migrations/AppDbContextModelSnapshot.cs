﻿// <auto-generated />
using EmpresaImportadoraDC.Models.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmpresaImportadoraDC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmpresaImportadoraDC.Models.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CorreoElectronico");

                    b.Property<string>("DireccionEntrega")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumeroCasillero")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("EmpresaImportadoraDC.Models.Entities.Mercancia", b =>
                {
                    b.Property<int>("IdMercancia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoMercancia")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMercancia");

                    b.ToTable("Mercancia");
                });

            modelBuilder.Entity("EmpresaImportadoraDC.Models.Entities.Paquete", b =>
                {
                    b.Property<int>("PaqueteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NoGuiaCO")
                        .HasColumnType("int");

                    b.Property<int>("NoGuiaUSA")
                        .HasColumnType("int");

                    b.Property<string>("RutaImagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoMercancia")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TransportadoraCO")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TransportadoraUSA")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("ValorTotal")
                        .HasColumnType("bigint");

                    b.HasKey("PaqueteId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Paquete");
                });

            modelBuilder.Entity("EmpresaImportadoraDC.Models.Entities.Transportadora", b =>
                {
                    b.Property<int>("TransportadoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("TransportadoraId");

                    b.ToTable("Transportadora");
                });

            modelBuilder.Entity("EmpresaImportadoraDC.Models.Entities.Paquete", b =>
                {
                    b.HasOne("EmpresaImportadoraDC.Models.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
