﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi1.DataConnections;

namespace WebApi1.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi1.Models.Musteri", b =>
                {
                    b.Property<int>("MusteriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sehir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MusteriId");

                    b.ToTable("Musteris");
                });

            modelBuilder.Entity("WebApi1.Models.Sepet", b =>
                {
                    b.Property<int>("SepetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MusteriId")
                        .HasColumnType("int");

                    b.HasKey("SepetId");

                    b.HasIndex("MusteriId");

                    b.ToTable("Sepets");
                });

            modelBuilder.Entity("WebApi1.Models.SepetUrun", b =>
                {
                    b.Property<int>("SepetUrunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SepetId")
                        .HasColumnType("int");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SepetUrunId");

                    b.HasIndex("SepetId");

                    b.ToTable("SepetUruns");
                });

            modelBuilder.Entity("WebApi1.Models.Sepet", b =>
                {
                    b.HasOne("WebApi1.Models.Musteri", "Musteri")
                        .WithMany("Sepet")
                        .HasForeignKey("MusteriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musteri");
                });

            modelBuilder.Entity("WebApi1.Models.SepetUrun", b =>
                {
                    b.HasOne("WebApi1.Models.Sepet", "Sepet")
                        .WithMany("SepetUrun")
                        .HasForeignKey("SepetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sepet");
                });

            modelBuilder.Entity("WebApi1.Models.Musteri", b =>
                {
                    b.Navigation("Sepet");
                });

            modelBuilder.Entity("WebApi1.Models.Sepet", b =>
                {
                    b.Navigation("SepetUrun");
                });
#pragma warning restore 612, 618
        }
    }
}
