namespace CleanArch.MVC.API.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime DataExpiration { get; set; }
    }
}