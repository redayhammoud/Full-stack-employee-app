using EMPAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EMPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll() {

            return Json(new { data = await _db.Employees.ToListAsync() });
        }

        [HttpPost]

        public async Task<ActionResult<Employee>> PostEmployee(Employee  emp)

        {
            _db.Employees.Add(emp);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = emp.EmployeeId }, emp);
        }




        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var EmployeeFromDb = await _db.Employees.FirstOrDefaultAsync(u => u.EmployeeId == id);
            if(EmployeeFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Remove(EmployeeFromDb);
            return Json(new { success = true, message = "Delete successfully" });

        }

    
    }

}
