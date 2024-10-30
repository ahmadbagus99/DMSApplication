using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Main
{
    public class IndexModel : PageModel
    {
        public int TotalUsers { get; set; }
        public decimal TotalSales { get; set; }
        public int PendingOrders { get; set; }
        public List<Entry> RecentEntries { get; set; }

        public void OnGet()
        {
            // Sample data for demonstration purposes
            TotalUsers = 150;
            TotalSales = 12000.50m;
            PendingOrders = 5;

            RecentEntries = new List<Entry>
                {
                    new Entry { Id = 1, Name = "John Doe", Date = DateTime.Now.AddDays(-1), Status = "Completed" },
                    new Entry { Id = 2, Name = "Jane Smith", Date = DateTime.Now.AddDays(-2), Status = "Pending" },
                    new Entry { Id = 3, Name = "Sam Johnson", Date = DateTime.Now.AddDays(-3), Status = "Completed" }
                };
        }

        public class Entry
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }
        }
    }
}
