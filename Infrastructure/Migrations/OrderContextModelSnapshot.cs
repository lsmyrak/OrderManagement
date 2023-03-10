// <auto-generated />
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
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<decimal>("GrossPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("gross_price");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("NettoPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("netto_price");

                    b.Property<int>("Tax")
                        .HasColumnType("integer")
                        .HasColumnName("tax");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_date");

                    b.HasKey("Id")
                        .HasName("pk_article");

                    b.ToTable("article");
                });

            modelBuilder.Entity("Domain.Model.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("NumberHome")
                        .HasColumnType("text")
                        .HasColumnName("number_home");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_date");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_contractor");

                    b.ToTable("contractor");
                });

            modelBuilder.Entity("Domain.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ContractorId")
                        .HasColumnType("integer")
                        .HasColumnName("contractor_id");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<decimal>("GrossPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("gross_price");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<decimal>("NettoPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("netto_price");

                    b.Property<Guid>("Number")
                        .HasColumnType("uuid")
                        .HasColumnName("number");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("order_date");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_date");

                    b.HasKey("Id")
                        .HasName("pk_order");

                    b.HasIndex("ContractorId")
                        .HasDatabaseName("ix_order_contractor_id");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Domain.Model.OrderDetalis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ArticleId")
                        .HasColumnType("integer")
                        .HasColumnName("article_id");

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");

                    b.Property<decimal>("GrossPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("gross_price");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<decimal>("NettoPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("netto_price");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_date");

                    b.HasKey("Id")
                        .HasName("pk_order_detalis");

                    b.HasIndex("ArticleId")
                        .HasDatabaseName("ix_order_detalis_article_id");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_detalis_order_id");

                    b.ToTable("order_detalis");
                });

            modelBuilder.Entity("Domain.Model.Order", b =>
                {
                    b.HasOne("Domain.Model.Contractor", "Contractor")
                        .WithMany("Orders")
                        .HasForeignKey("ContractorId")
                        .HasConstraintName("fk_order_contractor_contractor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor");
                });

            modelBuilder.Entity("Domain.Model.OrderDetalis", b =>
                {
                    b.HasOne("Domain.Model.Article", "Article")
                        .WithMany("OrderDetalis")
                        .HasForeignKey("ArticleId")
                        .HasConstraintName("fk_order_detalis_article_article_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Order", "Order")
                        .WithMany("OrderDetalis")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_order_detalis_order_order_id");

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
