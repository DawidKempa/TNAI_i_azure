using System;
using LibrarySystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibrarySystem.Data.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LibrarySystem.Core.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Adam Mickiewicz",
                            ISBN = "123456",
                            IsAvailable = true,
                            Title = "Pan Tadeusz",
                            Year = 1834
                        },
                        new
                        {
                            Id = 2,
                            Author = "Bolesław Prus",
                            ISBN = "234567",
                            IsAvailable = true,
                            Title = "Lalka",
                            Year = 1890
                        },
                        new
                        {
                            Id = 3,
                            Author = "Henryk Sienkiewicz",
                            ISBN = "345678",
                            IsAvailable = true,
                            Title = "Quo Vadis",
                            Year = 1896
                        });
                });

            modelBuilder.Entity("LibrarySystem.Core.Models.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ReaderId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReaderId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("LibrarySystem.Core.Models.Reader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Readers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardNumber = "LIB001",
                            Email = "jan@email.com",
                            FirstName = "Jan",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            Id = 2,
                            CardNumber = "LIB002",
                            Email = "anna@email.com",
                            FirstName = "Anna",
                            LastName = "Nowak"
                        });
                });

            modelBuilder.Entity("LibrarySystem.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("FirstName");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("LastName");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("PasswordHash");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("RegisterDate");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Role");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibrarySystem.Core.Models.Loan", b =>
                {
                    b.HasOne("LibrarySystem.Core.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibrarySystem.Core.Models.Reader", "Reader")
                        .WithMany()
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Reader");
                });
#pragma warning restore 612, 618
        }
    }
}
