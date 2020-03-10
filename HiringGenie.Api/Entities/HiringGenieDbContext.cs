using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HiringGenie.Api.Entities
{
    public class HiringGenieDbContext
        : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
        ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public HiringGenieDbContext(DbContextOptions<HiringGenieDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();


            });

            builder.Entity<Job>(job =>
            {
                job.HasKey(j => j.Id);

                job.HasOne(c => c.PostedByUser).WithMany(c => c.PostedJobs).HasForeignKey(c => c.PostedBy);

                job.HasMany(c => c.Applications).WithOne(c => c.Job).HasForeignKey(c => c.JobId);
            });

            builder.Entity<Application>(application =>
            {
                application.HasKey(j => j.Id);

                application.HasOne(c => c.PostedByUser).WithMany(c => c.PostedApplications).HasForeignKey(c => c.PostedBy);
            });

            builder.Entity<Interview>(interview =>
            {
                interview.HasKey(j => j.Id);

                interview.HasOne(c => c.Interviewer).WithMany(c => c.Interviews).HasForeignKey(c => c.InterviewerId);

                interview.HasOne(c => c.Application).WithMany(c => c.Interviews).HasForeignKey(c => c.ApplicationId);

                interview.HasOne(s => s.CurrentScheduler).WithOne(ad => ad.Interview).HasForeignKey<Interview>(c => c.SchedulerId);
            });

            builder.Entity<Scheduler>(schedule =>
            {
                schedule.HasKey(j => j.Id);
            });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).LastModifiedOn = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedOn = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }

        public virtual DbSet<Application> Applications { get; set; }

        public virtual DbSet<Interview> Interviews { get; set; }

        public virtual DbSet<Job> Jobs { get; set; }

        public virtual DbSet<Scheduler> Schedulers { get; set; }
    }
}
