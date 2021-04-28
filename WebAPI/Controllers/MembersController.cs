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
    public class MembersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MembersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from dbo.Members";
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

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"select MemberName, MemberDob, MemberJobTitle from dbo.Members where MemberId=" + id;
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
        [HttpPost]
        public JsonResult Post(Member m)
        {
            string query = @"insert into dbo.Members values ('" + m.MemberName + "','" + m.MemberDOB + "','" + m.MemberJobTitle + "')";
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
        public JsonResult Put(Member m)
        {
            string query = @"update dbo.Members "
                            + @"set MemberName = '" + m.MemberName + "', "
                            + @"MemberDob = '" + m.MemberDOB + "', "
                            + @"MemberJobTitle = '" + m.MemberJobTitle + "' "
                            + @"where MemberId =" + m.MemberId;
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
            string query = @"delete from dbo.Members where MemberId =" + id;
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
    }
}
