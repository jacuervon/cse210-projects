namespace FinalProject.Credentials
{
    public class SimpleCredential : Credential
    {
        private string _username;
        private string _password;

        public SimpleCredential(int id, string name, string username, string password) : base(name, id)
        {
            _username = username;
            _password = password;
        }

        public SimpleCredential(string name, string username, string password) : base(name)
        {
            _username = username;
            _password = password;
        }

        public override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> simpleDetails = new Dictionary<string, string>();
            simpleDetails.Add("Username", _username);
            simpleDetails.Add("Password", _password);
            return simpleDetails;
        }
    }
}