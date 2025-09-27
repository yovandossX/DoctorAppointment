namespace DoctorAppointmentScheduler.Application.DTOclass
{
    public class Occupationdto
    {
        public Guid Occupationid { get; set; }

        public string Occupationname { get; set; } = null!;
    }
    public class Occupationresponsedto
    {
        public Guid Occupationid { get; set; }
        public string Occupationname { get; set; } = null!;
        public bool? isdeleted { get; set; }
    }
}
