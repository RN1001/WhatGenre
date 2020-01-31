using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Entities
{
    public class PostComment
    {
        [Key, Column(Order = 0)]
        public int PostId { get; set; }
        public Post Post { get; set; }

        [Key, Column(Order = 1)]
        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
