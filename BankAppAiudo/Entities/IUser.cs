namespace BankAppAiudo.Entities
{
    public interface IUser
    {
        public string Id { get; }
        public string Password { get; }
        public int AccountNumber { get; }
        public double Balance { get; }

        public string ChangePassword(string id, string password, string newpassword);
    }
}