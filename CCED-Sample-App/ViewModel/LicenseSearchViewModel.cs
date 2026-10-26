using CCED_Sample_App.Models;

namespace CCED_Sample_App.ViewModel
{
    public class LicenseSearchViewModel
    {
        public LicenseSearchViewModel () { 
            Licenses = new List<License>();
        }
        public IEnumerable<License> Licenses { get; set; }
    }
}
