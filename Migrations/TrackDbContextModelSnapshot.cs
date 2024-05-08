﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrackAPI.Data;

#nullable disable

namespace TrackAPI.Migrations
{
    [DbContext(typeof(TrackDbContext))]
    partial class TrackDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BatchUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BatchId");

                    b.HasIndex("BatchId");

                    b.ToTable("BatchUser");
                });

            modelBuilder.Entity("TrackAPI.Models.Batch", b =>
                {
                    b.Property<int>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BatchId"));

                    b.Property<byte[]>("AttendanceExcel")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("BatchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Employee_info_Excel")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("MentorId")
                        .HasColumnType("int");

                    b.HasKey("BatchId");

                    b.HasIndex("MentorId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("TrackAPI.Models.DailyUpdate", b =>
                {
                    b.Property<int>("DailyUpdateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DailyUpdateId"));

                    b.Property<string>("Challenge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LearnedToday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OneDriveLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanForTomorrow")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DailyUpdateId");

                    b.HasIndex("UserId");

                    b.ToTable("DailyUpdates");
                });

            modelBuilder.Entity("TrackAPI.Models.FeedBack", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("TotalAverageRating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.HasIndex("TaskId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("TrackAPI.Models.Rating", b =>
                {
                    b.Property<long>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RatingId"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FeedbackId")
                        .HasColumnType("int");

                    b.Property<int>("RatedBy")
                        .HasColumnType("int");

                    b.Property<int>("RatedTo")
                        .HasColumnType("int");

                    b.Property<int>("RatingValue")
                        .HasColumnType("int");

                    b.Property<int>("TaskSubmissionId")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("FeedbackId");

                    b.HasIndex("RatedBy");

                    b.HasIndex("RatedTo");

                    b.HasIndex("TaskSubmissionId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("TrackAPI.Models.SubTask", b =>
                {
                    b.Property<int>("SubTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubTaskId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FileUploadTaskPdf")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubTaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("SubTask");
                });

            modelBuilder.Entity("TrackAPI.Models.TaskSubmissions", b =>
                {
                    b.Property<int>("TaskSubmissionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskSubmissionsId"));

                    b.Property<byte[]>("FileUploadSubmission")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("SubTaskSubmitteddOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("submittedFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subtaskid")
                        .HasColumnType("int");

                    b.HasKey("TaskSubmissionsId");

                    b.ToTable("TaskSubmissions");
                });

            modelBuilder.Entity("TrackAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<double>("Attendance_Count")
                        .HasColumnType("float");

                    b.Property<string>("CapgeminiEmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Doj")
                        .HasColumnType("datetime2");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EarlierMentorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinalMentorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCr")
                        .HasColumnType("bit");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalEmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<double>("Total_Average_RatingStatus")
                        .HasColumnType("float");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserTaskID")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserTaskID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TrackAPI.Models.UserTask", b =>
                {
                    b.Property<int>("UserTaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTaskID"));

                    b.Property<int>("AssignedBy")
                        .HasColumnType("int");

                    b.Property<string>("AssignedTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTaskID");

                    b.HasIndex("AssignedBy");

                    b.HasIndex("BatchId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("BatchUser", b =>
                {
                    b.HasOne("TrackAPI.Models.Batch", null)
                        .WithMany()
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TrackAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TrackAPI.Models.Batch", b =>
                {
                    b.HasOne("TrackAPI.Models.User", "Mentor")
                        .WithMany()
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("TrackAPI.Models.DailyUpdate", b =>
                {
                    b.HasOne("TrackAPI.Models.User", "User")
                        .WithMany("DailyUpdates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrackAPI.Models.FeedBack", b =>
                {
                    b.HasOne("TrackAPI.Models.UserTask", "UserTask")
                        .WithOne("FeedBack")
                        .HasForeignKey("TrackAPI.Models.FeedBack", "TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrackAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserTask");
                });

            modelBuilder.Entity("TrackAPI.Models.Rating", b =>
                {
                    b.HasOne("TrackAPI.Models.FeedBack", "FeedBack")
                        .WithMany("Ratings")
                        .HasForeignKey("FeedbackId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TrackAPI.Models.User", "RatedByUser")
                        .WithMany()
                        .HasForeignKey("RatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TrackAPI.Models.User", "RatedToUser")
                        .WithMany()
                        .HasForeignKey("RatedTo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TrackAPI.Models.TaskSubmissions", "TaskSubmissions")
                        .WithMany()
                        .HasForeignKey("TaskSubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeedBack");

                    b.Navigation("RatedByUser");

                    b.Navigation("RatedToUser");

                    b.Navigation("TaskSubmissions");
                });

            modelBuilder.Entity("TrackAPI.Models.SubTask", b =>
                {
                    b.HasOne("TrackAPI.Models.UserTask", "UserTask")
                        .WithMany("SubTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserTask");
                });

            modelBuilder.Entity("TrackAPI.Models.User", b =>
                {
                    b.HasOne("TrackAPI.Models.UserTask", null)
                        .WithMany("AssignedToUser")
                        .HasForeignKey("UserTaskID");
                });

            modelBuilder.Entity("TrackAPI.Models.UserTask", b =>
                {
                    b.HasOne("TrackAPI.Models.User", "AssignedByUser")
                        .WithMany()
                        .HasForeignKey("AssignedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TrackAPI.Models.Batch", null)
                        .WithMany("UserTask")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedByUser");
                });

            modelBuilder.Entity("TrackAPI.Models.Batch", b =>
                {
                    b.Navigation("UserTask");
                });

            modelBuilder.Entity("TrackAPI.Models.FeedBack", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("TrackAPI.Models.User", b =>
                {
                    b.Navigation("DailyUpdates");
                });

            modelBuilder.Entity("TrackAPI.Models.UserTask", b =>
                {
                    b.Navigation("AssignedToUser");

                    b.Navigation("FeedBack");

                    b.Navigation("SubTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
