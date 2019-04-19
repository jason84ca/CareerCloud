using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext:DbContext
    {
        public CareerCloudContext(bool createProxy = true) :
            base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {     
            Database.Log = l => System.Diagnostics.Debug.WriteLine(l);
            Configuration.ProxyCreationEnabled = false;
            Configuration.ProxyCreationEnabled = createProxy;
        }
        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SercurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantEducations)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e=>e.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantResumes)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant);
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantSkills)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant);
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantWorkHistorys)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant);
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantJobApplications)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant);
                        
            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(a => a.SecurityLoginsLogs)
                .WithRequired(e => e.SecurityLogins)
                .HasForeignKey(e => e.Login);
            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(a => a.SecurityLoginsRoles)
                .WithRequired(e => e.SecurityLogins)
                .HasForeignKey(e => e.Login);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(a => a.ApplicantProfiles)
                .WithRequired(e => e.SecurityLogins)
                .HasForeignKey(e => e.Login);

            modelBuilder.Entity<SecurityRolePoco>()
                .HasMany(a => a.SecurityLoginsRoles)
                .WithRequired(e => e.SecurityRoles)
                .HasForeignKey(e => e.Role);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(a => a.ApplicantProfiles)
                .WithRequired(e => e.SystemCountryCodes)
                .HasForeignKey(e => e.Country);
            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(a => a.ApplicantWorkHistorys)
                .WithRequired(e => e.SystemCountryCodes)
                .HasForeignKey(e => e.CountryCode);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(a => a.ApplicantJobApplications)
                .WithRequired(e => e.CompanyJobs)
                .HasForeignKey(e => e.Job);
            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(a => a.CompanyJobSkills)
                .WithRequired(e => e.CompanyJobs)
                .HasForeignKey(e => e.Job);
            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(a => a.CompanyJobEducations)
                .WithRequired(e => e.CompanyJobs)
                .HasForeignKey(e => e.Job);
            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(a => a.CompanyJobDescriptions)
                .WithRequired(e => e.CompanyJobs)
                .HasForeignKey(e => e.Job);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(a => a.CompanyJobs)
                .WithRequired(e => e.CompanyProfiles)
                .HasForeignKey(e => e.Company);
            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(a => a.CompanyLocations)
                .WithRequired(e => e.CompanyProfiles)
                .HasForeignKey(e => e.Company);
            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(a => a.CompanyDescriptions)
                .WithRequired(e => e.CompanyProfiles)
                .HasForeignKey(e => e.Company);

            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasMany(a => a.CompanyDescriptions)
                .WithRequired(e => e.SystemLanguageCodes)
                .HasForeignKey(e => e.LanguageId);
            
           base.OnModelCreating(modelBuilder);
        }
    }
}
