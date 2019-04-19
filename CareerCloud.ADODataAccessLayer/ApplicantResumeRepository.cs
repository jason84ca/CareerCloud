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
    public class ApplicantResumeRepository : BaseADO, IDataRepository<ApplicantResumePoco>
    {
        public void Add(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                foreach (ApplicantResumePoco poco in items)
                {
                    command.CommandText = @"INSERT INTO.[DBO].[Applicant_Resumes]
                        ([Id],[Applicant],[Resume],[Last_Updated])
                        VALUES
                        (@Id, @Applicant, @Resume, @Last_Updated)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    command.Parameters.AddWithValue("@Resume", poco.Resume);
                    command.Parameters.AddWithValue("@Last_Updated", poco.LastUpdated);              
                    conn.Open();
                    int rowEffected = command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantResumePoco> GetAll(params System.Linq.Expressions.Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = @"SELECT [Id]
                                       , [Applicant], [Resume], [Last_Updated]                                       
                                       FROM [JOB_PORTAL_DB].[dbo].[Applicant_Resumes]";
                conn.Open();
                int x = 0;
                SqlDataReader reader = command.ExecuteReader();
                ApplicantResumePoco[] appPocos = new ApplicantResumePoco[1000];
                while (reader.Read())
                {
                    ApplicantResumePoco poco = new ApplicantResumePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Resume = reader.GetString(2);                   
                    if (!reader.IsDBNull(3))
                    {
                        poco.LastUpdated = reader.GetDateTime(3);
                    }
                    else
                    {
                        poco.LastUpdated = null;
                    }
                    appPocos[x] = poco;
                    x++;
                }
                return appPocos.Where(a => a != null).ToList();
            }
        }

        public IList<ApplicantResumePoco> GetList(System.Linq.Expressions.Expression<Func<ApplicantResumePoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(System.Linq.Expressions.Expression<Func<ApplicantResumePoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> pocos =
                GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantResumePoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Applicant_Resumes WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    conn.Open();
                    int numofRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantResumePoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Applicant_Resumes 
                        SET Applicant = @Applicant, 
                            Resume = @Resume,
                            Last_Updated = @LastUpdated                           
                        WHERE Id = @MumboJumbo";
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Resume", poco.Resume);
                    cmd.Parameters.AddWithValue("@LastUpdated", poco.LastUpdated);
                    cmd.Parameters.AddWithValue("@MumboJumbo", poco.Id);
                    conn.Open();
                    int numofRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
