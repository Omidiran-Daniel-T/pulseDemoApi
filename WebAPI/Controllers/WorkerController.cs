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
    public class WorkerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public WorkerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from dbo.Workers";
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
            string query = @"select WorkerId, WorkerTeam, WorkerMemberId from dbo.Workers where WorkerId=" + id;
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
        public JsonResult Post(workers w)
        {
            string query = @"insert into dbo.Workers values ('" + w.WorkerTeam + "','" + w.WorkerMemberId +  "')";
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
        public JsonResult Put(workers w)
        {
            string query = @"update dbo.workers "
                            + @"set WorkerTeam = '" + w.WorkerTeam + "', "
                            + @"WorkerMemberId = '" + w.WorkerMemberId + "' "
                            + @"where workerId =" + w.WorkerId;
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
            string query = @"delete from dbo.Workers where WorkerId =" + id;
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
