﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(OrderContext))]
    partial class OrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Domain.Model.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreateBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("GrossPrice")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("NettoPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("Tax")
                        .HasColumnType("integer");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Domain.Model.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NumberHome")
                        .HasColumnType("text");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Contractor");
                });

            modelBuilder.Entity("Domain.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ContractorId")
                        .HasColumnType("integer");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("GrossPrice")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("NettoPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid>("Number")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Domain.Model.OrderDetalis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ArticleId")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("GrossPrice")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("NettoPrice")
                        .HasColumnType("numeric");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetalis");
                });

            modelBuilder.Entity("Domain.Model.Order", b =>
                {
                    b.HasOne("Domain.Model.Contractor", "Contractor")
                        .WithMany("Orders")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor");
                });

            modelBuilder.Entity("Domain.Model.OrderDetalis", b =>
                {
                    b.HasOne("Domain.Model.Article", "Article")
                        .WithMany("OrderDetalis")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Order", "Order")
                        .WithMany("OrderDetalis")
                        .HasForeignKey("OrderId");

                    b.Navigation("Article");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Domain.Model.Article", b =>
                {
                    b.Navigation("OrderDetalis");
                });

            modelBuilder.Entity("Domain.Model.Contractor", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Model.Order", b =>
                {
                    b.Navigation("OrderDetalis");
                });
#pragma warning restore 612, 618
        }
    }
}