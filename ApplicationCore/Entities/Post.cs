using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Post : BaseEntity
    {
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Post created at")]
        [Required]
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; }

    }
}
