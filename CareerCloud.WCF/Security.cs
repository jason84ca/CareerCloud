using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CareerCloud.WCF
{
    public class Security : ISecurity
    {
        public void AddSecurityLogin(SecurityLoginPoco[] item)
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            logic.Add(item);
        }

        public void AddSecurityLoginsLog(SecurityLoginsLogPoco[] item)
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            logic.Add(item);
        }

        public void AddSecurityLoginsRole(SecurityLoginsRolePoco[] item)
        {
            var logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco> (false));
            logic.Add(item);
        }

        public void AddSecurityRole(SecurityRolePoco[] item)
        {
            var logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            logic.Add(item);
        }

        public List<SecurityLoginPoco> GetAllSecurityLogin()
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            return logic.GetAll();
        }

        public List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog()
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            return logic.GetAll();
        }

        public List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole()
        {
            var logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            return logic.GetAll();
        }

        public List<SecurityRolePoco> GetAllSecurityRole()
        {
            var logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            return logic.GetAll();
        }

        public SecurityLoginPoco GetSingleSecurityLogin(string Id)
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            return logic.Get(Guid.Parse(Id));
        }

        public SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string Id)
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            return logic.Get(Guid.Parse(Id));
        }

        public SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string Id)
        {
            var logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            return logic.Get(Guid.Parse(Id));
        }

        public SecurityRolePoco GetSingleSecurityRole(string Id)
        {
            var logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            return logic.Get(Guid.Parse(Id));
        }

        public void RemoveSecurityLogin(SecurityLoginPoco[] items)
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            logic.Delete(items);
        }

        public void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            logic.Delete(items);
        }

        public void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            var logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            logic.Delete(items);
        }

        public void RemoveSecurityRole(SecurityRolePoco[] items)
        {
            var logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            logic.Delete(items);
        }

        public void UpdateSecurityLogin(SecurityLoginPoco[] items)
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            logic.Update(items);
        }

        public void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            logic.Update(items);
        }

        public void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            var logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            logic.Update(items);
        }

        public void UpdateSecurityRole(SecurityRolePoco[] items)
        {
            var logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            logic.Update(items);
        }
    }

}
