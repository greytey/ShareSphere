using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSphere.Data
{
    public class Post
    {
        public string id { get; set; }
        public Gamer gamer { get; set; }
        public string videoUrl { get; set; }
        public int wps { get; set; }
        public List<Comment> comments { get; set; }

        public Post() { }

        public Post(Gamer gamer, string videoUrl, string id)
        {
            this.gamer = gamer;
            this.videoUrl = videoUrl;
            wps = 0;
            comments = new List<Comment>();
            this.id = id;
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