using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;

namespace ShareSphere.Data
{
    public class FirebaseAuthentication
    {
        private static FirebaseAuthConfig config = new FirebaseAuthConfig {
            ApiKey = "AIzaSyA6PrPGDJNbv0jv_y4jvJPz48tMz0e8Et4",
            AuthDomain = "sharesphere-b9b02.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            },
            UserRepository = new FileUserRepository("FirebaseSample"), 
            //UserRepository = new StorageRepository()
        };

        private FirebaseAuthClient client = new FirebaseAuthClient(config);

        public FirebaseAuthClient getClient()
        {
            return client;
        }
    }
}
