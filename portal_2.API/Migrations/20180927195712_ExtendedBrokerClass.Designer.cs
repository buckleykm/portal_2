﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using portal_2.API.Data;

namespace portal_2.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180927195712_ExtendedBrokerClass")]
    partial class ExtendedBrokerClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("portal_2.API.Models.App", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apftnm");

                    b.Property<string>("Apltnm");

                    b.Property<int?>("BrokerId");

                    b.Property<DateTime?>("Placed");

                    b.Property<string>("PolNo");

                    b.Property<DateTime>("Submittd");

                    b.HasKey("Id");

                    b.HasIndex("BrokerId");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("portal_2.API.Models.Broker", b =>
                {
                    b.Property<int>("BrokerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("AffiliateId");

                    b.Property<string>("AltEmail");

                    b.Property<string>("AltPhone");

                    b.Property<int>("BranchId");

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<int>("EntityId");

                    b.Property<string>("Fstname");

                    b.Property<bool>("IsContracted");

                    b.Property<DateTime>("LastActive");

                    b.Property<string>("Lstname");

                    b.Property<DateTime>("ModifyWhen");

                    b.Property<int>("NpnId");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int>("Phone");

                    b.Property<int>("PhoneExt");

                    b.Property<int>("RbmId");

                    b.Property<int>("StateId");

                    b.Property<string>("Username");

                    b.Property<int>("ZipCode");

                    b.HasKey("BrokerId");

                    b.ToTable("Brokers");
                });

            modelBuilder.Entity("portal_2.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("portal_2.API.Models.App", b =>
                {
                    b.HasOne("portal_2.API.Models.Broker")
                        .WithMany("Apps")
                        .HasForeignKey("BrokerId");
                });
#pragma warning restore 612, 618
        }
    }
}
