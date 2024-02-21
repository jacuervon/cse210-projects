using FinalProject.Clients;
namespace FinalProject.Users { 
    public class User {
        private string _name;
        private string _nickname;
        private string _password; 
        private int _role;
        private List<Client> _clients = new List<Client>();
    }

}