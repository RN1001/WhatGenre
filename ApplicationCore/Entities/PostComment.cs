using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class PostComment
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        public int UserId { get; set; }

    }
}
