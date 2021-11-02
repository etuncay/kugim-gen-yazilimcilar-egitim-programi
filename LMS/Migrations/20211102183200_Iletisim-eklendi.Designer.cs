﻿// <auto-generated />
using System;
using LMS.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LMS.Migrations
{
    [DbContext(typeof(LMSDbContext))]
    [Migration("20211102183200_Iletisim-eklendi")]
    partial class Iletisimeklendi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LMS.Models.Data.AnaDersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UstId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UstId");

                    b.ToTable("AnaDers");
                });

            modelBuilder.Entity("LMS.Models.Data.BasvuruEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BasvuruDosyaYol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CepTelefonu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Eposta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResimDosyaYol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCNO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Basvuru");
                });

            modelBuilder.Entity("LMS.Models.Data.BasvuruSureciEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BasvuruId")
                        .HasColumnType("int");

                    b.Property<int>("BasvuruSurecTipi")
                        .HasColumnType("int");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BasvuruId");

                    b.ToTable("BasvuruSureci");
                });

            modelBuilder.Entity("LMS.Models.Data.IlEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tanim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Il");
                });

            modelBuilder.Entity("LMS.Models.Data.IlceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("IlId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tanim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IlId");

                    b.ToTable("Ilce");
                });

            modelBuilder.Entity("LMS.Models.Data.Iletisim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("IlceId")
                        .HasColumnType("int");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IlceId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Iletisim");
                });

            modelBuilder.Entity("LMS.Models.Data.KullaniciEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<string>("Eposta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yetki")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kullanici");
                });

            modelBuilder.Entity("LMS.Models.Data.AnaDersEntity", b =>
                {
                    b.HasOne("LMS.Models.Data.AnaDersEntity", "UstAnaDers")
                        .WithMany()
                        .HasForeignKey("UstId");

                    b.Navigation("UstAnaDers");
                });

            modelBuilder.Entity("LMS.Models.Data.BasvuruSureciEntity", b =>
                {
                    b.HasOne("LMS.Models.Data.BasvuruEntity", "Basvuru")
                        .WithMany("BasvuruSurecleri")
                        .HasForeignKey("BasvuruId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basvuru");
                });

            modelBuilder.Entity("LMS.Models.Data.IlceEntity", b =>
                {
                    b.HasOne("LMS.Models.Data.IlEntity", "Il")
                        .WithMany()
                        .HasForeignKey("IlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Il");
                });

            modelBuilder.Entity("LMS.Models.Data.Iletisim", b =>
                {
                    b.HasOne("LMS.Models.Data.IlceEntity", "Ilce")
                        .WithMany()
                        .HasForeignKey("IlceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS.Models.Data.KullaniciEntity", "Kullanici")
                        .WithMany()
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ilce");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("LMS.Models.Data.BasvuruEntity", b =>
                {
                    b.Navigation("BasvuruSurecleri");
                });
#pragma warning restore 612, 618
        }
    }
}
