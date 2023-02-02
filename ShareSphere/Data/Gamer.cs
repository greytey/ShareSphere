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
        private List<Gamer> joinedAsString { get; set; }
        private List<Gamer> joined;
        private List<Gamer> isJoinedBy;

        public Gamer(string userId, string username)
        {
            this.userId = userId;
            this.username = username;
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
