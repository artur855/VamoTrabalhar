﻿// <auto-generated />
using System;
using Hospital.Domain.Entities;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Infra.Data.Migrations
{
    [DbContext(typeof(HospitalContext))]
    partial class HospitalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Hospital.Domain.Entities.ExamRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("ExamName")
                        .HasColumnName("exame");

                    b.Property<DateTime>("ExpectedDate")
                        .HasColumnName("data_prevista");

                    b.Property<string>("Hypothesis")
                        .HasColumnName("hipotese_cid");

                    b.Property<int>("MedicId")
                        .HasColumnName("id_medico");

                    b.Property<int>("PatientId")
                        .HasColumnName("id_paciente");

                    b.Property<string>("Recomendation")
                        .HasColumnName("recomendacao");

                    b.HasKey("Id");

                    b.HasIndex("MedicId");

                    b.HasIndex("PatientId");

                    b.ToTable("tb_pedidos_exames");
                });

            modelBuilder.Entity("Hospital.Domain.Entities.Medic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnName("crm");

                    b.Property<int>("UserId")
                        .HasColumnName("id_usuario");

                    b.Property<int>("tipo_medico");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("tb_medicos");

                    b.HasDiscriminator<int>("tipo_medico").HasValue(0);
                });

            modelBuilder.Entity("Hospital.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnName("dt_nasc");

                    b.Property<int>("Color")
                        .HasColumnName("cor");

                    b.Property<char>("Sex")
                        .HasColumnName("sexo");

                    b.Property<int>("UserId")
                        .HasColumnName("id_usuario");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("tb_pacientes");
                });

            modelBuilder.Entity("Hospital.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasColumnName("nome");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.ToTable("tb_usuarios");
                });

            modelBuilder.Entity("Hospital.Domain.Entities.Docent", b =>
                {
                    b.HasBaseType("Hospital.Domain.Entities.Medic");

                    b.Property<string>("Titulation")
                        .HasColumnName("titulacao")
                        .HasColumnType("VARCHAR(45)");

                    b.ToTable("tb_medicos");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Hospital.Domain.Entities.Resident", b =>
                {
                    b.HasBaseType("Hospital.Domain.Entities.Medic");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnName("ano_inicio")
                        .HasColumnType("DATE");

                    b.ToTable("tb_medicos");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Hospital.Domain.Entities.ExamRequest", b =>
                {
                    b.HasOne("Hospital.Domain.Entities.Medic", "Medic")
                        .WithMany("ExamRequests")
                        .HasForeignKey("MedicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hospital.Domain.Entities.Patient", "Patient")
                        .WithMany("ExamRequests")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hospital.Domain.Entities.Medic", b =>
                {
                    b.HasOne("Hospital.Domain.Entities.User", "User")
                        .WithOne("Medic")
                        .HasForeignKey("Hospital.Domain.Entities.Medic", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hospital.Domain.Entities.Patient", b =>
                {
                    b.HasOne("Hospital.Domain.Entities.User", "User")
                        .WithOne("Patient")
                        .HasForeignKey("Hospital.Domain.Entities.Patient", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
