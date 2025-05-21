using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace InternSharp.Models
{
    public class InternshipModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string Location { get; set; }
        public string ShortDescription { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string InternshipType { get; set; }
        public string Stipend { get; set; }
        public string CompanyName { get; set; }
        public string FullDescription { get; set; }
      
        [NotMapped]
        public InternshipDetails FullDescriptionJson
        {
            get => string.IsNullOrEmpty(FullDescription)
                ? new InternshipDetails()
                : JsonSerializer.Deserialize<InternshipDetails>(FullDescription);
        }
    }
    public class InternshipDetails
    {
        public string AboutRole { get; set; }
        public List<string> Requirements { get; set; }
        public List<string> Responsibilities { get; set; }
        public List<string> Benefits { get; set; }
    }
}
