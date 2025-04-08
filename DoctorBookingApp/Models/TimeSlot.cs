namespace DoctorBookingAPP.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Doctor? Doctor { get; set; }
    }
}
