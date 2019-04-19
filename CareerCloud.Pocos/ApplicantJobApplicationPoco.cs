﻿using System;
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
    [Table ("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco:IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        public Guid Applicant { get; set; }
        [DataMember]
        public Guid Job { get; set; }
        [DataMember]
        [Column ("Application_Date")]
        public DateTime ApplicationDate { get; set; }
        [DataMember]
        [Column ("Time_Stamp")]
        [Timestamp, NotMapped]
        public byte[] TimeStamp { get; set; }
        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }
        public virtual CompanyJobPoco CompanyJobs { get; set; }
    }
}
