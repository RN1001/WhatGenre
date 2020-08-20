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

        public ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
