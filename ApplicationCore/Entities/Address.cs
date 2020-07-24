using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Address : BaseEntity
    {
   
        [Display(Name = "House number")]
        [Required, StringLength(3, MinimumLength = 1, ErrorMessage = "House no. must be between 1 - 3 characters")]
        public int HouseNo { get; set; }

        [Display(Name = "Street name")]
        [Required, StringLength(100, MinimumLength = 4, ErrorMessage = "Street name must be between 4 - 100 characters")]
        public string StreetName { get; set; }

        [Display(Name = "Postcode")]
        [Required, StringLength(8, MinimumLength = 7, ErrorMessage = "Postcode must be between 7 - 8 characters")]
        public string Postcode { get; set; }

        public User User { get; set; }
    }
}
