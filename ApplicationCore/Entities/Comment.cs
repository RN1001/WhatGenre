using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Comment : BaseEntity
    {

        [Required]
        [Display(Name = "Comment")]
        public string CommentBody { get; set; }

        [Display(Name = "Date of comment")]
        public DateTime CommentDate { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; }

    }
}
