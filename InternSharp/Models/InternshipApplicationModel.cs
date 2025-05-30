namespace InternSharp.Models
{
    public class InternshipApplicationModel
    {
        public int UserID { get; set; }
        public int InternshipID { get; set; }
        public int StatusID { get; set; }
        public DateTime AppliedDate { get; set; }
        public int? ResumeID { get; set; } 
        public bool IsActive { get; set; } = true;
    }
}
