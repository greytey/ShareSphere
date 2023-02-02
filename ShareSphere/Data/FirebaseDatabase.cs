using System;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace ShareSphere.Data
{
    public class FirebaseDatabase
    {
        private FirebaseClient firebaseClient;

        public FirebaseDatabase()
        {
            firebaseClient = new FirebaseClient("https://sharesphere-b9b02-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task addGamer(Gamer gamer)
        {
            await firebaseClient
              .Child("gamers")
              .Child(gamer.userId)
              .PostAsync(gamer);
        }

        public async Task<List<Gamer>> getGamers()
        {
            var gamers = await firebaseClient
              .Child("gamers")
              .OnceAsync<Gamer>();

            return gamers?.Select(item => new Gamer
            {
                userId = item.Object.userId,
                username = item.Object.username,
                biography = item.Object.biography,
                platforms = item.Object.platforms,
                games = item.Object.games,
                joinedAsString = item.Object.joinedAsString,
            }).ToList();
        }

        public async void updateGamer(string id, Gamer gamer)
        {
            await firebaseClient.Child("gamers").Child(gamer.userId).Child(id).PutAsync(gamer);
        }

        public async void removeGamer(Gamer gamer)
        {
            await firebaseClient.Child("gamers").Child(gamer.userId).DeleteAsync();
        }

        public async Task<Gamer> getGamerByUid(string uid)
        {
            List<Gamer> gamers = await getGamers();

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
            List<Gamer> gamers = await getGamers();

            foreach (Gamer gamer in gamers)
            {
                if (gamer.userId.Contains(username))
                {
                    return gamer;
                }
            }
            return null;
        }
    }
}
