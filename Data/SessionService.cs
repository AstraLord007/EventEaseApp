namespace EventEaseApp.Data
{
    public class SessionService
    {
        private User? currentUser;

        public bool IsLoggedIn => currentUser != null;

        public User? GetCurrentUser() => currentUser;

        public void Login(User user)
        {
            currentUser = user;
        }

        public void Logout()
        {
            currentUser = null;
        }
    }
}