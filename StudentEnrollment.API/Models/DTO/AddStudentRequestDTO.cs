namespace StudentEnrollment.API.Models.DTO
{
    public class AddStudentRequestDTO
    {
        public string StudentName { get; set; } = string.Empty;
        public string Programme { get; set; } = string.Empty;
        public string EnrollmentStatus { get; set; } = string.Empty;
    }
}