using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobEducationRepository : BaseADO, IDataRepository<CompanyJobEducationPoco>
    {
        public void Add(params CompanyJobEducationPoco[] items)
        {
            
            using (SqlConnection conn = new SqlConnection(connString))
            {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    foreach (CompanyJobEducationPoco poco in items)
                    {
                        cmd.CommandText = @"INSERT INTO [dbo].[Company_Job_Educations]
                        ([Id],[Job],[Major],[Importance])
                        VALUES
                        (@Id, @Job, @Major, @Importance)";
                        cmd.Parameters.AddWithValue("@Id", poco.Id);
                        cmd.Parameters.AddWithValue("@Job", poco.Job);
                        cmd.Parameters.AddWithValue("@Major", poco.Major);
                        cmd.Parameters.AddWithValue("@Importance", poco.Importance);
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

        public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT [Id],[Job],[Major],[Importance], [Time_Stamp]
                                       FROM [JOB_PORTAL_DB].[dbo].[Company_Job_Educations]";
                    conn.Open();
                    int x = 0;
                    SqlDataReader reader = cmd.ExecuteReader();
                    CompanyJobEducationPoco[] appPocos = new CompanyJobEducationPoco[2000];
                    while (reader.Read())
                    {
                        CompanyJobEducationPoco poco = new CompanyJobEducationPoco();
                        poco.Id = reader.GetGuid(0);
                        poco.Job = reader.GetGuid(1);
                        poco.Major = reader.GetString(2);
                        poco.Importance = reader.GetInt16(3);
                        poco.TimeStamp = (byte[])reader[4];
                        appPocos[x] = poco;
                        x++;
                    }
                    return appPocos.Where(a => a != null).ToList();
                }
            }

        public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
                IQueryable<CompanyJobEducationPoco> pocos =
                    GetAll().AsQueryable();
                return pocos.Where(where).FirstOrDefault();
            }

        public void Remove(params CompanyJobEducationPoco[] items)
        {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    foreach (CompanyJobEducationPoco poco in items)
                    {
                        cmd.CommandText = @"DELETE FROM Company_Job_Educations WHERE Id=@Id";
                        cmd.Parameters.AddWithValue("@Id", poco.Id);
                        conn.Open();
                        int numofRows = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

        public void Update(params CompanyJobEducationPoco[] items)
        {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    foreach (CompanyJobEducationPoco poco in items)
                    {
                        cmd.CommandText = @"UPDATE Company_Job_Educations
                        SET Job = @Job, Major = @Major, Importance = @Importance
                        WHERE Id = @MumboJumbo";
                        cmd.Parameters.AddWithValue("@Job", poco.Job);
                        cmd.Parameters.AddWithValue("@Major", poco.Major);
                        cmd.Parameters.AddWithValue("@Importance", poco.Importance);
                        cmd.Parameters.AddWithValue("@MumboJumbo", poco.Id);
                        conn.Open();
                        int NumOfRow = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
    }
}
