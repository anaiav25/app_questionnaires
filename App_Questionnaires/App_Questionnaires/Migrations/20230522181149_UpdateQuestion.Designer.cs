﻿// <auto-generated />
using System;
using App_Questionnaires.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App_Questionnaires.Migrations
{
    [DbContext(typeof(App_QuestionnairesContext))]
    [Migration("20230522181149_UpdateQuestion")]
    partial class UpdateQuestion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App_Questionnaires.Models.QuestionNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionnaireId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("App_Questionnaires.Models.Questionnaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questionnaire");
                });

            modelBuilder.Entity("App_Questionnaires.Models.QuestionNode", b =>
                {
                    b.HasOne("App_Questionnaires.Models.QuestionNode", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("App_Questionnaires.Models.Questionnaire", null)
                        .WithMany("AssociatedQuestions")
                        .HasForeignKey("QuestionnaireId");
                });
#pragma warning restore 612, 618
        }
    }
}
