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
        private List<Gamer> joined;
        private List<Gamer> isJoinedBy;

        public Gamer()
        {

        }

        public Gamer(string userId, string username)
        {
            this.userId = userId;
            this.username = username;
            biography = "I'm new to this app";
            platforms = new List<int>();
            games = new List<int>();
            joinedAsString = new List<string>();
        }

        public Gamer(string userId, string username, string biography, List<int> platforms, List<int> games, List<string> joinedAsString)
        {
            this.userId = userId;
            this.username = username;
            this.biography = biography;
            this.platforms = platforms;
            this.games = games;
            this.joinedAsString= joinedAsString;
        }

        public List<Gamer> getJoined()
        {
            return joined;
        }

        public void addJoined(Gamer gamer)
        {
            joined.Add(gamer);
            joinedAsString.Add(gamer.username);
        }

        public bool joins(Gamer gamer)
        {
            foreach(Gamer iterate in joined)
            {
                if(iterate == gamer)
                {
                    return true;
                }
            }
            return false;
        }

        public void removedJoined(Gamer gamer)
        {
            joined.Remove(gamer);
            joinedAsString.Remove(gamer.username);
        }

        public List<Gamer> getIsJoinedBy()
        {
            return isJoinedBy;
        }

        public void addIsJoinedBy(Gamer gamer)
        {
            isJoinedBy.Add(gamer);
        }
        public void removedIsJoinedBy(Gamer gamer)
        {
            isJoinedBy.Remove(gamer);
        }
    }
}
