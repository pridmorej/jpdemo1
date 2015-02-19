using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jpdemo1.Models
{
    /// <summary>
    /// Summary description for ContactModel
    /// </summary>
    public class ContactModel
    {
        private int thankYouPage;

        public ContactModel()
        {
        }

        public ContactModel(int ThankYouPage = 0)
        {
            // TODO: Complete member initialization
            this.thankYouPage = ThankYouPage;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Enter a Message")]
        public string Message { get; set; }
        [Required]
        public int ThankYouPage
        {
            get
            {
                return this.thankYouPage;
            }
            set
            {
                this.thankYouPage = value;
            }
        }
    }
}