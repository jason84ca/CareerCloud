using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [DataContract]
    [Table("Applicant_Profiles")]
    public class ApplicantProfilePoco:IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Login { get; set; }
        [DataMember]
        [Column ("Current_Salary")]
        public Decimal? CurrentSalary { get; set; }
        [DataMember]
        [Column("Current_Rate")]
        public Decimal? CurrentRate { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        [Column("Country_Code")]
        public string Country { get; set; }
        [DataMember]
        [Column("State_Province_Code")]
        public string Province { get; set; }
        [DataMember]
        [Column("Street_Address")]
        public string Street { get; set; }
        [DataMember]
        [Column("City_Town")]
        public string City { get; set; }
        [DataMember]
        [Column("Zip_Postal_Code")]
        public string PostalCode { get; set; }
        [DataMember]
        [Column("Time_Stamp")]
        [Timestamp, NotMapped]
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public virtual ICollection<ApplicantResumePoco> ApplicantResumes { get; set; }
        public virtual SecurityLoginPoco SecurityLogins { get; set; }
        public virtual ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCodes { get; set; }
    }
}
