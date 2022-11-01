using HotelReservationsClient.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace HotelReservationsClient.Services
{
    public class AuthenticationApiService : ApiService
    {
        private static ApiUser user = new ApiUser();
        public bool LoggedIn { get { return !string.IsNullOrWhiteSpace(user.Token); } }
        public AuthenticationApiService(string apiUrl) : base(apiUrl) { }

        public bool Login(string submittedName, string submittedPass)
        {
            LoginUser loginUser = new LoginUser { Username = submittedName, Password = submittedPass };
            RestRequest request = new RestRequest("login");
            request.AddJsonBody(loginUser);
            IRestResponse<ApiUser> response = client.Post<ApiUser>(request);

            CheckForError(response, "Login");





            user.Token = response.Data.Token;

            //Set the token on the client
            client.Authenticator = new JwtAuthenticator(user.Token);
            //this will send the logged-in user's token on all subsequent requests 

            return true;
        }

        public void Logout()
        {
            user = new ApiUser();

            //Remove the token from the client
            client.Authenticator = null;

        }
    }
}
