using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSphere.Data
{
    public class Gamer
    {
        public string userId { get; set; }
        public string username { get; set; }
        public string biography { get; set; }
        public List<string> platforms { get; set; }
        public List<string> games { get; set; }
        public List<string> joinedAsString { get; set; }
        public List<string> postIds { get; set; }
        public List<string> wpedPostsIds { get; set; }
        public string photoUrl { get; set; }
        public string filename { get; set; }

        public Gamer()
        {
            platforms = new List<string>();
            games = new List<string>();
            joinedAsString = new List<string>();
            postIds = new List<string>();
            wpedPostsIds = new List<string>();
        }

        public Gamer(string userId, string username)
        {
            string[] placeholderArray = { "", "", "" };
            this.userId = userId;
            this.username = username;
            biography = "I'm new to this app";
            platforms = new List<string>();
            platforms.AddRange(placeholderArray);
            games = new List<string>();
            games.AddRange(placeholderArray);
            joinedAsString = new List<string>();
            postIds = new List<string>();
            wpedPostsIds = new List<string>();
            photoUrl = "https://firebasestorage.googleapis.com/v0/b/sharesphere-b9b02.appspot.com/o/bot_fill.png?alt=media&token=6fcbadf8-f292-4d2f-b855-9b1f1607767f";
            filename = "bot_fill.png";
        }

        public bool joins(Gamer gamer)
        {
            foreach(string iterate in joinedAsString)
            {
                if(iterate == gamer.username)
                {
                    return false;
                }
            }
            return true;
        }

        public void addJoins(Gamer gamer)
        {
            joinedAsString.Add(gamer.username);
        }

        public void removeJoins(Gamer gamer)
        {
            joinedAsString.Remove(gamer.username);
        }

        public void addPost(Post post)
        {
            postIds.Add(post.postId);
        }

        public void removePost(Post post)
        {
            postIds.Remove(post.postId);
        }

        public bool wp(Post post)
        {
            foreach (string wpedPost in wpedPostsIds)
            {
                if (wpedPost == post.postId)
                {
                    return false;
                }
            }
            return true;

        }

        public void addWP(Post post)
        {
            wpedPostsIds.Add(post.postId);
        }

        public void removeWP(Post post)
        {
            wpedPostsIds.Remove(post.postId);
        }
    }
}