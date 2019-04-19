using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyDescriptionRepository : BaseADO, IDataRepository<CompanyDescriptionPoco>
    {
        public void Add(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyDescriptionPoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Descriptions]
                        ([Id],[Company],[LanguageID],[Company_Name],[Company_Description])
                        VALUES
                        (@Id, @Company, @LanguageID, @Company_Name,@Company_Description)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);
                    conn.Open();
                    int rowEffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetAll(params System.Linq.Expressions.Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id],[Company],[LanguageID],[Company_Name],[Company_Description], [Time_Stamp]
                                       FROM [JOB_PORTAL_DB].[dbo].[Company_Descriptions]";
                conn.Open();
                int x = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                CompanyDescriptionPoco[] appPocos = new CompanyDescriptionPoco[1000];
                while (reader.Read())
                {
                    CompanyDescriptionPoco poco = new CompanyDescriptionPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Company = reader.GetGuid(1);
                    poco.LanguageId = reader.GetString(2);
                    poco.CompanyName = reader.GetString(3);
                    poco.CompanyDescription = reader.GetString(4);                    
                    poco.TimeStamp = (byte[])reader[5];
                    appPocos[x] = poco;
                    x++;
                }
                return appPocos.Where(a => a != null).ToList();
            }
        }

        public IList<CompanyDescriptionPoco> GetList(System.Linq.Expressions.Expression<Func<CompanyDescriptionPoco, bool>> where, params System.Linq.Expressions.Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(System.Linq.Expressions.Expression<Func<CompanyDescriptionPoco, bool>> where, params System.Linq.Expressions.Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyDescriptionPoco> pocos =
                GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyDescriptionPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Company_Descriptions WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    conn.Open();
                    int numofRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyDescriptionPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Company_Descriptions
                        SET Company = @Company, LanguageID = @LanguageID, Company_Name = @Company_Name, Company_Description = @Company_Description
                        WHERE Id = @MumboJumbo";
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);
                    cmd.Parameters.AddWithValue("@MumboJumbo", poco.Id);
                    conn.Open();
                    int NumOfRow = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
