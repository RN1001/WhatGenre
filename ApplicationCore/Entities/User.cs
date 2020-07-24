using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class User : IdentityUser<string>
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override string Id { get => base.Id; set => base.Id = value; }

        //[Display(Name = "First name")]
        //[Required, StringLength(100, MinimumLength = 1, ErrorMessage = "Firstname must be between 1 - 100 characters")]
        //public string Firstname { get; set; }

        //[Display(Name = "Last name")]
        //[Required, StringLength(100, MinimumLength = 1, ErrorMessage = "Firstname must be between 1 - 100 characters")]
        //public string Lastname { get; set; }

        //[Display(Name = "Full name")]
        //public string Fullname => Firstname + " " + Lastname;

        public ICollection<Address> Addresses { get; set; }

        //public override string ToString()
        //{
        //    return Fullname;
        //}

    }
}
