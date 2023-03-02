using System;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using System.Threading.Tasks;
using Firebase.Storage;

namespace ShareSphere.Data
{
    public class FirebaseDatabase
    {
        private FirebaseClient firebaseClient;
        private FirebaseStorage firebaseStorage;
        private List<Gamer> gamers;

        public FirebaseDatabase()
        {
            firebaseClient = new FirebaseClient("https://sharesphere-b9b02-default-rtdb.europe-west1.firebasedatabase.app/");
            firebaseStorage = new FirebaseStorage("sharesphere-b9b02.appspot.com");

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

        public async Task<Gamer> getGamerByUsername(string username)
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


        public async void uploadPost(Gamer gamer, Post post)
        {
            await firebaseClient.Child("posts").Child(post.id).PutAsync(post);
            gamer.addPost(post);
            updateGamer(gamer);

        }

        public async Task<List<Post>> getAllPosts()
        {
            var posts = await firebaseClient.Child("posts").OnceAsync<Post>();
            return posts?.Select(x => new Post()
            {
                gamerId = x.Object.gamerId,
                id = x.Key,
                wps = x.Object.wps,
                videoUrl = x.Object.videoUrl
            }).ToList();
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
                    gamerId = x.Object.gamerId,
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
        public static string generatePostId(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
    }
}