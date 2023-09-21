namespace NewwebApp.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public string ClinicRemarks { get; set; }
        public string Diagnosis { get; set; } //تشخيص
        public string SecondDiagnosis { get; set; }
        public string ThirdDiagnosis { get; set; }
        public string Therapy { get; set; } // علاج
        public DateTime Date { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
