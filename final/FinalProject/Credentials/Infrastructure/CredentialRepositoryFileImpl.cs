using FinalProject.Credentials.Domain;
namespace FinalProject.Credentials.Infrastructure
{
    public class CredentialRepositoryFileImpl : ICredentialRepository
    {
        private string _fileName;
        private List<Credential> _credentials = new List<Credential>();

        public CredentialRepositoryFileImpl(string fileName)
        {
            _fileName = fileName;
        }

        public void AddCredential(Credential credential)
        {
            LoadCredentials();
            credential.SetId(_credentials.Count + 1);
            _credentials.Add(credential);
            SaveCredentials();
        }

        public void RemoveCredentialById(int id)
        {
            LoadCredentials();
            _credentials.RemoveAll(c => c.GetId() == id);
            SaveCredentials();
        }

        public void UpdateCredential(Credential credential)
        {
            LoadCredentials();
            _credentials.RemoveAll(c => c.GetId() == credential.GetId());
            _credentials.Add(credential);
            SaveCredentials();
        }

        public Credential GetCredentialById(int id)
        {
            LoadCredentials();
            Credential credential = _credentials.Find(c => c.GetId() == id);
            return credential;
        }

        public List<Credential> GetAllCredentials()
        {
            LoadCredentials();
            return _credentials;
        }

        public List<Credential> GetCredentialsByName(string name)
        {
            LoadCredentials();
            return _credentials.FindAll(c => c.GetName().ToLower().Contains(name));
        }

        private void LoadCredentials()
        {
            _credentials = new List<Credential>();
            if (File.Exists(_fileName))
            {
                string[] lines = File.ReadAllLines(_fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    string type = parts[2];
                    List<string> details = new List<string>();
                    for (int i = 3; i < parts.Length; i++)
                    {
                        details.Add(parts[i]);
                    }
                    switch (type)
                    {
                        case "Simple":
                            _credentials.Add(new SimpleCredential(id, name, details[0], details[1]));
                            break;
                        case "FTP":
                            _credentials.Add(new FtpCredential(id, name, details[0], details[1], details[2], details[3]));
                            break;
                    }
                }
            }
        }

        private void SaveCredentials()
        {
            List<string> lines = new List<string>();
            foreach (Credential credential in _credentials)
            {
                Dictionary<string, string> details = credential.GetDetails();
                string line = $"{credential.GetId()},{credential.GetName()},{credential.GetCredentialType()}";
                foreach (KeyValuePair<string, string> detail in details)
                {
                    line += "," + detail.Value;
                }
                lines.Add(line);
            }
            File.WriteAllLines(_fileName, lines);
        }

    }
}