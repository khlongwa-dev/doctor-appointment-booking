using Microsoft.AspNetCore.Mvc;
using DoctorBookingAPP.DTOs;
using DoctorBookingAPP.Data;
using DoctorBookingAPP.Services;
using DoctorBookingAPP.Models;

namespace DoctorBookingAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorAuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwt;

        public DoctorAuthController(AppDbContext context, JwtService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(DoctorRegisterDto dto)
        {
            if (_context.Doctors.Any(d => d.Email == dto.Email))
                return BadRequest("Email already exists.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var doctor = new Doctor
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = passwordHash,
                Specialization = dto.Specialization,
                ProfileImageUrl = dto.ProfileImageUrl,
                Bio = dto.Bio
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return Ok("Doctor registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login(DoctorLoginDto dto)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Email == dto.Email);
            if (doctor == null || !BCrypt.Net.BCrypt.Verify(dto.Password, doctor.PasswordHash))
                return Unauthorized("Invalid email or password.");

            var token = _jwt.GenerateToken(doctor);

            return Ok(new { token });
        }
    }
}