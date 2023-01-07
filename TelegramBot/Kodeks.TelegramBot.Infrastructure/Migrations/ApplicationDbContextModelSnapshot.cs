﻿// <auto-generated />
using System;
using Kodeks.TelegramBot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kodeks.TelegramBot.Infrastructure.Migrations
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

            modelBuilder.Entity("Kodeks.TelegramBot.Domain.Entities.Bob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BolimId")
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("KodeksId")
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

            modelBuilder.Entity("Kodeks.TelegramBot.Domain.Entities.Bolim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("KodeksId")
                        .HasColumnType("uuid");

                    b.Property<float>("Number")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("KodeksId");

                    b.ToTable("Bolimlar");
                });

            modelBuilder.Entity("Kodeks.TelegramBot.Domain.Entities.Kodeks", b =>
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

            modelBuilder.Entity("Kodeks.TelegramBot.Domain.Entities.Modda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BobId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descrition")
                        .HasColumnType("text");

                    b.Property<Guid>("KodeksId")
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

            modelBuilder.Entity("Kodeks.TelegramBot.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("IsSubscriber")
                        .HasColumnType("boolean");

                    b.Property<string>("KodeksId")
                        .HasColumnType("text");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Kodeks.TelegramBot.Domain.Entities.Bob", b =>
                {
                    b.HasOne("Kodeks.TelegramBot.Domain.Entities.Bolim", "Bolim")
                        .WithMany("Boblar")
                        .HasForeignKey("BolimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kodeks.TelegramBot.Domain.Entities.Kodeks", "Kodeks")
                        .WithMany("Boblar")
                        .HasForeignKey("KodeksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolim");

                    b.Navigation("Kodeks");
                });

            modelBuilder.Entity("Kodeks.TelegramBot.Domain.Entities.Bolim", b =>
                {
                    b.HasOne("Kodeks.TelegramBot.Domain.Entities.Kodeks", "Kodeks")
                        .WithMany("Bolimlar")
                        .HasForeignKey("KodeksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kodeks");
                });

            modelBuilder.Entity("Kodeks.TelegramBot.Domain.Entities.Modda", b =>
                {
                    b.HasOne("Kodeks.TelegramBot.Domain.Entities.Bob", "Bob")
                        .WithMany("Moddalar")
                        .HasForeignKey("BobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kodeks.TelegramBot.Domain.Entities.Kodeks", "Kodeks")
                        .WithMany("Moddalar")
                        .HasForeignKey("KodeksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bob");

                    b.Navigation("Kodeks");
                });

            modelBuilder.Entity("Kodeks.TelegramBot.Domain.Entities.Bob", b =>
                {
                    b.Navigation("Moddalar");
                });

            modelBuilder.Entity("Kodeks.TelegramBot.Domain.Entities.Bolim", b =>
                {
                    b.Navigation("Boblar");
                });

            modelBuilder.Entity("Kodeks.TelegramBot.Domain.Entities.Kodeks", b =>
                {
                    b.Navigation("Boblar");

                    b.Navigation("Bolimlar");

                    b.Navigation("Moddalar");
                });
#pragma warning restore 612, 618
        }
    }
}