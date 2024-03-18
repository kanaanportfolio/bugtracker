using BTA.Core.Models;
using Microsoft.EntityFrameworkCore;

public class BtaDbContext : DbContext
{
    public BtaDbContext(DbContextOptions<BtaDbContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>(etb =>
        {
            etb.HasOne(t => t.Project)
               .WithMany(p => p.Tickets)
               .HasForeignKey(t => t.ProjectId);
        });

        modelBuilder.Entity<Ticket>().HasData(
            new List<Ticket>
            {
                new Ticket {
                    Id = 9,
                    Title = "Tricky bug",
                    ProjectId = 1,
                    Owner = "Kanaan",
                    DueDate = new DateTime(2002, 2, 2),
                    EnteredDate = new DateTime(2004, 2, 2)
                },
                new Ticket {
                    Id = 10,
                    Title = "Simple bug",
                    ProjectId = 1,
                    Owner = "Frank",
                    DueDate = new DateTime(2003, 2, 2),
                    EnteredDate = new DateTime(2001, 2, 2)
                },
                new Ticket {
                    Id = 11,
                    Title = "Obvious bug",
                    ProjectId = 2,
                    Owner = "Frank",
                    DueDate = new DateTime(2002, 2, 2),
                    EnteredDate = new DateTime(2004, 2, 2)
                }
            }
        );
        
        modelBuilder.Entity<Project>().HasData(
            new List<Project>
            {
                new Project { Id = 1, Name = "Freshers" },
                new Project { Id = 2, Name = "Seniors" }
            }
        );
    }
}