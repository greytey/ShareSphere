using Firebase.Database;
using Firebase.Database.Query;

namespace ShareSphere.Data
{
    public class FirebaseDatabasePosts
    {
        private FirebaseClient firebaseClient;

        public FirebaseDatabasePosts()
        {
            firebaseClient = new FirebaseClient("https://sharesphere-b9b02-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async void uploadPost(Gamer gamer, Post post)
        {
            await firebaseClient.Child("posts").Child(post.id).PutAsync(post);
            await firebaseClient.Child("gamer").Child(gamer.userId).Child("posts").PutAsync(post.id);
        }
    }
}
