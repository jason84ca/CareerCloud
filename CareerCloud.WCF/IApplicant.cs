using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CareerCloud.WCF
{
    [ServiceContract]
    public interface IApplicant
    {
        // ApplicantEducationPoco
        [OperationContract]
        void AddApplicantEducation(ApplicantEducationPoco[] item);
        [OperationContract]
        List<ApplicantEducationPoco> GetAllApplicantEducation();
        [OperationContract]
        ApplicantEducationPoco GetSingleApplicantEducation(string Id);
        [OperationContract]
        void RemoveApplicantEducation(ApplicantEducationPoco[] item);
        [OperationContract]
        void UpdateApplicantEducation(ApplicantEducationPoco[] items);

        // ApplicantJobApplicationPoco
        [OperationContract]
        void AddApplicantJobApplication(ApplicantJobApplicationPoco[] item);
        [OperationContract]
        List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication();
        [OperationContract]
        ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string Id);
        [OperationContract]
        void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] items);
        [OperationContract]
        void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items);

        // ApplicantProfilePoco
        [OperationContract]
        void AddApplicantProfile(ApplicantProfilePoco[] item);
        [OperationContract]
        List<ApplicantProfilePoco> GetAllApplicantProfile();
        [OperationContract]
        ApplicantProfilePoco GetSingleApplicantProfile(string Id);
        [OperationContract]
        void RemoveApplicantProfile(ApplicantProfilePoco[] items);
        [OperationContract]
        void UpdateApplicantProfile(ApplicantProfilePoco[] items);

        // ApplicantResumePoco
        [OperationContract]
        void AddApplicantResume(ApplicantResumePoco[] item);
        [OperationContract]
        List<ApplicantResumePoco> GetAllApplicantResume();
        [OperationContract]
        ApplicantResumePoco GetSingleApplicantResume(string Id);
        [OperationContract]
        void RemoveApplicantResume(ApplicantResumePoco[] items);
        [OperationContract]
        void UpdateApplicantResume(ApplicantResumePoco[] items);

        // ApplicantSkillPoco
        [OperationContract]
        void AddApplicantSkill(ApplicantSkillPoco[] item);
        [OperationContract]
        List<ApplicantSkillPoco> GetAllApplicantSkill();
        [OperationContract]
        ApplicantSkillPoco GetSingleApplicantSkill(string Id);
        [OperationContract]
        void RemoveApplicantSkill(ApplicantSkillPoco[] items);
        [OperationContract]
        void UpdateApplicantSkill(ApplicantSkillPoco[] items);

        // ApplicantWorkHistoryPoco
        [OperationContract]
        void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] item);
        [OperationContract]
        List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory();
        [OperationContract]
        ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string Id);
        [OperationContract]
        void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);
        [OperationContract]
        void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);
    }  
}
