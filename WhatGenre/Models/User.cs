using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhatGenre.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        public string Fullname => this.Firstname + " " + this.Lastname;
        
        public ICollection<Address> Addresses { get; set; }

        public override string ToString()
        {
            return this.Username + " " + Password + " " + Fullname;
        }

    }
}
