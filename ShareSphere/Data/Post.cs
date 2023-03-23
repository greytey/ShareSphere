using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSphere.Data
{
    public class Post
    {
        public string postId { get; set; }
        public string userId { get; set; }
        public Gamer gamer { get; set; }
        public string videoUrl { get; set; }
        public int wps { get; set; }
        public string filename { get; set; }
        public List<Comment> comments { get; set; }

        public Post() { }

        public Post(string postId, Gamer gamer, string videoUrl, string filename)
        {
            this.postId = postId;
            this.userId = gamer.userId;
            this.gamer = gamer;
            this.videoUrl = videoUrl;
            wps = 0;
            this.comments = new List<Comment>();
            this.filename = filename;
        }

        public void addWp()
        {
            wps++;
        }

        public void removeWp()
        {
            wps--;
        }

        public void addComment(Comment comment)
        {
            comments.Add(comment);
        }

        public void removeComment(Comment comment)
        {
            comments.Remove(comment);
        }
    }
}