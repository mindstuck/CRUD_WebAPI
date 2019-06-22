﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_CRUD.Models;

namespace WebAPI_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {   
        private readonly DepartmentContext _context;

        public DepartmentController(DepartmentContext context)
        {
            _context = context;
        }

        // GET:  
        [HttpGet]
        public async Task<Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<Department>>> GetDepartments(int? page)
        {
            return await _context.Departments.ToListAsync();

            //var countDetails = _context.Departments.Count();

            //var result = new PageResult<Department>
            //{
            //    Count = countDetails,
            //    PageIndex = page ?? 1,
            //    PageSize = pagesize,
            //    Items = await _context.Departments.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToListAsync()
            //};
            //return result;
        }
    
        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Department/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Department
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            if (DepartmentNameUnique(department.DepartmentName))
            {
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
            }
            else
                throw new Exception("Customer Name cannot be empty");
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return department;
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
        
        private bool DepartmentNameUnique(string name)
        {
            return !_context.Departments.Any(e => e.DepartmentName == name);
        }
    }
}
