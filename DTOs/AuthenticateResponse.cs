namespace Rezervation.DTOs
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }

        public string Jwt { get; set; }

        public AuthenticateResponse(int id, string jwt)
        {
            Id = id;
            Jwt = jwt;
        }
    }
}
