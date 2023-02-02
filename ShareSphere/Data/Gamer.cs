using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSphere.Data
{
    public class Gamer
    {
        private string userId { get; set; }
        private string username { get; set; }
        private string biography { get; set; }
        private List<int> platforms { get; set; }
        private List<int> games { get; set; }
        private List<String> joinedAsString { get; set; }
        private List<Gamer> joined;
        private List<Gamer> isJoinedBy;

        public Gamer(string userId, string username)
        {
            this.userId = userId;
            this.username = username;
        }

        public Gamer(string userId, string username, string biography, List<int> platforms, List<int> games)
        {
            this.userId = userId;
            this.username = username;
            this.biography = biography;
            this.platforms = platforms;
            this.games = games;
        }

        public string getUserId()
        {
            return userId;
        }

        public void setUserId(string userId)
        {
            this.userId = userId;
        }

        public string getUseranme()
        {
            return username;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public string getBiography()
        {
            return biography;
        }

        public List<int> getPlatforms()
        {
            return platforms;
        }

        public List<int> getGames()
        {
            return games;
        }

        public List<string> getJoinedAsString()
        {
            return joinedAsString;
        }

        public List<Gamer> getJoined()
        {
            return joined;
        }

        public void addJoined(Gamer gamer)
        {
            joined.Add(gamer);
        }
        public void removedJoined(Gamer gamer)
        {
            joined.Remove(gamer);
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
