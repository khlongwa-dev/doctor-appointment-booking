using DoctorBookingAPP.Data;
using DoctorBookingAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorBookingAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DoctorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = doctor.Id }, doctor);
        }

        [HttpPost("{id}/upload-profile-image")]
        public async Task<IActionResult> UploadProfileImage(int id, IFormFile file)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
                return NotFound("Doctor not found.");
            
        }
    }
}
