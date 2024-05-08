using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TrackAPI.Models;
using static TrackAPI.Models.TaskSubmissions;

namespace TrackAPI.Data
{
    public class TrackDbContext : DbContext
    {

    public TrackDbContext(DbContextOptions<TrackDbContext> options)
            : base(options){}
    public DbSet<User> Users { get; set; }
    public DbSet<Batch> Batches { get; set; }
//SubTask
    public DbSet<UserTask> Tasks { get; set; }
    public DbSet<SubTask> SubTask { get; set; }
    public DbSet<FeedBack> FeedBacks { get; set; }
    public DbSet<DailyUpdate> DailyUpdates { get; set; }

    //changed
    public DbSet<TaskSubmissions> TaskSubmissions {get;set;}

     public DbSet<Rating>Ratings {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the relationship between User and Batch
         modelBuilder.Entity<Batch>()
            .HasOne(b => b.Mentor)                
            .WithMany()                           
            .HasForeignKey(b => b.MentorId);     

        // Define the many-to-many relationship between Batch and Employees (Users)
       modelBuilder.Entity<User>()
        .HasMany(u => u.Batches)
        .WithMany(b => b.Employees)
        .UsingEntity<Dictionary<string, object>>(
            j => j
                .HasOne<Batch>()
                .WithMany()
                .HasForeignKey("BatchId")
                .OnDelete(DeleteBehavior.Restrict), // Specify the OnDelete behavior
            j => j
                .HasOne<User>()
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Restrict), // Specify the OnDelete behavior
            j =>
            {
                j.HasKey("UserId", "BatchId"); // Define the composite primary key
            });

         modelBuilder.Entity<UserTask>()
        .HasOne(t => t.AssignedByUser)
        .WithMany()
        .HasForeignKey(t => t.AssignedBy)
        .OnDelete(DeleteBehavior.Restrict); // Specify the OnDelete behavior

   

    // Define relationship between Task and SubTask
    modelBuilder.Entity<SubTask>()
        .HasOne(st => st.UserTask)
        .WithMany(t => t.SubTasks)
        .HasForeignKey(st => st.TaskId)
        .OnDelete(DeleteBehavior.Cascade); // Specify the OnDelete behavior if needed

      modelBuilder.Entity<FeedBack>()
        .HasOne(f => f.UserTask) // Specify the navigation property for Task in Feedback
        .WithOne(t => t.FeedBack) // Specify the navigation property for Feedback in Task
        .HasForeignKey<FeedBack>(f => f.TaskId) // Specify the foreign key property in Feedback
        .OnDelete(DeleteBehavior.Cascade);// Specify the OnDelete behavior if needed

    // Define relationship between Feedback and User
    modelBuilder.Entity<FeedBack>()
        .HasOne(f => f.User)
        .WithMany()
        .HasForeignKey(f => f.UserId)
        .OnDelete(DeleteBehavior.Restrict); // Specify the OnDelete behavior if needed

    // Define relationship between Feedback and Rating (assuming one-to-many)
    modelBuilder.Entity<FeedBack>()
        .HasMany(f => f.Ratings)
        .WithOne(f=>f.FeedBack) // Assuming there's no navigation property in Rating pointing back to Feedback
        .HasForeignKey(r => r.FeedbackId)
.OnDelete(DeleteBehavior.Restrict); 

     // Define the relationship between DailyUpdate and User
    modelBuilder.Entity<DailyUpdate>()
        .HasOne(d => d.User)                    // DailyUpdate has one User
        .WithMany(u => u.DailyUpdates)          // User can have many DailyUpdates
        .HasForeignKey(d => d.UserId)
        .OnDelete(DeleteBehavior.Restrict);

        // Define the relationship between Rating and RatedByUser (User)
modelBuilder.Entity<Rating>()
    .HasOne(r => r.RatedByUser)
    .WithMany()
    .HasForeignKey(r => r.RatedBy)
    .OnDelete(DeleteBehavior.Restrict);

    // Define the relationship between Rating and RatedToUser (User)
modelBuilder.Entity<Rating>()
    .HasOne(r => r.RatedToUser)
    .WithMany()
    .HasForeignKey(r => r.RatedTo)
    .OnDelete(DeleteBehavior.Restrict);

    // Define the relationship between Rating and TaskSubmissions
modelBuilder.Entity<Rating>()
    .HasOne(r => r.TaskSubmissions)
    .WithMany() // Assuming TaskSubmissions can have multiple ratings
    .HasForeignKey(r => r.TaskSubmissionId)
    .OnDelete(DeleteBehavior.Cascade); // Specify the OnDelete behavior if needed

    // Define the relationship between Rating and FeedBack
modelBuilder.Entity<Rating>()
    .HasOne(r => r.FeedBack)
    .WithMany(f => f.Ratings)
    .HasForeignKey(r => r.FeedbackId)
    .OnDelete(DeleteBehavior.Restrict);
    base.OnModelCreating(modelBuilder);   
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
      if (!optionsBuilder.IsConfigured)
      {
          optionsBuilder.UseSqlServer("YourConnectionString")
              .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name })
              .EnableSensitiveDataLogging();
}}}}