using System;

using FinalProject.Credentials;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "credentials.txt";
        ICredentialRepository credentialRepository = new CredentialRepositoryFileImpl(fileName);
        CredentialService credentialService = new CredentialService(credentialRepository);
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Welcome to the Credential Manager");
            Console.WriteLine("1. Add a new credential");
            Console.WriteLine("2. Remove a credential");
            Console.WriteLine("3. Update a credential");
            Console.WriteLine("4. Get a credential by ID");
            Console.WriteLine("5. Get all credentials");
            Console.WriteLine("6. Get credentials by name");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            int choice = int.Parse(input);

            switch (choice)
            {
                case 1:
                    Credential credential;
                    Console.Write("Enter the name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Types of credential: ");
                    Console.WriteLine(" 1. Username/Password");
                    Console.WriteLine(" 2. FTP");
                    Console.WriteLine("Enter the type: ");
                    string type = Console.ReadLine();
                    if (int.Parse(type) == 2)
                    {
                        Console.Write("Enter the username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter the password: ");
                        string password = Console.ReadLine();
                        Console.Write("Enter the domain: ");
                        string domain = Console.ReadLine();
                        Console.Write("Enter the port: ");
                        string port = Console.ReadLine();
                        credential = new FtpCredential(name, username, password, domain, port);

                    }
                    else
                    {
                        Console.Write("Enter the username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter the password: ");
                        string password = Console.ReadLine();
                        credential = new SimpleCredential(name, username, password);
                    }
                    credentialService.AddCredential(credential);
                    break;
                case 2:
                    Console.Write("Enter the ID: ");
                    input = Console.ReadLine();
                    int id = int.Parse(input);
                    credentialService.RemoveCredentialById(id);
                    break;
                case 4:
                    Console.Write("Enter the ID: ");
                    input = Console.ReadLine();
                    id = int.Parse(input);
                    credential = credentialService.GetCredentialById(id);
                    if (credential == null)
                    {
                        Console.WriteLine("Credential not found");
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("=====================================");
                    Console.WriteLine(credential.GetId() + ": " + credential.GetName());
                    foreach (KeyValuePair<string, string> detail in credential.GetDetails())
                    {
                        Console.WriteLine(detail.Key + ": " + detail.Value);
                    }
                    break;
                case 5:
                    List<Credential> credentials = credentialService.GetAllCredentials();
                    Console.Clear();
                    foreach (Credential c in credentials)
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine(c.GetId() + ": " + c.GetName());
                        foreach (KeyValuePair<string, string> detail in c.GetDetails())
                        {
                            Console.WriteLine(detail.Key + ": " + detail.Value);
                        }
                        Console.WriteLine("=====================================");
                    }
                    break;
                case 6:
                    Console.Write("Enter the name: ");
                    name = Console.ReadLine();
                    List<Credential> credentialsByName = credentialService.GetCredentialsByName(name);
                    foreach (Credential c in credentialsByName)
                    {
                        Console.WriteLine(c);
                    }
                    break;
                case 7:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        }
    }
}