using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSphere.Data
{
    public class Comment
    {
        public string commentId {  get; set; }
        public string postId { get; set; }
        public string userId { get; set; }
        public Gamer gamer { get; set; }
        public Post post { get; set; }
        public string comment { get; set; }

        public Comment() { }

        public Comment(string postId, string userId, Gamer gamer, Post post, string comment)
        {
            commentId = FirebaseDatabase.generateId(15);
            this.postId = postId;
            this.userId = userId;
            this.gamer = gamer;
            this.post = post;
            this.comment = comment;
        }
    }
}