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
    public interface ICompany
    {
        // CompanyDescriptionPoco
        [OperationContract]
        void AddCompanyDescription(CompanyDescriptionPoco[] item);
        [OperationContract]
        List<CompanyDescriptionPoco> GetAllCompanyDescription();
        [OperationContract]
        CompanyDescriptionPoco GetSingleCompanyDescription(string Id);
        [OperationContract]
        void RemoveCompanyDescription(CompanyDescriptionPoco[] items);
        [OperationContract]
        void UpdateCompanyDescription(CompanyDescriptionPoco[] items);

        // CompanyJobDescriptionPoco
        [OperationContract]
        void AddCompanyJobDescription(CompanyJobDescriptionPoco[] item);
        [OperationContract]
        List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription();
        [OperationContract]
        CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string Id);
        [OperationContract]
        void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] items);
        [OperationContract]
        void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] items);

        // CompanyJobEducationPoco
        [OperationContract]
        void AddCompanyJobEducation(CompanyJobEducationPoco[] item);
        [OperationContract]
        List<CompanyJobEducationPoco> GetAllCompanyJobEducation();
        [OperationContract]
        CompanyJobEducationPoco GetSingleCompanyJobEducation(string Id);
        [OperationContract]
        void RemoveCompanyJobEducation(CompanyJobEducationPoco[] items);
        [OperationContract]
        void UpdateCompanyJobEducation(CompanyJobEducationPoco[] items);

        // CompanyJobPoco
        [OperationContract]
        void AddCompanyJob(CompanyJobPoco[] item);
        [OperationContract]
        List<CompanyJobPoco> GetAllCompanyJob();
        [OperationContract]
        CompanyJobPoco GetSingleCompanyJob(string Id);
        [OperationContract]
        void RemoveCompanyJob(CompanyJobPoco[] items);
        [OperationContract]
        void UpdateCompanyJob(CompanyJobPoco[] items);

        // CompanyJobSkillPoco
        [OperationContract]
        void AddCompanyJobSkill(CompanyJobSkillPoco[] item);
        [OperationContract]
        List<CompanyJobSkillPoco> GetAllCompanyJobSkill();
        [OperationContract]
        CompanyJobSkillPoco GetSingleCompanyJobSkill(string Id);
        [OperationContract]
        void RemoveCompanyJobSkill(CompanyJobSkillPoco[] items);
        [OperationContract]
        void UpdateCompanyJobSkill(CompanyJobSkillPoco[] items);

        // CompanyLocationPoco
        [OperationContract]
        void AddCompanyLocation(CompanyLocationPoco[] item);
        [OperationContract]
        List<CompanyLocationPoco> GetAllCompanyLocation();
        [OperationContract]
        CompanyLocationPoco GetSingleCompanyLocation(string Id);
        [OperationContract]
        void RemoveCompanyLocation(CompanyLocationPoco[] items);
        [OperationContract]
        void UpdateCompanyLocation(CompanyLocationPoco[] items);

        // CompanyProfilePoco
        [OperationContract]
        void AddCompanyProfile(CompanyProfilePoco[] item);
        [OperationContract]
        List<CompanyProfilePoco> GetAllCompanyProfile();
        [OperationContract]
        CompanyProfilePoco GetSingleCompanyProfile(string Id);
        [OperationContract]
        void RemoveCompanyProfile(CompanyProfilePoco[] items);
        [OperationContract]
        void UpdateCompanyProfile(CompanyProfilePoco[] items);
    }

}
