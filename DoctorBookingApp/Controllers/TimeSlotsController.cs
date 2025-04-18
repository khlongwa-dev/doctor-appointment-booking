using System.Security.Claims;
using DoctorBookingAPP.Data;
using DoctorBookingAPP.DTOs;
using DoctorBookingAPP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorBookingAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeSlotsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TimeSlotsController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost("add-timeslot")]
        public async Task<IActionResult> AddTimeSlot(TimeSlotDto dto)
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(idClaim) || !int.TryParse(idClaim, out var doctorId))
                return Unauthorized("Invalid token. Doctor ID not found.");

            var timeSlot = new TimeSlot
            {
                DoctorId = doctorId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            };

            _context.TimeSlots.Add(timeSlot);
            await _context.SaveChangesAsync();

            return Ok("Time slot added.");
        }
    
    }
}