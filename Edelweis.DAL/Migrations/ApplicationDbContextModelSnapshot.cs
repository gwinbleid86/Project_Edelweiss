﻿// <auto-generated />
using System;
using Edelweiss.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Edelweiss.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Edelweiss.DAL.Entities.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("ImageLogo");

                    b.Property<string>("ImagePromo");

                    b.Property<bool>("IsBlocked");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentAgentId");

                    b.Property<string>("TextPromo");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("ParentAgentId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.CellPhoneMask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellPhone");

                    b.Property<int>("CountryId");

                    b.Property<int>("Mask");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("CellPhoneMasks");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName");

                    b.Property<string>("MobilePhone");

                    b.Property<string>("Name");

                    b.Property<string>("PassportData");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.Commission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgentId");

                    b.Property<int>("TransactionId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("TransactionId");

                    b.ToTable("Commissions");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.CommissionDividing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AgentFromCommission");

                    b.Property<decimal>("AgentToCommission");

                    b.Property<decimal>("SystemCommission");

                    b.HasKey("Id");

                    b.ToTable("CommissionDividing");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountQty");

                    b.Property<string>("Name");

                    b.Property<int>("Utc");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.Range", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("MaxValue");

                    b.Property<decimal>("MinValue");

                    b.HasKey("Id");

                    b.ToTable("Ranges");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.SysTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgentFromId");

                    b.Property<int?>("AgentToId");

                    b.Property<int>("ClientFromId");

                    b.Property<int?>("ClientToId");

                    b.Property<DateTime?>("ConfirmDateLocal");

                    b.Property<DateTime?>("ConfirmDateUtc");

                    b.Property<string>("ControllerId");

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("CreateDateLocal");

                    b.Property<DateTime>("CreateDateUtc");

                    b.Property<int>("CurrencyId");

                    b.Property<DateTime?>("IssueDateLocal");

                    b.Property<DateTime?>("IssueDateUtc");

                    b.Property<decimal>("Sum");

                    b.Property<string>("Tcn");

                    b.Property<int>("TransactionStatus");

                    b.Property<string>("UserFromId");

                    b.Property<string>("UserToId");

                    b.HasKey("Id");

                    b.HasIndex("AgentFromId");

                    b.HasIndex("AgentToId");

                    b.HasIndex("ClientFromId");

                    b.HasIndex("ClientToId");

                    b.HasIndex("CountryId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.Tariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgentId");

                    b.Property<int>("CommissionType");

                    b.Property<int>("CountryId");

                    b.Property<int>("CurrencyId");

                    b.Property<int?>("RangeId");

                    b.Property<DateTime>("StartTime");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("CountryId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("RangeId");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("AgentId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsBlocked");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<DateTime>("NextPasswordChangedDate");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("RecoveryRole");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.Agent", b =>
                {
                    b.HasOne("Edelweiss.DAL.Entities.Country", "Country")
                        .WithMany("Agents")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edelweiss.DAL.Entities.Agent", "ParentAgent")
                        .WithMany()
                        .HasForeignKey("ParentAgentId");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.CellPhoneMask", b =>
                {
                    b.HasOne("Edelweiss.DAL.Entities.Country", "Country")
                        .WithMany("CellPhoneMasks")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.Commission", b =>
                {
                    b.HasOne("Edelweiss.DAL.Entities.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edelweiss.DAL.Entities.SysTransaction", "Transaction")
                        .WithMany("Commissions")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.SysTransaction", b =>
                {
                    b.HasOne("Edelweiss.DAL.Entities.Agent", "AgentFrom")
                        .WithMany("SysTransactionsFrom")
                        .HasForeignKey("AgentFromId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edelweiss.DAL.Entities.Agent", "AgentTo")
                        .WithMany("SysTransactionsTo")
                        .HasForeignKey("AgentToId");

                    b.HasOne("Edelweiss.DAL.Entities.Client", "ClientFrom")
                        .WithMany("SysTransactionsFrom")
                        .HasForeignKey("ClientFromId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edelweiss.DAL.Entities.Client", "ClientTo")
                        .WithMany("SysTransactionsTo")
                        .HasForeignKey("ClientToId");

                    b.HasOne("Edelweiss.DAL.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edelweiss.DAL.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.Tariff", b =>
                {
                    b.HasOne("Edelweiss.DAL.Entities.Agent", "Agent")
                        .WithMany("Tariffs")
                        .HasForeignKey("AgentId");

                    b.HasOne("Edelweiss.DAL.Entities.Country", "Country")
                        .WithMany("Tariffs")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edelweiss.DAL.Entities.Currency", "Currency")
                        .WithMany("Tariffs")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edelweiss.DAL.Entities.Range", "Range")
                        .WithMany("Tariffs")
                        .HasForeignKey("RangeId");
                });

            modelBuilder.Entity("Edelweiss.DAL.Entities.User", b =>
                {
                    b.HasOne("Edelweiss.DAL.Entities.Agent", "Agent")
                        .WithMany("User")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Edelweiss.DAL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Edelweiss.DAL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edelweiss.DAL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Edelweiss.DAL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
