using FinalProject.Credentials.Domain;
namespace FinalProject.Credentials.Application
{
    public class CredentialService
    {
        private ICredentialRepository _credentialRepository;

        public CredentialService(ICredentialRepository credentialRepository)
        {
            _credentialRepository = credentialRepository;
        }

        public void AddCredential(Credential credential)
        {
            _credentialRepository.AddCredential(credential);
        }

        public void RemoveCredentialById(int id)
        {
            _credentialRepository.RemoveCredentialById(id);
        }

        public void UpdateCredential(Credential credential)
        {
            _credentialRepository.UpdateCredential(credential);
        }

        public Credential GetCredentialById(int id)
        {
            return _credentialRepository.GetCredentialById(id);
        }

        public List<Credential> GetAllCredentials()
        {
            return _credentialRepository.GetAllCredentials();
        }

        public List<Credential> GetCredentialsByName(string name)
        {
            return _credentialRepository.GetCredentialsByName(name);
        }
    }
}