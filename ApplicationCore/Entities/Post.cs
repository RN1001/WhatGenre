using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Post : BaseEntity
    {
        [Display(Name = "Title")]
        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "Title should be between 5 - 100 characters")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "Title should be between 5 - 100 characters")]
        public string Description { get; set; }

        [Display(Name = "Post created at")]
        [Required]
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; }

    }
}
