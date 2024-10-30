using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DokumenChecklist
    {
        public int Id { get; set; }

        public int Position { get; set; }
        [Required]
        public string DokumenName { get; set; }

        public bool IsChecked { get; set; }

        public string FileName { get; set; } = "";

        public int DataEntryId { get; set; }

        [ForeignKey("DataEntryId")]
        public DataEntry DataEntry { get; set; }
    }
}
