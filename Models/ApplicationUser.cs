using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WOMB_Final.Models
{
    public class ApplicationUser : IdentityUser
    {
        public enum Title
        {
            Mr,
            Miss,
            Mrs,
            Ms,
            Dr,
            Prof,
            Mx
        }
        //public ICollection<Title> titles
        //{
        //    get; set;
        //}

        public enum Gender
        {
            Man,
            Woman,
            NonBinary,
            Transgender,
            Unspecified,
        }


        public Title title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender gender { get; set; }
        public string Address { get; set; } //maps api
        public string Occupation { get; set; }
        public DateTime DOB { get; set; } //date picker
        public string? Bio { get; set; } // big box
        public double ConsultationFee { get; set; }
        public string HPCSAnumber { get; set; }
        public string URL { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
