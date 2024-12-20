﻿// <auto-generated />
using System;
using ExitSlipService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExitslipService.DatabaseMigration.Migrations
{
    [DbContext(typeof(ExitSlipContext))]
    [Migration("20241203115012_nullablecomment")]
    partial class nullablecomment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExitslipService.Domain.Entities.ExitSlipPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDistributed")
                        .HasColumnType("bit");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ExitSlipPosts");
                });

            modelBuilder.Entity("ExitslipService.Domain.Entities.ExitSlipReply", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ExitSlipReplies");
                });

            modelBuilder.Entity("ExitslipService.Domain.Entities.QuestionForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ExitSlipPostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ExitSlipReplyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("ExitSlipPostId");

                    b.HasIndex("ExitSlipReplyId");

                    b.ToTable("QuestionForm");
                });

            modelBuilder.Entity("ExitslipService.Domain.Entities.QuestionForm", b =>
                {
                    b.HasOne("ExitslipService.Domain.Entities.ExitSlipPost", null)
                        .WithMany("Questionnaire")
                        .HasForeignKey("ExitSlipPostId");

                    b.HasOne("ExitslipService.Domain.Entities.ExitSlipReply", null)
                        .WithMany("Questionnaire")
                        .HasForeignKey("ExitSlipReplyId");
                });

            modelBuilder.Entity("ExitslipService.Domain.Entities.ExitSlipPost", b =>
                {
                    b.Navigation("Questionnaire");
                });

            modelBuilder.Entity("ExitslipService.Domain.Entities.ExitSlipReply", b =>
                {
                    b.Navigation("Questionnaire");
                });
#pragma warning restore 612, 618
        }
    }
}
