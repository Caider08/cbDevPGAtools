using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using cbDevPGAtools.Data;

namespace cbDevPGAtools.Migrations
{
    [DbContext(typeof(cbDevPGAtoolsDbContext))]
    partial class cbDevPGAtoolsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("cbDevPGAtools.Models.DKtourney", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("DKT");
                });

            modelBuilder.Entity("cbDevPGAtools.Models.Golfer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DkTourneyID");

                    b.Property<double>("Exposure");

                    b.Property<string>("GameInfo");

                    b.Property<string>("Name");

                    b.Property<int>("Playerid");

                    b.Property<int>("Salary");

                    b.Property<string>("Website");

                    b.Property<int>("YearCreated");

                    b.HasKey("ID");

                    b.HasIndex("DkTourneyID");

                    b.ToTable("GOLFER");
                });

            modelBuilder.Entity("cbDevPGAtools.Models.Golfer", b =>
                {
                    b.HasOne("cbDevPGAtools.Models.DKtourney")
                        .WithMany("Participants")
                        .HasForeignKey("DkTourneyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
