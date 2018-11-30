﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TermProject.Repositories;

namespace TermProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181130210003_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TermProject.Models.Poll", b =>
                {
                    b.Property<int>("PollID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.HasKey("PollID");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("TermProject.Models.PollOption", b =>
                {
                    b.Property<int>("PollOptionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("PollID");

                    b.Property<int>("Votes");

                    b.HasKey("PollOptionID");

                    b.HasIndex("PollID");

                    b.ToTable("PollOptions");
                });

            modelBuilder.Entity("TermProject.Models.PollOption", b =>
                {
                    b.HasOne("TermProject.Models.Poll")
                        .WithMany("Options")
                        .HasForeignKey("PollID");
                });
#pragma warning restore 612, 618
        }
    }
}