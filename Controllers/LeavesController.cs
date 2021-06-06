using ELMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ELMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        string sqlDataSource = null;
        public LeavesController(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlDataSource = _configuration.GetConnectionString("ELMSAppCon");
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
             select Id, LeaveType,convert(varchar(10),FromDate,120)as FromDate,
             convert(varchar(10),ToDate,120)as ToDate,AdminRemark,
             Status
             from dbo.Leaves";
            DataTable table = new DataTable();

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Leaves leave)
        {
            string query = @"
             insert into dbo.Leaves values
             (
              '" + leave.LeaveType + @"'
              ,'" + leave.FromDate + @"'
              ,'" + leave.ToDate + @"'
              ,'" + leave.AdminRemark + @"'
              ,'" + leave.Status + @"'

             )";
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Leaves leave)
        {
            string query = @"
             update dbo.Employee set 
             LeaveType= '" + leave.LeaveType + @"'
            ,FromDate= '" + leave.FromDate + @"'
            ,ToDate= '" + leave.ToDate + @"'
            ,AdminRemark= '" + leave.AdminRemark + @"'
            ,Status= '" + leave.Status + @"'
            where Id= " + leave.Id + @"
              ";
            DataTable table = new DataTable();

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
             delete dbo.Leaves 
            where Id= " + id + @"
              ";
            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
