using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using System.Linq;

namespace ShareSphere.Data
{
    public class FirebaseDatabasePosts
    {
        private FirebaseClient firebaseClient;
        private FirebaseStorage firebaseStorage;

        public FirebaseDatabasePosts()
        {
            firebaseClient = new FirebaseClient("https://sharesphere-b9b02-default-rtdb.europe-west1.firebasedatabase.app/");
            firebaseStorage = new FirebaseStorage("sharesphere-b9b02.appspot.com");
        }

        public async void uploadPost(Gamer gamer, Post post)
        {
            await firebaseClient.Child("posts").Child(post.id).PutAsync(post);
            await firebaseClient.Child("gamer").Child(gamer.userId).Child("posts").PutAsync(post.id);
        }

        public async Task<List<Post>> getAllPostsFromGamer(Gamer gamer)
        {
            List<Post> posts = new List<Post>();
            var postIds = await firebaseClient.Child("gamer").Child(gamer.userId).Child("posts").OnceAsListAsync<string>();
            foreach (var postId in postIds)
            {
                var singlePost = await firebaseClient.Child("posts").Child(postId.Object).OnceAsync<Post>();
                posts.AddRange(singlePost?.Select(x => new Post()
                {
                    id = postId.Object,
                    wps = x.Object.wps,
                    videoUrl = x.Object.videoUrl
                }).ToList());

            }
            return posts;
        }

        public async Task<string> uploadPostToStorage(FileResult video)
        {
            var videoToUpload = await video.OpenReadAsync();
            return await firebaseStorage.Child(video.FileName).PutAsync(videoToUpload);
        }

        // from https://jonathancrozier.com/blog/how-to-generate-a-random-string-with-c-sharp 
        public static string GenerateRandomAlphanumericString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
    }
}