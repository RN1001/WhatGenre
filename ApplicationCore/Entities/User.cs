using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class User : BaseEntity
    {
        
        [Display(Name = "Username")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "First name")]
        [Required]
        public string Firstname { get; set; }

        [Display(Name = "Last name")]
        [Required]
        public string Lastname { get; set; }

        [Display(Name = "Full name")]
        public string Fullname => Firstname + " " + Lastname;

        public ICollection<Address> Addresses { get; set; }

        public override string ToString()
        {
            return Username + " " + Password + " " + Fullname;
        }

    }
}
