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
              .PostAsync(gamer);
        }

        public async Task<List<KeyValuePair<string, Gamer>>> getGamers()
        {
            var gamers = await firebaseClient
              .Child("gamers")
              .OnceAsync<Gamer>();

            return gamers?
              .Select(x => new KeyValuePair<string, Gamer>(x.Key, x.Object))
              .ToList();
        }

        public async Task updateGamer(string id, Gamer gamer)
        {
            var gamers = await firebaseClient
              .Child("gamers")
              .Child(id)
              .PutAsync(gamer);
        }

        public async Task removeGamer(string id)
        {
            var gamers = await firebaseClient
              .Child("gamers")
              .Child(id)
              .DeleteAsync();
        }
    }
}
