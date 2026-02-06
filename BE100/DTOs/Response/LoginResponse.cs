namespace BE100.DTOs.Response
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string Role { get; set; }
    }
}
