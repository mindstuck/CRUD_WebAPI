using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_CRUD.Models;

namespace WebAPI_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly DepartmentContext _context;

        public WorkerController(DepartmentContext context)
        {
            _context = context;
        }

        // GET: api/Worker
        [HttpGet]
        public async Task<Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<Worker>>> GetWorkers(int? depId)
        { 
            if (depId != null)
                return await _context.Workers.Where(w => w.DepartmentId == depId).ToListAsync();
            return await _context.Workers.ToListAsync();
        }

        // GET: api/Worker/5
        [HttpGet("{id}")]
        public async Task<Microsoft.AspNetCore.Mvc.ActionResult<Worker>> GetWorker(int id)
        {
            var worker = await _context.Workers.FindAsync(id);

            if (worker == null)
            {
                return NotFound();
            }

            return worker;
        }

        // PUT: api/Worker/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorker(int id, Worker worker)
        {
            if (id != worker.WorkerId)
            {
                return BadRequest();
            }

            _context.Entry(worker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(id))
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

        // POST: api/Worker
        [HttpPost]
        public async Task<Microsoft.AspNetCore.Mvc.ActionResult<Worker>> PostWorker(Worker worker)
        {
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorker", new { id = worker.WorkerId }, worker);
        }

        // DELETE: api/Worker/5
        [HttpDelete("{id}")]
        public async Task<Microsoft.AspNetCore.Mvc.ActionResult<Worker>> DeleteWorker(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();

            return worker;
        }

        private bool WorkerExists(int id)
        {
            return _context.Workers.Any(e => e.WorkerId == id);
        }
    }
}
