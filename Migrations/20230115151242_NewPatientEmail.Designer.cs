﻿// <auto-generated />
using System;
using System.Collections.Generic;
using MedicalTrack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicalTrack.Migrations
{
    [DbContext(typeof(MedicalContext))]
    [Migration("20230115151242_NewPatientEmail")]
    partial class NewPatientEmail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "hstore");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MedicalTrack.src.Drug.Model.Drug", b =>
                {
                    b.Property<int>("DrugId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DrugId"));

                    b.Property<int?>("DrugCount")
                        .HasColumnType("integer");

                    b.Property<Dictionary<string, string>>("DrugInfo")
                        .HasColumnType("hstore");

                    b.Property<Dictionary<string, string>>("DrugPurpose")
                        .HasColumnType("hstore");

                    b.HasKey("DrugId");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("MedicalTrack.src.Patient.Model.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PatientId"));

                    b.Property<int>("PatientAge")
                        .HasColumnType("integer");

                    b.Property<string>("PatientCondition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PatientEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Dictionary<string, string>>("PatientName")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MedicalTrack.src.Schedule.Model.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ScheduleId"));

                    b.Property<bool[]>("ScheduleConfirm")
                        .HasColumnType("boolean[]");

                    b.Property<int?>("ScheduleDay")
                        .HasColumnType("integer");

                    b.Property<int>("ScheduleDrugId")
                        .HasColumnType("integer");

                    b.Property<int>("SchedulePatientId")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("ScheduleTime")
                        .HasColumnType("time without time zone");

                    b.HasKey("ScheduleId");

                    b.HasIndex("ScheduleDrugId");

                    b.HasIndex("SchedulePatientId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("MedicalTrack.src.Test.Model.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TestId"));

                    b.Property<int>("TestPatientId")
                        .HasColumnType("integer");

                    b.Property<int>("TestResultBp")
                        .HasColumnType("integer");

                    b.Property<int>("TestResultOxygen")
                        .HasColumnType("integer");

                    b.Property<int>("TestResultSugars")
                        .HasColumnType("integer");

                    b.Property<int>("TestResultWeight")
                        .HasColumnType("integer");

                    b.HasKey("TestId");

                    b.HasIndex("TestPatientId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("MedicalTrack.src.Schedule.Model.Schedule", b =>
                {
                    b.HasOne("MedicalTrack.src.Drug.Model.Drug", "ScheduleDrug")
                        .WithMany("Schedules")
                        .HasForeignKey("ScheduleDrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalTrack.src.Patient.Model.Patient", "SchedulePatient")
                        .WithMany("Schedules")
                        .HasForeignKey("SchedulePatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScheduleDrug");

                    b.Navigation("SchedulePatient");
                });

            modelBuilder.Entity("MedicalTrack.src.Test.Model.Test", b =>
                {
                    b.HasOne("MedicalTrack.src.Patient.Model.Patient", "TestPatient")
                        .WithMany("Tests")
                        .HasForeignKey("TestPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestPatient");
                });

            modelBuilder.Entity("MedicalTrack.src.Drug.Model.Drug", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("MedicalTrack.src.Patient.Model.Patient", b =>
                {
                    b.Navigation("Schedules");

                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
