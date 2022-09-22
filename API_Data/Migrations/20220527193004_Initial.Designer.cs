﻿// <auto-generated />
using System;
using Api_Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api_Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220527193004_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Api_Domain.Entities.CepEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<Guid>("MunicipioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Numero")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Cep");

                    b.HasIndex("MunicipioId");

                    b.ToTable("Cep");
                });

            modelBuilder.Entity("Api_Domain.Entities.MunicipioEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CodIBGE")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<Guid>("UfId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CodIBGE");

                    b.HasIndex("UfId");

                    b.ToTable("Municipio");
                });

            modelBuilder.Entity("Api_Domain.Entities.UfEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Sigla")
                        .IsUnique();

                    b.ToTable("Uf");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a7abf6d4-b2fc-4897-aa12-d0d6589c6256"),
                            CreateAt = new DateTime(2022, 5, 27, 19, 30, 4, 109, DateTimeKind.Utc).AddTicks(6569),
                            Nome = "Acre",
                            Sigla = "AC"
                        },
                        new
                        {
                            Id = new Guid("b32ee1cd-82d1-4d05-9b71-b674e947db00"),
                            CreateAt = new DateTime(2022, 5, 27, 19, 30, 4, 109, DateTimeKind.Utc).AddTicks(6649),
                            Nome = "Alagoas",
                            Sigla = "AL"
                        },
                        new
                        {
                            Id = new Guid("5afaeaed-e40d-4907-b1fb-18bf86c65264"),
                            CreateAt = new DateTime(2022, 5, 27, 19, 30, 4, 109, DateTimeKind.Utc).AddTicks(6663),
                            Nome = "São Paulo",
                            Sigla = "SP"
                        });
                });

            modelBuilder.Entity("Api_Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dbf7c725-136a-47bd-9724-6a95873e6d48"),
                            CreateAt = new DateTime(2022, 5, 27, 16, 30, 4, 102, DateTimeKind.Local).AddTicks(8839),
                            Email = "and@teste.com",
                            Name = "Administrador",
                            UpdateAt = new DateTime(2022, 5, 27, 16, 30, 4, 106, DateTimeKind.Local).AddTicks(9165)
                        });
                });

            modelBuilder.Entity("Api_Domain.Entities.CepEntity", b =>
                {
                    b.HasOne("Api_Domain.Entities.MunicipioEntity", "Municipio")
                        .WithMany("Ceps")
                        .HasForeignKey("MunicipioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("Api_Domain.Entities.MunicipioEntity", b =>
                {
                    b.HasOne("Api_Domain.Entities.UfEntity", "Uf")
                        .WithMany("Municipios")
                        .HasForeignKey("UfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uf");
                });

            modelBuilder.Entity("Api_Domain.Entities.MunicipioEntity", b =>
                {
                    b.Navigation("Ceps");
                });

            modelBuilder.Entity("Api_Domain.Entities.UfEntity", b =>
                {
                    b.Navigation("Municipios");
                });
#pragma warning restore 612, 618
        }
    }
}
