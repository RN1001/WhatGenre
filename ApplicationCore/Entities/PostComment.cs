using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Entities
{
    public class PostComment
    {
        [Key]
        public int PostId { get; set; }
        public Post Post { get; set; }

        [Key]
        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
