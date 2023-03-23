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
        public List<int> platforms { get; set; }
        public List<int> games { get; set; }
        public List<string> joinedAsString { get; set; }
        public List<string> postIds { get; set; }
        public List<string> wpedPostsIds { get; set; }

        public Gamer()
        {
            platforms = new List<int>();
            games = new List<int>();
            joinedAsString = new List<string>();
            postIds = new List<string>();
            wpedPostsIds = new List<string>();
        }

        public Gamer(string userId, string username)
        {
            this.userId = userId;
            this.username = username;
            biography = "I'm new to this app";
            platforms = new List<int>();
            games = new List<int>();
            joinedAsString = new List<string>();
            postIds = new List<string>();
            wpedPostsIds = new List<string>();
        }

        public Gamer(string userId, string username, string biography, List<int> platforms, List<int> games, List<string> joinedAsString, List<string> postIds, List<string> wpedPostsIds)
        {
            this.userId = userId;
            this.username = username;
            this.biography = biography;
            this.platforms = platforms;
            this.games = games;
            this.joinedAsString= joinedAsString;
            this.postIds = postIds;
            this.wpedPostsIds = wpedPostsIds;
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