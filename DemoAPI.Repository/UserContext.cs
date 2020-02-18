using DemoAPI.Core.Contracts;
using DemoAPI.Core.Model;
using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.DataAccess.SQL
{
    public class DataContext: DbContext ,IDataContext
    {

        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user_table = modelBuilder.Entity<User>();
            user_table
                .ToTable("Users");
            user_table
              .HasKey(n => n.Id);
            user_table
                .Property(n => n.UserName);
            user_table
              .Property(n => n.Email)
              .IsRequired();
            user_table
              .Property(n => n.MobilePhone)
              .IsRequired();
            user_table
                .Property(n => n.Password)
                .IsRequired();
            user_table
                .Property(n => n.FirstName);
            user_table
                .Property(n => n.LastName);
            user_table
                .Property(n => n.Role);
            user_table.Property(t => t.CreatedDateTime).HasColumnType("DateTime");
            user_table.Property(n => n.ModifiedDateTime).HasColumnType("DateTime");
            var survey_table = modelBuilder.Entity<Survey>();
            survey_table
                .ToTable("Survey");
            survey_table
              .HasKey(n => n.Id);
            survey_table
                .Property(n => n.Name);
            survey_table
              .Property(n => n.SurveyQuestion)
              .IsRequired();
            survey_table
              .Property(n => n.Description)
              .IsRequired();
            survey_table
                .Property(n => n.CreatedBy)
                .IsRequired();
            survey_table
                .Property(n => n.Category)
                .IsRequired();
            survey_table.Property(n => n.SurveyDate).HasColumnType("DateTime");
            survey_table.Property(t => t.CreatedDateTime).HasColumnType("DateTime");
            survey_table.Property(n => n.ModifiedDateTime).HasColumnType("DateTime");

            var feedback_table = modelBuilder.Entity<Feedback>(entity =>
            {
                entity
                    .ToTable("Feedback");
                entity
                  .HasKey(n => n.Id);
                entity
                    .Property(n => n.Name);
                entity
                  .Property(n => n.Age);
                entity
                  .Property(n => n.Comment)
                  .IsRequired();
                entity
                   .Property(n => n.CreatedBy)
                   .IsRequired();
                entity
                   .Property(n => n.Evaluation)
                   .IsRequired();
                entity
                   .Property(n => n.Gender)
                   .IsRequired();
                entity
                   .Property(n => n.SurveyId)
                   .IsRequired();
                entity
                    .Property(n => n.Occupation)
                    .IsRequired();
                entity.Property(n => n.CommentDateTime).HasColumnType("DateTime");
                entity.Property(t => t.CreatedDateTime).HasColumnType("DateTime");
                entity.Property(n => n.ModifiedDateTime).HasColumnType("DateTime");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("FK_Feedback_Survey");
            });



        }
    }

}
