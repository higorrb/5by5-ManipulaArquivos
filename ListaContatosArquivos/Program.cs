var path = @"C:\dev\";
var file = "contatos.txt";

List<Contact> contactList = new List<Contact>();

int Menu()
{
    Console.WriteLine("[1] - Adicionar contato no arquivo");
    Console.WriteLine("[2]- Mostrar contato");
    Console.WriteLine("[3] - Deletar tudo");
    Console.WriteLine("[4] - encontrar contato");
    Console.WriteLine("[0] - sair");
    return int.Parse(Console.ReadLine());
}

bool AddContats()
{
    if (File.Exists(path + file))
    {
        Console.WriteLine("Digite um nome: ");
        string name = Console.ReadLine();
        Console.WriteLine("Digite um telefone: ");
        string phone = Console.ReadLine();
        Console.WriteLine("Digite seu sexo[M/F]: ");
        char gender = char.Parse(Console.ReadLine().ToUpper());

        var contact = new Contact(name, phone, gender);

        contactList.Add(contact);
        File.AppendAllText(path + file, contact.ToString() + "\n");
        return true;
    }
    else
    {
        File.Create(path + file).Close();
        return false;
    }
}

void ShowContacts()
{
    if (File.Exists(path + file))
    {
        Console.WriteLine(File.ReadAllText(path + file));
    }
    else
    {
        File.Create(path + file).Close();
        Console.WriteLine("Arquivo criado, tente novamente!");
    }

}

void DeleteFile()
{
    File.Delete(path + file);
    Console.WriteLine("VOCE deletou o arquivo");
}

void FindContact(string nomeBusca)
{
    var reader = new StreamReader(path + file);

    while (reader.Read() != -1)
    {
        string linha = reader.ReadLine();
        string[] vetorlinha = linha.Split(',');
        if (vetorlinha[0] == nomeBusca)
        {
            for (int i = 0; i < vetorlinha.Length; i++)
            {
                Console.WriteLine(vetorlinha[i] + "\n");
            }
        }
    }
    reader.Close();
}


while (true)
{
    switch (Menu())
    {
        case 1:
            try
            {
                if (AddContats()) Console.WriteLine("Contato adicionado!");
                else Console.WriteLine("Arquivo criado, tente novamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case 2:
            ShowContacts();
            break;

        case 3:
            DeleteFile();
            break;
        /*
        case 4:
            Console.WriteLine("Digite um nome para encontrar: ");
            FindContact(Console.ReadLine());
            break;
        */
        case 0:
            Console.WriteLine("saindo do programa");
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("teste novamente");
            break;
    }
}


