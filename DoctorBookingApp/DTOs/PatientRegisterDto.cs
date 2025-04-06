namespace DoctorBookingAPP.DTOs
{
    public class PatientRegisterDto
    {
        public int Id { get; set; }
        
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}