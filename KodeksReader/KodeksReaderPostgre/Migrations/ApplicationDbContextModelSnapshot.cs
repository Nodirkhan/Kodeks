﻿// <auto-generated />
using System;
using KodeksReaderPostgre.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KodeksReaderPostgre.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KodeksReaderPostgre.Model.Bob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BolimId")
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("KodeksId")
                        .HasColumnType("uuid");

                    b.Property<float>("Number")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BolimId");

                    b.HasIndex("KodeksId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("KodeksReaderPostgre.Model.Bolim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("KodeksId")
                        .HasColumnType("uuid");

                    b.Property<float>("Number")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("KodeksId");

                    b.ToTable("Bolimlar");
                });

            modelBuilder.Entity("KodeksReaderPostgre.Model.Kodeks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Codexes");
                });

            modelBuilder.Entity("KodeksReaderPostgre.Model.Modda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BobId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descrition")
                        .HasColumnType("text");

                    b.Property<Guid?>("KodeksId")
                        .HasColumnType("uuid");

                    b.Property<float>("Number")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BobId");

                    b.HasIndex("KodeksId");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.ToTable("Moddalar");
                });

            modelBuilder.Entity("KodeksReaderPostgre.Model.Bob", b =>
                {
                    b.HasOne("KodeksReaderPostgre.Model.Bolim", null)
                        .WithMany("Boblar")
                        .HasForeignKey("BolimId");

                    b.HasOne("KodeksReaderPostgre.Model.Kodeks", null)
                        .WithMany("Boblar")
                        .HasForeignKey("KodeksId");
                });

            modelBuilder.Entity("KodeksReaderPostgre.Model.Bolim", b =>
                {
                    b.HasOne("KodeksReaderPostgre.Model.Kodeks", null)
                        .WithMany("Bolimlar")
                        .HasForeignKey("KodeksId");
                });

            modelBuilder.Entity("KodeksReaderPostgre.Model.Modda", b =>
                {
                    b.HasOne("KodeksReaderPostgre.Model.Bob", null)
                        .WithMany("Moddalar")
                        .HasForeignKey("BobId");

                    b.HasOne("KodeksReaderPostgre.Model.Kodeks", null)
                        .WithMany("Moddalar")
                        .HasForeignKey("KodeksId");
                });

            modelBuilder.Entity("KodeksReaderPostgre.Model.Bob", b =>
                {
                    b.Navigation("Moddalar");
                });

            modelBuilder.Entity("KodeksReaderPostgre.Model.Bolim", b =>
                {
                    b.Navigation("Boblar");
                });

            modelBuilder.Entity("KodeksReaderPostgre.Model.Kodeks", b =>
                {
                    b.Navigation("Boblar");

                    b.Navigation("Bolimlar");

                    b.Navigation("Moddalar");
                });
#pragma warning restore 612, 618
        }
    }
}
