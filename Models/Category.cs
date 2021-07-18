using System.ComponentModel.DataAnnotations;

namespace QuoteApi_cs.Models
{
    public class Category
    {
        // unique category id
        [Key]
        public long Id { get; set; }
        // category name
        public string Name { get; set; }
    }
}