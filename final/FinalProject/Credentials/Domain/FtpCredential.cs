namespace FinalProject.Credentials.Domain
{
    public class FtpCredential : Credential
    {
        private string _username;
        private string _password;
        private string _domain;
        private string _port;

        public FtpCredential(int id, string name, string username, string password, string domain, string port) : base(id, name)
        {
            _type = "FTP";
            _username = username;
            _password = password;
            _domain = domain;
            _port = port;
        }

        public FtpCredential(string name, string username, string password, string domain, string port) : base(name)
        {
            _type = "FTP";
            _username = username;
            _password = password;
            _domain = domain;
            _port = port;
        }

        public override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> ftpDetails = new Dictionary<string, string>();
            ftpDetails.Add("Username", _username);
            ftpDetails.Add("Password", _password);
            ftpDetails.Add("Domain", _domain);
            ftpDetails.Add("Port", _port.ToString());
            return ftpDetails;
        }
    }
}