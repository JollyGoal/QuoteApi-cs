using System;

namespace QuoteApi_cs.Models
{
    public class Quote
    {
        // unique identifier of the quote
        public long Id { get; set; }
        // quote text
        public string Text { get; set; }
        // author of the quote
        public Author Author { get; set; }
        // datetime of the quote with default value of current time
        public DateTime DateTime { get; set; } = DateTime.Now;

    }
}