﻿// <auto-generated />
using EFCoreMigrationUpdateData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreMigrationUpdateData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200717044931_NoChanges")]
    partial class NoChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreMigrationUpdateData.TestEntity", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("('UTC')");

                    b.HasKey("Code")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("TestEntities");

                    b.HasData(
                        new
                        {
                            Code = "code-1",
                            TimeZone = "Eastern Standard Time"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
