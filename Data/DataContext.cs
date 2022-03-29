using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quiz_api.Models;

namespace Quiz_api.Data
{
    public class DataContext: IdentityDbContext<AppUser, Role, Guid>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Attempt> Attempts{get; set;}
        public DbSet<AttemptLines> AttemptLines {get; set;}
        public DbSet<Quiz> Quizzes{get; set;}
        public DbSet<QuizImage> QuizImages {get; set;}
        public DbSet<Option> Options{get; set;}
        public DbSet<OptionImage> OptionImages {get; set;}
        
      protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);


            builder.Entity<QuizImage>()
                .HasOne(p=> p.Quiz)
                .WithMany(b => b.QuizImages);

            builder.Entity<OptionImage>()
                .HasOne(P=> P.option)
                .WithMany(b=> b.OptionImages);


            builder.Entity<Option>()
                .HasOne(p=> p.Quiz)
                .WithMany(b => b.options);


            builder.Entity<Attempt>()
                .HasOne(U => U.AppUser)
                .WithMany(b => b.attempts);

            //Many to Many Relationship

            builder.Entity<AttemptLines>()
                .HasKey(t=> new {t.AttemptID, t.QuizID});

            builder.Entity<AttemptLines>()
                .HasOne(A => A.Attempt)
                .WithMany(Q=> Q.Attemptlines)
                .HasForeignKey(pt => pt.QuizID);

            builder.Entity<AttemptLines>()
                .HasOne(Q => Q.Quiz)
                .WithMany(al => al.attemptLines)
                .HasForeignKey(pt => pt.AttemptID);
        }
    }
   
}