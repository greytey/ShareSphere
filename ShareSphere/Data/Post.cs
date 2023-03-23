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
        public int views { get; set;  }
        public DateTime date { get; set; }
        public string game { get; set; }

        public Post() { }

        public Post(string postId, Gamer gamer, string videoUrl, string filename)
        {
            this.postId = postId;
            this.userId = gamer.userId;
            this.gamer = gamer;
            this.videoUrl = videoUrl;
            wps = 0;
            this.filename = filename;
            this.comments = new List<Comment>();
            views = 0;
            date = DateTime.Now;
            game = "random game";
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