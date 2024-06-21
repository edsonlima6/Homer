namespace Homer.Domain.Entities
{
    public class User : EntityBase
    {
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _userName = string.Empty;
        public string Email { get => _email; set => _email = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
