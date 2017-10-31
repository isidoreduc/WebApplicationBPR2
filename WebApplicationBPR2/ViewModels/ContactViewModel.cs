using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBPR2.ViewModels
{
    public class ContactViewModel   // used for model binding; it is going to store the data input by user in the contact form
    {
        [Required]  //data annotation used for validation (that is, if user tries to send form without name, he cant cause it s mandatory)
        [MinLength(5)]  // minimum 5 letters
        public string Name { get; set; }
        [Required]
        [EmailAddress]  // email should have legitimate email structure
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(250)]
        public string Message { get; set; }
    }
}
