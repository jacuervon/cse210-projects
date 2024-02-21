namespace FinalProject.Credentials.Domain
{
    public abstract class Credential
    {
        protected int _id;
        protected string _name;

        protected string _type;

        public Credential(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public Credential(string name)
        {
            _id = 0;
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

        public string GetCredentialType()
        {
            return _type;
        }

        public void SetId(int id)
        {
            if (_id == 0)
            {
                _id = id;
            }
        }

        public abstract Dictionary<string, string> GetDetails();
    }
}