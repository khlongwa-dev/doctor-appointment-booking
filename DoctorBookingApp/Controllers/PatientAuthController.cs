using Microsoft.AspNetCore.Mvc;
using DoctorBookingAPP.DTOs;
using DoctorBookingAPP.Data;
using DoctorBookingAPP.Services;
using DoctorBookingAPP.Models;

namespace DoctorBookingAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientAuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwt;

        public PatientAuthController(AppDbContext context, JwtService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(PatientRegisterDto dto)
        {
            if (_context.Patients.Any(d => d.Email == dto.Email))
                return BadRequest("Email already exists.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var patient = new Patient
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = passwordHash,
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return Ok("Patient registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login(PatientLoginDto dto)
        {
            var patient = _context.Patients.FirstOrDefault(d => d.Email == dto.Email);
            if (patient == null || !BCrypt.Net.BCrypt.Verify(dto.Password, patient.PasswordHash))
                return Unauthorized("Invalid email or password.");

            var token = _jwt.GenerateToken(patient);

            return Ok(new { token });
        }
    }
}