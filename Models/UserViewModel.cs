using System;
using static WOMB_Final.Models.ApplicationUser;

namespace WOMB_Final.Models
{
    public class UserViewModel
    {

        public int Id { get; set; }
        public Title title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender gender { get; set; }
        public string Address { get; set; } 
        public string Occupation { get; set; }
        public DateTime DOB { get; set; } 
        public string? Bio { get; set; } 
        public double ConsultationFee { get; set; }
        public string HPCSAnumber { get; set; }
        public string URL { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
