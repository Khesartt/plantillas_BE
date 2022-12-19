﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Plantilla_S_EF.Context;

namespace Plantilla_S_EF.Migrations
{
    [DbContext(typeof(PrincipalContext))]
    [Migration("20221219001815_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Plantilla_S_EF.Models.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("disabled")
                        .HasColumnType("bit");

                    b.Property<int>("id_country")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("varchar(120)");

                    b.Property<int>("pib")
                        .HasColumnType("int");

                    b.Property<long>("population")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("id");

                    b.HasIndex("id_country");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Plantilla_S_EF.Models.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("disabled")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("varchar(120)");

                    b.Property<int>("pib")
                        .HasColumnType("int");

                    b.Property<long>("population")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Plantilla_S_EF.Models.City", b =>
                {
                    b.HasOne("Plantilla_S_EF.Models.Country", "country")
                        .WithMany("cities")
                        .HasForeignKey("id_country")
                        .IsRequired();

                    b.Navigation("country");
                });

            modelBuilder.Entity("Plantilla_S_EF.Models.Country", b =>
                {
                    b.Navigation("cities");
                });
#pragma warning restore 612, 618
        }
    }
}