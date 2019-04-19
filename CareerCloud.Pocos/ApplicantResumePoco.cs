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
    [Table ("Applicant_Resumes")]
    public class ApplicantResumePoco:IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]        
        public Guid Applicant { get; set; }
        [DataMember]
        public string Resume { get; set; }
        [DataMember]
        [Column ("Last_Updated")]
        public DateTime? LastUpdated { get; set; }
        public virtual ApplicantProfilePoco ApplicantProfiles { get; set; }
    }
}
