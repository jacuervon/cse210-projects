namespace FinalProject.Credentials
{
    public interface ICredentialRepository
    {

        void AddCredential(Credential credential);
        void RemoveCredentialById(int id);
        void UpdateCredential(Credential credential);
        Credential GetCredentialById(int id);
        List<Credential> GetAllCredentials();
        List<Credential> GetCredentialsByName(string name);
    }
}