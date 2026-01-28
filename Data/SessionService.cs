using Microsoft.JSInterop;

namespace EventEaseApp.Data
{
    public class SessionService
    {
        private readonly IJSRuntime _jsRuntime;
        private User? currentUser;

        public SessionService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public bool IsLoggedIn => currentUser != null;

        public User? GetCurrentUser() => currentUser;

        public async Task InitializeAsync()
        {
            // Leer usuario desde localStorage al iniciar
            var userJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "currentUser");
            if (!string.IsNullOrEmpty(userJson))
            {
                currentUser = System.Text.Json.JsonSerializer.Deserialize<User>(userJson);
            }
        }

        public async Task Login(User user)
        {
            currentUser = user;
            var userJson = System.Text.Json.JsonSerializer.Serialize(user);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "currentUser", userJson);
        }

        public async Task Logout()
        {
            currentUser = null;
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "currentUser");
        }
    }
}