using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DataForm.Api.Models
{
    public class Item
    {
        
        public int Id { get; set; }
        [StringLength(255)]
        public string No { get; set; } = string.Empty;
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
