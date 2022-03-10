using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using EMPAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EMPAPI.Controllers

    
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

  
        
        /*   [HttpGet]
           public JsonResult Get()
           {
               string query = @"
   select DepartmentId, DepartmentName from 
   dbo.Department
   ";
               DataTable table = new DataTable();
               string sqlDataSource = sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
               SqlDataReader myReader;
               using(SqlConnection myCon=new SqlConnection(sqlDataSource))
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
           }*/
    }
}
