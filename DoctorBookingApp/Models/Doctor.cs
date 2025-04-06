namespace DoctorBookingAPP.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string Specialization { get; set; }
        public required string Address { get; set; }
    }
}