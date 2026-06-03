namespace StudentEnrollment.API.Models.DTO
{
    public class UpdateStudentRequestDTO
    {
        public string StudentName { get; set; } = string.Empty;
        public string Programme { get; set; } = string.Empty;
        public string EnrollmentStatus { get; set; } = string.Empty;
    }
}