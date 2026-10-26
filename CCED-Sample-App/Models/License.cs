using System.ComponentModel.DataAnnotations;

namespace CCED_Sample_App.Models
{
    public class License
    {
        public License() {
            Name = string.Empty;
            LicenseNumber = string.Empty;
            LicenseType = string.Empty;
        }
        public int Id { get; set; }
        [Required, StringLength(100)]
        [Display(Name = "Business Name")]
        public string Name { get; set; }

        [Required, StringLength(30)]
        [Display(Name = "License number")]
        public string LicenseNumber {  get; set; }

        [Required, StringLength(30)]
        [Display(Name = "License Type")]
        public string LicenseType { get; set; }

        [DataType(DataType.Date), Display(Name = "Issue date")]
        public DateTime IssueDate { get; set; }

        [DataType(DataType.Date), Display(Name = "Expiration date")]
        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; }

    }
}
