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

        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public Post Post { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return $"Comment: {CommentBody}, Date: {CommentDate}";
        }


    }
}
