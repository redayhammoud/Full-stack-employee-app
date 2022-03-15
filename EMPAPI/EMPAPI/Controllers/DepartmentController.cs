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
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartmentController(ApplicationDbContext db) 
        {
            _db = db;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll() 
        {
            return Json(new { data = await _db.Department.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var departmentFromDb = await _db.Department.FirstOrDefaultAsync(u => u.DepartmentId == id);
            if(departmentFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _db.Department.Remove(departmentFromDb);
            return Json(new { success = true, message = "Delete successfully" });

        }
        
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
