using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuoteApi_cs.Models
{
    // abstract class for adding and updating a quote
    public class QuotePayload
    {
        // quote text
        public string Text { get; set; }
        // author of the quote
        [ForeignKey("AuthorId")]
        public long AuthorId { get; protected set; }
        public Author Author { get; set; }
        // category of the quote
        [ForeignKey("CategoryId")]
        public long CategoryId { get; protected set; }
        public Category Category { get; set; }
    }

    public class Quote : QuotePayload
    {
        // unique identifier of the quote
        [Key]
        public long Id { get; set; }
        // datetime of the quote with default value of current time
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}