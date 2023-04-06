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
        public List<string> commentId { get; set; }
        public List<Comment> comments { get; set; }
        public int views { get; set;  }
        public DateTime date { get; set; }
        public string game { get; set; }
        public string description { get; set; }

        public Post() {
            this.commentId = new List<string>();
            this.comments = new List<Comment>();
        }

        public Post(string postId, Gamer gamer, string videoUrl, string filename, string game, string description)
        {
            this.postId = postId;
            this.userId = gamer.userId;
            this.gamer = gamer;
            this.videoUrl = videoUrl;
            wps = 0;
            this.filename = filename;
            this.commentId = new List<string>();
            this.comments = new List<Comment>();
            views = 0;
            date = DateTime.Now;
            this.game = game;
            this.description = description;
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
            commentId.Add(comment.commentId);
        }

        public void removeComment(Comment comment)
        {
            comments.Remove(comment);
            commentId.Remove(comment.commentId);
        }
    }
}