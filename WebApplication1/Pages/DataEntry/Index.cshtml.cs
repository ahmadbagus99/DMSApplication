using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Services;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Pages.DataEntry
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        // Ubah List<DataEntries> menjadi List<DataEntry>
        public List<WebApplication1.Models.DataEntry> ListDataEntry { get; set; } = new List<WebApplication1.Models.DataEntry>();

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            ListDataEntry = context.DataEntries.OrderByDescending(x => x.Id).ToList();
        }
    }
}
