using System;
using FinalProject.Credentials.Domain;
using FinalProject.Credentials.Application;
using FinalProject.Credentials.Infrastructure;
class Program
{
    static void Main(string[] args)
    {
        ICredentialRepository repository = InitRepository();
        CredentialService service = new CredentialService(repository);
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Credential Manager");
            Console.WriteLine();
            DisplayMenu();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "1":
                    AddCredential(service);
                    break;
                case "2":
                    RemoveCredential(service);
                    break;
                case "3":
                    GetCredentialById(service);
                    break;
                case "4":
                    GetAllCredentials(service);
                    break;
                case "5":
                    GetCredentialsByName(service);
                    break;
                case "6":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            Console.Clear();
        }
    }

    static ICredentialRepository InitRepository()
    {
        Console.Write("Enter the file name for the credentials: ");
        string fileName = Console.ReadLine();
        Console.WriteLine();
        return new CredentialRepositoryFileImpl(fileName);
    }

    static void DisplayMenu()
    {
        Console.WriteLine("1. Add a credential");
        Console.WriteLine("2. Remove a credential");
        Console.WriteLine("3. Get a credential by id");
        Console.WriteLine("4. Get all credentials");
        Console.WriteLine("5. Get credentials by name");
        Console.WriteLine("6. Exit");
    }

    static void AddCredential(CredentialService service)
    {
        Console.WriteLine("Credential Type: ");
        Console.WriteLine(" 1. Username/Password");
        Console.WriteLine(" 2. FTP");
        Console.Write("Enter your choice: ");
        string type = Console.ReadLine();

        Console.Write("Credential Name: ");
        string name = Console.ReadLine();
        Credential credential;

        switch (type)
        {
            case "1":
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                credential = new SimpleCredential(name, username, password);
                service.AddCredential(credential);
                break;
            case "2":
                Console.Write("Server: ");
                string server = Console.ReadLine();
                Console.Write("Port: ");
                string port = Console.ReadLine();
                Console.Write("Username: ");
                string ftpUsername = Console.ReadLine();
                Console.Write("Password: ");
                string ftpPassword = Console.ReadLine();
                Credential ftpCredential = new FtpCredential(name, ftpUsername, ftpPassword, server, port);
                service.AddCredential(ftpCredential);
                break;
            default:
                Console.WriteLine("Invalid type");
                break;
        }
    }

    static void GetCredentialsByName(CredentialService service)
    {
        Console.Write("Enter the name of the credential: ");
        string name = Console.ReadLine();
        List<Credential> credentials = service.GetCredentialsByName(name);
        PrintCredentialsShort(credentials);
        if (credentials.Count > 0)
        {
            GetCredentialById(service);
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }

    static void GetCredentialById(CredentialService service)
    {
        Console.Write("Enter the id of the credential: ");
        int id = int.Parse(Console.ReadLine());
        Credential credential = service.GetCredentialById(id);
        PrintCredentialFull(credential);
    }

    static void GetAllCredentials(CredentialService service)
    {
        List<Credential> credentials = service.GetAllCredentials();
        PrintCredentialsShort(credentials);
        if (credentials.Count > 0)
        {
            GetCredentialById(service);
        } else
        {
            Console.WriteLine("No credentials found");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }

    static void PrintCredentialsShort(List<Credential> credentials)
    {
        Console.WriteLine($"{new String('=', 10)} Credentials {new String('=', 10)}");
        foreach (var credential in credentials)
        {
            Console.WriteLine(credential.GetId() + " - " + credential.GetName());
        }
        Console.WriteLine();
    }

    static void PrintCredentialFull(Credential credential)
    {
        Console.WriteLine($"{new String('=', 30)}");
        Console.WriteLine("Id: " + credential.GetId());
        Console.WriteLine("Name: " + credential.GetName());
        Console.WriteLine("Type: " + credential.GetCredentialType());
        foreach (var detail in credential.GetDetails())
        {
            Console.WriteLine(detail.Key + ": " + detail.Value);
        }
        Console.WriteLine($"{new String('=', 30)}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    static void RemoveCredential(CredentialService service)
    {
        Console.Write("Enter the id of the credential to remove: ");
        int id = int.Parse(Console.ReadLine());
        service.RemoveCredentialById(id);
    }
}