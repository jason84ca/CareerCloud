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
    [Table ("Company_Descriptions")]
    public class CompanyDescriptionPoco:IPoco
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        [DataMember]
        [Column ("Company_Name")]
        public string CompanyName { get; set; }
        [DataMember]
        [Column ("Company_Description")]
        public string CompanyDescription { get; set; }
        [DataMember]
        [Column ("Time_Stamp")]
        [Timestamp,NotMapped]
        public byte[] TimeStamp { get; set; }
        [DataMember]
        public Guid Company { get; set; }
        [DataMember]
        public string LanguageId { get; set; }
        
        public virtual CompanyProfilePoco CompanyProfiles { get; set; }
        public virtual SystemLanguageCodePoco SystemLanguageCodes { get; set; }
    }
}
