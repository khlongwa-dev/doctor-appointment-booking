namespace DoctorBookingAPP.DTOs
{
    public class DoctorRegisterDto
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Specialization { get; set; }
        public required string Address { get; set; }
        public required string ProfileImageUrl { get; set; }
        public required string Bio { get; set; }
    }
}