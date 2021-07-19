using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuoteApi_cs.Models
{
    public class Subscriber
    {
        // unique identifier of the Subscriber
        [Key]
        public long Id { get; set; }

        // contact details
        [Required]
        [StringLength(150)]
        public string Contact { get; set; }

        // default regexp checker method that returns true if Contact field is Email
        public bool IsValidEmail()
        {
            return new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*").IsMatch(Contact);
        }

        // default regexp checker method that returns true if Contact field is Phone
        public bool IsValidPhone()
        {
            return new System.Text.RegularExpressions.Regex(@"\(?\+[0-9]{1,3}\)? ?-?[0-9]{1,3} ?-?[0-9]{3,5} ?-?[0-9]{4}( ?-?[0-9]{3})?").IsMatch(Contact);
        }

        // get error messages from the Contact field
        public string GetErrors()
        {
            // if both methods return false, no errors
            if (!IsValidEmail() && !IsValidPhone()) return "Please enter a valid email address or phone number";
            return "";
        }

        // model defauult validator
        public bool IsValid()
        {
            return IsValidEmail() || IsValidPhone();
        }
    }
}