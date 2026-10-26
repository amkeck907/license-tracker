using CCED_Sample_App.Data_Access;
using CCED_Sample_App.Models;
using Microsoft.EntityFrameworkCore;


namespace CCED_Sample_App.Data_Access
{
    public static class DemoData
    {
        public static async Task InitializeAsync(LicenseDbContext db)
        {
            if (await db.License.AnyAsync()) return;

            var today = DateTime.Today;
            db.License.AddRange(
                new License { LicenseNumber = "AK-1001", Name = "North Star Bakery", LicenseType = "Business", IssueDate = today.AddMonths(-6), ExpirationDate = today.AddDays(60), IsActive = true },
                new License { LicenseNumber = "AK-1002", Name = "Aurora Design Studio", LicenseType = "Business", IssueDate = today.AddYears(-1), ExpirationDate = today.AddDays(10), IsActive = true },
                new License { LicenseNumber = "AK-1003", Name = "Copper River Consulting", LicenseType = "Professional", IssueDate = today.AddYears(-1), ExpirationDate = today, IsActive = true },
                new License { LicenseNumber = "AK-1004", Name = "Midnight Sun Outfitters", LicenseType = "Business", IssueDate = today.AddYears(-2), ExpirationDate = today.AddDays(-20), IsActive = true },
                new License { LicenseNumber = "AK-1005", Name = "Denali Accounting Group", LicenseType = "Professional", IssueDate = today.AddMonths(-3), ExpirationDate = today.AddMonths(9), IsActive = true },
                new License { LicenseNumber = "AK-1006", Name = "Arctic Harbor Services", LicenseType = "Business", IssueDate = today.AddMonths(-8), ExpirationDate = today.AddMonths(4), IsActive = false },
                new License { LicenseNumber = "AK-1007", Name = "Tundra Trail Guides", LicenseType = "Professional", IssueDate = today.AddMonths(-2), ExpirationDate = today.AddDays(25), IsActive = true },
                new License { LicenseNumber = "AK-1008", Name = "North Star Bakery", LicenseType = "Food Service", IssueDate = today.AddMonths(-4), ExpirationDate = today.AddMonths(8), IsActive = true }
            );
            await db.SaveChangesAsync();
        }
    }
}





