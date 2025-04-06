namespace DoctorBookingAPP.Models
{
    public class Patient
    {
        public int Id { get; set; }
        
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
    }
}