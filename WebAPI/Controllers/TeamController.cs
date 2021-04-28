using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TeamController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from dbo.Team";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PulseDemoAppCon");
            SqlDataReader reader;
            using(SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using(SqlCommand command = new SqlCommand(query, con))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    con.Close();
                }

            }
            return new JsonResult(table);
        }


        [HttpPost]
        public JsonResult Post(Team t)
        {
            string query = @"insert into dbo.Team values ('"+t.TeamName+ @"')";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PulseDemoAppCon");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    con.Close();
                }

            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Team t)
        {
            string query = @"update dbo.Team "
                            +@"set TeamName = '" + t.TeamName + "' "
                            +@"where TeamId ="+ t.TeamId;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PulseDemoAppCon");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    con.Close();
                }

            }
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from dbo.Team where TeamId =" + id;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PulseDemoAppCon");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    con.Close();
                }

            }
            
            return new JsonResult("Deleted Successfully");
        }

        [Route("GetTeams")]
        public JsonResult GetTeams()
        {
            string query = @"select TeamName from dbo.Team";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PulseDemoAppCon");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    con.Close();
                }

            }
            return new JsonResult(table);
        }
    }
}
