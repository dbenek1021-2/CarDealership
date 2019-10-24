using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GuildCars.Models.Mapper;
using GuildCars.Models.Queries;
using GuildCars.Data.Mapper;
using System.Configuration;

namespace GuildCars.Data.Repos.ADO
{
    public class HomeRepoADO : IHomeRepo
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<GetHomePage> GetHomePage()
        {
            List<GetHomePage> cars = new List<GetHomePage>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllFeatured", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        GetHomePage hp = new GetHomePage();

                        hp.CarId = int.Parse(dr["CarId"].ToString());
                        hp.Year = int.Parse(dr["Year"].ToString());
                        hp.MakeName = dr["MakeName"].ToString();
                        hp.ModelName = dr["ModelName"].ToString();
                        hp.SalePrice = int.Parse(dr["SalePrice"].ToString());
                        hp.ImageFileName = dr["ImageFileName"].ToString();

                        cars.Add(hp);
                    }
                }
                conn.Close();
            }
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllSpecials", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        GetHomePage hp = new GetHomePage();

                        hp.SpecialId = int.Parse(dr["SpecialId"].ToString());
                        hp.SpecialTitle = dr["SpecialTitle"].ToString();
                        hp.SpecialDescription = dr["SpecialDescription"].ToString();

                        cars.Add(hp);
                    }
                }
                conn.Close();
            }
            return cars;
        }

        public IEnumerable<GetSpecials> GetSpecials()
        {
            List<GetSpecials> specials = new List<GetSpecials>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllSpecials", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        GetSpecials hp = new GetSpecials();

                        hp.SpecialId = int.Parse(dr["SpecialId"].ToString());
                        hp.SpecialTitle = dr["SpecialTitle"].ToString();
                        hp.SpecialDescription = dr["SpecialDescription"].ToString();

                        specials.Add(hp);
                    }
                }
            }
            return specials;
        }

        public void AddContact(ContactUs contactInfo)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SubmitContactUs", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", contactInfo.Name);

                if (contactInfo.Email == null)
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", contactInfo.Email);
                }
                if (contactInfo.Phone == null)
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", contactInfo.Phone);
                }

                cmd.Parameters.AddWithValue("@Message", contactInfo.Message);

                conn.Open();
                cmd.ExecuteReader();

            }
        }
    }
}
