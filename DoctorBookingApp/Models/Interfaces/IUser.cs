namespace DoctorBookingAPP.Models
{
    public interface IUser
    {
        int Id { get; }
        string Email { get; }
        string FullName { get; }
    }
}