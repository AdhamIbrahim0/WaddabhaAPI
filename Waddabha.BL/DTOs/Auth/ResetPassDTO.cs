namespace Waddabha.BL.DTOs.Auth
{
    public class ResetPassDTO
    {
        public string Email { get; set; }
        public int Code { get; set; }
        public string Password { get; set; }
    }
}
