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
    [Table ("Applicant_Skills")]
    public class ApplicantSkillPoco:IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Applicant { get; set; }
        [DataMember]
        public string Skill { get; set; }
        [DataMember]
        [Column ("Skill_Level")]
        public string SkillLevel { get; set; }
        [DataMember]
        [Column("Start_Month")]
        public byte StartMonth { get; set; }
        [DataMember]
        [Column("Start_Year")]
        public Int32 StartYear { get; set; }
        [DataMember]
        [Column("End_Month")]
        public byte EndMonth { get; set; }
        [DataMember]
        [Column("End_Year")]
        public Int32 EndYear { get; set; }
        [DataMember]
        [Column("Time_Stamp")]
        [Timestamp, NotMapped]
        public byte[] TimeStamp { get; set; }
        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }
    }
}
