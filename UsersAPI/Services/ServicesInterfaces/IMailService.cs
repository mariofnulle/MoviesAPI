namespace UsersAPI.Services.ServicesInterfaces
{
    public interface IMailService
    {
        public void SendMail(string[] recipients, string subject, int userId, string activationCode);
    }
}
