namespace FinalProject.Credentials
{
    public abstract class Credential
    {
        protected int _id;
        protected string _name;

        public Credential(string name, int id = 0)
        {
            _id = id;
            _name = name;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public abstract Dictionary<string, string> GetDetails();
    }
}