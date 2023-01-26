using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSphere.Data
{
    internal class Gamer
    {
        private string username;
        private string email;
        private string password;
        private List<Gamer> joined;
        private List<Gamer> isJoinedBy;

        public Gamer(string username, string email, string password, List<Gamer> joined)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.joined = joined;
        }

        public string getUseranme()
        {
            return username;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public string getEmail()
        {
            return email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getPassword()
        {
            return password;
        }

        public void setPassword(string password)
        {
            this.password = password;
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
