using DoctorBookingAPP.Data;
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
    
    }
}