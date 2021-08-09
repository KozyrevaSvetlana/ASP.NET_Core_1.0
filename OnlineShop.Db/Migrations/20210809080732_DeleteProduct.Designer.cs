﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Db;

namespace OnlineShop.Db.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210809080732_DeleteProduct")]
    partial class DeleteProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompareProduct", b =>
                {
                    b.Property<int>("ComparesId")
                        .HasColumnType("int");

                    b.Property<Guid>("ItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ComparesId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("CompareProduct");
                });

            modelBuilder.Entity("FavoritesProduct", b =>
                {
                    b.Property<int>("FavoritesId")
                        .HasColumnType("int");

                    b.Property<Guid>("ItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FavoritesId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("FavoritesProduct");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserContactId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserContactId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Compare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Compares");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Favorites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Image");

                    b.HasData(
                        new
                        {
                            Id = new Guid("94071aa3-5452-4feb-8246-9a39bd1566ad"),
                            ProductId = new Guid("a3f432a9-17a0-4307-984b-290611a248f5"),
                            Url = "/img/Products/1.jpg"
                        },
                        new
                        {
                            Id = new Guid("43ab8992-9894-409f-b39b-d50e9aa1b119"),
                            ProductId = new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"),
                            Url = "/img/Products/2.jpg"
                        },
                        new
                        {
                            Id = new Guid("ddf85b63-da7e-4a1e-b70b-ffbff17b4b2b"),
                            ProductId = new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"),
                            Url = "/img/Products/3.jpg"
                        },
                        new
                        {
                            Id = new Guid("cb651ccb-187c-4481-bf41-d7f741fe1405"),
                            ProductId = new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"),
                            Url = "/img/Products/3.jpg"
                        },
                        new
                        {
                            Id = new Guid("5bc96938-64d2-4d6a-aced-8f27cc1bb198"),
                            ProductId = new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"),
                            Url = "/img/Products/5.jpg"
                        },
                        new
                        {
                            Id = new Guid("6e18de15-ba9e-4219-8f71-9a6bf6ec9377"),
                            ProductId = new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"),
                            Url = "/img/Products/6.jpg"
                        },
                        new
                        {
                            Id = new Guid("4fc122c4-ba54-4350-85ab-b50c0e176af6"),
                            ProductId = new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"),
                            Url = "/img/Products/6.jpg"
                        },
                        new
                        {
                            Id = new Guid("31349315-168a-4ffe-b700-f3f61307ed34"),
                            ProductId = new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"),
                            Url = "/img/Products/5.jpg"
                        },
                        new
                        {
                            Id = new Guid("01f51329-108a-4719-9c5e-2814b03fd851"),
                            ProductId = new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"),
                            Url = "/img/Products/4.jpg"
                        },
                        new
                        {
                            Id = new Guid("9d4fdad8-37d3-4b99-8f8a-79b6eda1242a"),
                            ProductId = new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"),
                            Url = "/img/Products/3.jpg"
                        },
                        new
                        {
                            Id = new Guid("322f854b-36d5-4239-a271-2e917f6bbbd7"),
                            ProductId = new Guid("615496eb-0537-4657-8237-f033266a3a57"),
                            Url = "/img/Products/2.jpg"
                        },
                        new
                        {
                            Id = new Guid("d8dae5ad-3e8e-416d-95f5-f80a7a80ee07"),
                            ProductId = new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"),
                            Url = "/img/Products/1.jpg"
                        },
                        new
                        {
                            Id = new Guid("9541f59c-80c9-4529-8b4b-0ca3b116606d"),
                            ProductId = new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"),
                            Url = "/img/Products/2.jpg"
                        },
                        new
                        {
                            Id = new Guid("e04bd3f0-51e9-4436-8b81-330d77469cc6"),
                            ProductId = new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"),
                            Url = "/img/Products/3.jpg"
                        },
                        new
                        {
                            Id = new Guid("68f1abd2-4d42-4664-8f0f-e24b09888535"),
                            ProductId = new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"),
                            Url = "/img/Products/4.jpg"
                        },
                        new
                        {
                            Id = new Guid("79b22ce5-414b-4e82-9409-5ef2adf616f0"),
                            ProductId = new Guid("0794a187-dfea-4807-9259-a7ff279455f2"),
                            Url = "/img/Products/5.jpg"
                        },
                        new
                        {
                            Id = new Guid("326ea53d-6560-4adf-bfc9-694821670496"),
                            ProductId = new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"),
                            Url = "/img/Products/6.jpg"
                        },
                        new
                        {
                            Id = new Guid("72b4e684-3d77-4044-96fa-83a10568db92"),
                            ProductId = new Guid("755221a6-0f45-4e86-9948-6e9f85872734"),
                            Url = "/img/Products/4.jpg"
                        },
                        new
                        {
                            Id = new Guid("b45e6f23-372e-42cb-b027-f64064953f5d"),
                            ProductId = new Guid("133788f9-139f-453e-b543-98b5876c4cb7"),
                            Url = "/img/Products/3.jpg"
                        },
                        new
                        {
                            Id = new Guid("a2fa654a-066d-4988-be96-3d60cf1fb49c"),
                            ProductId = new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"),
                            Url = "/img/Products/1.jpg"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("InfoStatus")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a3f432a9-17a0-4307-984b-290611a248f5"),
                            Cost = 11426m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                            IsDeleted = false,
                            Name = "Пистолетик"
                        },
                        new
                        {
                            Id = new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"),
                            Cost = 11426m,
                            Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim",
                            IsDeleted = false,
                            Name = "Шапка"
                        },
                        new
                        {
                            Id = new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"),
                            Cost = 10398m,
                            Description = "Ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ",
                            IsDeleted = false,
                            Name = "Конструктор"
                        },
                        new
                        {
                            Id = new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"),
                            Cost = 94608m,
                            Description = "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate",
                            IsDeleted = false,
                            Name = "Пистолетик"
                        },
                        new
                        {
                            Id = new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"),
                            Cost = 83000m,
                            Description = "Velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat",
                            IsDeleted = false,
                            Name = "Мишка"
                        },
                        new
                        {
                            Id = new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"),
                            Cost = 38020m,
                            Description = "cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                            IsDeleted = false,
                            Name = "Пирамидка"
                        },
                        new
                        {
                            Id = new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"),
                            Cost = 59657m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing",
                            IsDeleted = false,
                            Name = "Трусы"
                        },
                        new
                        {
                            Id = new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"),
                            Cost = 73815m,
                            Description = "Ex ea commodo consequat.Duis aute irure dolor",
                            IsDeleted = false,
                            Name = "Пистолетик"
                        },
                        new
                        {
                            Id = new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"),
                            Cost = 66068m,
                            Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna ",
                            IsDeleted = false,
                            Name = "Пистолетик"
                        },
                        new
                        {
                            Id = new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"),
                            Cost = 51625m,
                            Description = "Velit esse cillum dolore eu fugiat nulla pariatur.E",
                            IsDeleted = false,
                            Name = "Ложка"
                        },
                        new
                        {
                            Id = new Guid("615496eb-0537-4657-8237-f033266a3a57"),
                            Cost = 76311m,
                            Description = "Velit esse cillum dolore eu fugiat nulla pariatur.",
                            IsDeleted = false,
                            Name = "Пистолетик"
                        },
                        new
                        {
                            Id = new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"),
                            Cost = 12248m,
                            Description = "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in v",
                            IsDeleted = false,
                            Name = "Соска"
                        },
                        new
                        {
                            Id = new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"),
                            Cost = 4225m,
                            Description = "Ex ea commodo consequat.Duis aute i ",
                            IsDeleted = false,
                            Name = "Ложка"
                        },
                        new
                        {
                            Id = new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"),
                            Cost = 54643m,
                            Description = "Minim veniam, quis nostrud exercitation ullamco laboris ",
                            IsDeleted = false,
                            Name = "Конструктор"
                        },
                        new
                        {
                            Id = new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"),
                            Cost = 18346m,
                            Description = "Velit esse cillum dolore eu fugiat nulla pariatur.",
                            IsDeleted = false,
                            Name = "Шапка"
                        },
                        new
                        {
                            Id = new Guid("0794a187-dfea-4807-9259-a7ff279455f2"),
                            Cost = 94741m,
                            Description = "Ex ea commodo consequat.Duis aute irure dolor in r",
                            IsDeleted = false,
                            Name = "Кукла"
                        },
                        new
                        {
                            Id = new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"),
                            Cost = 6957m,
                            Description = "Velit esse cillum dolore eu fugiat nulla pariatur.",
                            IsDeleted = false,
                            Name = "Кукла"
                        },
                        new
                        {
                            Id = new Guid("755221a6-0f45-4e86-9948-6e9f85872734"),
                            Cost = 82167m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                            IsDeleted = false,
                            Name = "Ложка"
                        },
                        new
                        {
                            Id = new Guid("133788f9-139f-453e-b543-98b5876c4cb7"),
                            Cost = 82167m,
                            Description = "Velit esse cillum dolore eu fugiat nulla pariatur",
                            IsDeleted = false,
                            Name = "Чашка"
                        },
                        new
                        {
                            Id = new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"),
                            Cost = 88268m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                            IsDeleted = false,
                            Name = "Ползунки"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.UserContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("UserContacts");
                });

            modelBuilder.Entity("CompareProduct", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Compare", null)
                        .WithMany()
                        .HasForeignKey("ComparesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Db.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FavoritesProduct", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Favorites", null)
                        .WithMany()
                        .HasForeignKey("FavoritesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Db.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId");

                    b.HasOne("OnlineShop.Db.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineShop.Db.Models.UserContact", "UserContact")
                        .WithMany()
                        .HasForeignKey("UserContactId");

                    b.Navigation("Cart");

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("UserContact");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", null)
                        .WithMany("Orders")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.UserContact", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Order", "Order")
                        .WithOne("UserContacts")
                        .HasForeignKey("OnlineShop.Db.Models.UserContact", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("UserContacts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Images");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
