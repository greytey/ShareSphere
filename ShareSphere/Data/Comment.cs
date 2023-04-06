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
    }
}