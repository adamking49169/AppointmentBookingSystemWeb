namespace AppointmentBookingSystemWeb.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public required string Forename { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentStatus { get; set; } 
    }
}
