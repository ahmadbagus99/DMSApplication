using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Services;

namespace WebApplication1.Pages.DataEntry
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        public DeleteModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/DataEntry/Index");
                return;
            }

            var dataEntry = context.DataEntries.Find(id);
            if (dataEntry == null)
            {
                Response.Redirect("/DataEntry/Index");
                return;
            }

            string imageFullPath = environment.WebRootPath + "/img/storage/" + dataEntry.KTPFileName;
            System.IO.File.Delete(imageFullPath);

            context.DataEntries.Remove(dataEntry);
            context.SaveChanges();
            Response.Redirect("/DataEntry/Index");
        }
    }
}
