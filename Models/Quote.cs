using System;

namespace QuoteApi_cs.Models
{
    // abstract class for adding and updating a quote
    public class QuotePayload
    {
        // quote text
        public string Text { get; set; }
        // author of the quote
        public Author Author { get; set; }
        // category of the quote
        public Category Category { get; set; }
    }

    public class Quote : QuotePayload
    {
        // unique identifier of the quote
        public long Id { get; set; }
        // datetime of the quote with default value of current time
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}