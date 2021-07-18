using System.ComponentModel.DataAnnotations;

namespace QuoteApi_cs.Models
{
    public class Author
    {
        // unique id
        [Key]
        public long Id { get; set; }
        // name of the author
        public string Name { get; set; }
    }
}