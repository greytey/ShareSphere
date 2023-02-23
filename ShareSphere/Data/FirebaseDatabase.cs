using System;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace ShareSphere.Data
{
    public class FirebaseDatabase
    {
        private FirebaseClient firebaseClient;
        private List<Gamer> gamers;

        public FirebaseDatabase()
        {
            firebaseClient = new FirebaseClient("https://sharesphere-b9b02-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task addGamer(Gamer gamer)
        {
            await firebaseClient
              .Child("gamers")
              .Child(gamer.userId)
              .PutAsync(gamer);
               await getGamers();
        }

        public async Task<bool> getGamers()
        {
            var gamers = await firebaseClient
              .Child("gamers")
              .OnceAsync<Gamer>();

            this.gamers =  gamers?.Select(item => new Gamer
            {
                userId = item.Object.userId,
                username = item.Object.username,
                biography = item.Object.biography,
                platforms = item.Object.platforms,
                games = item.Object.games,
                joinedAsString = item.Object.joinedAsString,
            }).ToList();

            return this.gamers != null;
        }

        public async void updateGamer(Gamer gamer)
        {
            await firebaseClient.Child("gamers").Child(gamer.userId).PutAsync(gamer);
            await getGamers();
        }

        public async void removeGamer(Gamer gamer)
        {
            await firebaseClient.Child("gamers").Child(gamer.userId).DeleteAsync();
            await getGamers();
        }

        public async Task<Gamer> getGamerByUid(string uid)
        {
            if(gamers == null)
            {
                await getGamers();
            }
            foreach(Gamer gamer in gamers)
            {
                if (gamer.userId.Equals(uid))
                {
                    return gamer;
                }
            }
            return null;
        }

        public async Task<Gamer> getUsername(string username)
        {
            if (gamers == null)
            {
                await getGamers();
            }
            foreach (Gamer gamer in gamers)
            {
                if (gamer.username.Contains(username))
                {
                    return gamer;
                }
            }
            return null;
        }
    }
}
