using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
    {
        public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository)
        {
        }
        public override void Add(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(CompanyLocationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyLocationPoco item in pocos)
            {
                if (item.CountryCode == null)
                {
                    exceptions.Add(new ValidationException(500, "CountryCode cannot be empty"));
                }
                if (item.Province == null)
                {
                    exceptions.Add(new ValidationException(501, "Province cannot be empty"));
                }
                if (item.Street == null)
                {
                    exceptions.Add(new ValidationException(502, "Street cannot be empty"));
                }
                if (item.City == null)
                {
                    exceptions.Add(new ValidationException(503, "City cannot be empty"));
                }
                if (item.PostalCode == null)
                {
                    exceptions.Add(new ValidationException(504, "PostalCode cannot be empty"));
                }

            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
