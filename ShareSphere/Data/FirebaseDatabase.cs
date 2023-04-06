using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;

namespace ShareSphere.Data
{
    public class FirebaseDatabase
    {
        private FirebaseClient firebaseClient;
        private FirebaseStorage firebaseStorage;
        private List<Gamer> gamers;
        private List<Post> postsList;
        private List<string> games;

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

            this.gamers = gamers?.Select(item => new Gamer
            {
                userId = item.Object.userId,
                username = item.Object.username,
                biography = item.Object.biography,
                platforms = item.Object.platforms,
                games = item.Object.games,
                joinedAsString = item.Object.joinedAsString,
                wpedPostsIds = item.Object.wpedPostsIds,
                postIds = item.Object.postIds
            }).ToList();

            return this.gamers != null;
        }

        public async Task updateGamer(Gamer gamer)
        {
            await firebaseClient.Child("gamers").Child(gamer.userId).PutAsync(gamer);
            await getGamers();
        }

        public async void removeGamer(Gamer gamer)
        {
            await firebaseClient.Child("gamers").Child(gamer.userId).DeleteAsync();
            await getGamers();
        }

        public async Task<Gamer> getGamerByUid(string userId)
        {
            Gamer gamer = await firebaseClient
                .Child("gamers")
                .Child(userId)
                .OnceSingleAsync<Gamer>();

            return gamer;
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

        public async Task<List<string>> getAllGames()
        {
            var gamesList = await firebaseClient.Child("games").OnceAsListAsync<string>();
            games = gamesList?.Select(x => x.Object).ToList();
            return games;
        }


        public async Task uploadPost(Gamer gamer, Post post)
        {
            await firebaseClient.Child("posts").Child(post.postId).PutAsync(new Post()
            {
                postId = post.postId,
                userId = gamer.userId.ToString(),
                wps = post.wps,
                comments = post.comments,
                videoUrl = post.videoUrl,
                filename = post.filename,
                views = post.views,
                date = post.date,
                game= post.game,
                description = post.description
            }) ;
            gamer.addPost(post);
            await updateGamer(gamer);
        }

        public async Task<List<Post>> getAllPostsExceptLoggedInUser(string currentUserUid)
        {
            List<Post> allPosts = await getAllPosts();
            List<Post> notFromLoggedInUser = new List<Post>();
            foreach(Post post in allPosts)
            {
                if(post.userId != currentUserUid)
                {
                    notFromLoggedInUser.Add(post);
                }
            }
            return notFromLoggedInUser;
        }

        public async Task<List<Post>> getAllPosts()
        {
            var posts = await firebaseClient
              .Child("posts")
              .OnceAsync<Post>();

            postsList = posts?.Select(item => new Post
            {
                postId = item.Key,
                userId = item.Object.userId,
                wps = item.Object.wps,
                videoUrl = item.Object.videoUrl,
                comments = item.Object.comments,
                filename = item.Object.filename,
                game = item.Object.game,
                description = item.Object.description
            }).ToList();

            foreach (Post iterate in postsList)
            {
                iterate.gamer = await getGamerByUid(iterate.userId);
            }
            return postsList;
        }

        public async Task<List<Post>> getAllPostsFromGamer(Gamer gamer)
        {
            List<Post> postsList = new List<Post>();

            foreach (string iterate in gamer.postIds)
            {
                Post post = await firebaseClient
                .Child("posts")
                .Child(iterate)
                .OnceSingleAsync<Post>();

                post.gamer = await getGamerByUid(post.userId);
                postsList.Add(post);
            }

            return postsList;
        }

        public async Task<List<Post>> getAllPostsByGame(String gamename)
        {
            List<Post> postsByGame = new List<Post>();
            List<Post> allPosts = await getAllPosts();

            foreach (Post post in allPosts)
            {
                if(post.game == gamename)
                {
                    postsByGame.Add(post);
                }
            }

            return postsByGame;
        }

        public async void updatePost(Post post)
        {
            await firebaseClient.Child("posts").Child(post.postId).PutAsync(post);
            await getAllPosts();
        }

        public async void deletePost(Post post)
        {
            await firebaseClient.Child("posts").Child(post.postId).DeleteAsync();
            await firebaseStorage.Child(post.filename).DeleteAsync();
            await getAllPosts();
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