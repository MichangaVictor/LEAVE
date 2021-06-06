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
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        string sqlDataSource = null;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlDataSource = _configuration.GetConnectionString("ELMSAppCon");
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
             select Id,DepartmentCode,DepartmentShortName,DepartmentFullName,DateOfCreation,DateOfUpdation from dbo.Department";
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
        public JsonResult Post(Department dep)
        {
            string query = @"
             insert into dbo.Department values
             (
              '" + dep.DepartmentCode+ @"'
              ,'" + dep.DepartmentShortName + @"'
              ,'" + dep.DepartmentFullName + @"'
              ,'" + dep.DateOfCreation + @"'
              ,'" + dep.DateOfUpdation + @"'
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
        public JsonResult Put(Department dep)
        {
            string query = @"
             update dbo.Department set 
             DepartmentCode= '" + dep.DepartmentCode + @"'
            ,DepartmentShortName= '" + dep.DepartmentShortName + @"'
            ,DepartmentFullName= '" + dep.DepartmentFullName + @"'
            ,DateOfCreation= '" + dep.DateOfCreation + @"'
            ,DateOfUpdation= '" + dep.DateOfUpdation + @"'
            where Id= " + dep.Id + @"
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
             delete dbo.Department 
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
