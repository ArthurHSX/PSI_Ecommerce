﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSI_Ecommerce.Context;

namespace PSI_Ecommerce.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    [Migration("20201107142604_CreateEcommerceDB")]
    partial class CreateEcommerceDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PSI_Ecommerce.Models.Anuncio", b =>
                {
                    b.Property<int>("IdAnuncio")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<int?>("ID");

                    b.Property<string>("TituloAnuncio");

                    b.Property<double>("Valor");

                    b.HasKey("IdAnuncio");

                    b.HasIndex("ID");

                    b.ToTable("Anuncio");
                });

            modelBuilder.Entity("PSI_Ecommerce.Models.Avaliacao", b =>
                {
                    b.Property<int>("ID");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nota");

                    b.HasKey("ID");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("PSI_Ecommerce.Models.Comentario", b =>
                {
                    b.Property<int>("ID");

                    b.Property<int?>("ComentarioPaiID");

                    b.Property<string>("Descricao");

                    b.HasKey("ID");

                    b.HasIndex("ComentarioPaiID");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("PSI_Ecommerce.Models.Contato", b =>
                {
                    b.Property<int>("ID");

                    b.Property<string>("TelefoneFixo");

                    b.Property<string>("TelefoneMovel");

                    b.HasKey("ID");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("PSI_Ecommerce.Models.Foto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnuncioIdAnuncio");

                    b.Property<byte[]>("Imagem");

                    b.Property<int?>("UsuarioID");

                    b.HasKey("ID");

                    b.HasIndex("AnuncioIdAnuncio");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("PSI_Ecommerce.Models.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("PSI_Ecommerce.Models.Anuncio", b =>
                {
                    b.HasOne("PSI_Ecommerce.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("ID");
                });

            modelBuilder.Entity("PSI_Ecommerce.Models.Avaliacao", b =>
                {
                    b.HasOne("PSI_Ecommerce.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PSI_Ecommerce.Models.Anuncio", "Anuncio")
                        .WithMany()
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PSI_Ecommerce.Models.Comentario", b =>
                {
                    b.HasOne("PSI_Ecommerce.Models.Comentario", "ComentarioPai")
                        .WithMany()
                        .HasForeignKey("ComentarioPaiID");

                    b.HasOne("PSI_Ecommerce.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PSI_Ecommerce.Models.Anuncio", "Anuncio")
                        .WithMany()
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PSI_Ecommerce.Models.Contato", b =>
                {
                    b.HasOne("PSI_Ecommerce.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PSI_Ecommerce.Models.Foto", b =>
                {
                    b.HasOne("PSI_Ecommerce.Models.Anuncio", "Anuncio")
                        .WithMany()
                        .HasForeignKey("AnuncioIdAnuncio");

                    b.HasOne("PSI_Ecommerce.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID");
                });
#pragma warning restore 612, 618
        }
    }
}