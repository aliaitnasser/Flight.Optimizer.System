﻿// <auto-generated />
using Flight.Optimizer.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Flight.Optimizer.API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Flight.Optimizer.API.Model.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FamilyId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdult")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("NeedsTwoSeats")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });
#pragma warning restore 612, 618
        }
    }
}
