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
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        string sqlDataSource = null;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlDataSource = _configuration.GetConnectionString("ELMSAppCon");
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
             select Id, FirstName,MiddleName,LastName,
             EmployeeCode,Email,Password,PhoneNumber,Address,Gender
             from dbo.Employee";
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
        public JsonResult Post(Employee emp)
        {
            string query = @"
             insert into dbo.Employee values
             (
              '" + emp.FirstName + @"'
              ,'" + emp.MiddleName + @"'
              ,'" + emp.LastName + @"'
              ,'" + emp.EmployeeCode + @"'
              ,'" + emp.Email + @"'
              ,'" + emp.Password + @"'
              ,'" + emp.PhoneNumber + @"'
              ,'" + emp.Address + @"'
              ,'" + emp.Gender + @"'

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
        public JsonResult Put(Employee emp)
        {
            string query = @"
             update dbo.Employee set 
             FirstName= '" + emp.FirstName + @"'
            ,MiddleName= '" + emp.MiddleName + @"'
            ,LastName= '" + emp.LastName + @"'
            ,EmployeeCode= '" + emp.EmployeeCode + @"'
            ,Email= '" + emp.Email + @"'
            ,PhoneNumber= '" + emp.PhoneNumber + @"'
            ,Address= '" + emp.Address + @"'
            ,Gender= '" + emp.Gender + @"'
            where Id= " + emp.Id + @"
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
             delete dbo.Employee 
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
