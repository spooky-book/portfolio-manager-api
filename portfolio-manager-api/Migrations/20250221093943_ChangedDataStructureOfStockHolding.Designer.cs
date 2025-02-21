﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioManagerApi.Repository;

#nullable disable

namespace portfolio_manager_api.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    [Migration("20250221093943_ChangedDataStructureOfStockHolding")]
    partial class ChangedDataStructureOfStockHolding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("PortfolioManagerApi.Entities.Assets.HoldableAsset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AssetType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<double>("AveragePrice")
                        .HasColumnType("REAL");

                    b.Property<Guid>("PortfolioId")
                        .HasColumnType("TEXT");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Assets", (string)null);

                    b.HasDiscriminator<string>("AssetType").HasValue("HoldableAsset");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PortfolioManagerApi.Entities.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Portfolios", (string)null);
                });

            modelBuilder.Entity("portfolio_manager_api.Models.StockHolding", b =>
                {
                    b.HasBaseType("PortfolioManagerApi.Entities.Assets.HoldableAsset");

                    b.Property<DateTimeOffset>("AcquisitionDateTime")
                        .HasColumnType("TEXT");

                    b.Property<double>("AcquisitionPrice")
                        .HasColumnType("REAL");

                    b.Property<DateTimeOffset>("DisposalDateTime")
                        .HasColumnType("TEXT");

                    b.Property<double>("DisposalPrice")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsDisposed")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Stock");
                });

            modelBuilder.Entity("PortfolioManagerApi.Entities.Assets.HoldableAsset", b =>
                {
                    b.HasOne("PortfolioManagerApi.Entities.Portfolio", "Portfolio")
                        .WithMany("Assets")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("PortfolioManagerApi.Entities.Portfolio", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
