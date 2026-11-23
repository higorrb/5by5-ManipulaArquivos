//reader e writer para ler e escrever nos arquivos
//Classe file e directory, arquivo e pastas

var path = @"C:\dev\"; // o @ tira a formatacao e usa os caracteres como eles são, podendo usar \ "" ,
var file = "dados.dat"; //nome do arquivo em string

/*
var sw = new StreamWriter(path+file);//sempre sobrescreve o arquivo caso ele exista

var frase = "Menos foco, mais ansiedade";
var frase2 = "vamos esquecer os erros do passado e nos focar nos erros do futuro";

sw.WriteLine(frase);
sw.WriteLine(frase2); //escrevendo dentro do arquivo
sw.Close();

var sr = new StreamReader(path + file); //ler o arquivo
Console.WriteLine(sr.ReadLine());
*/

bool PathValidation(string p)
{
    if (Directory.Exists(p))
        return true;

    try
    {
        Directory.CreateDirectory(p);
        return true;
    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine(ex.Message);
        return false;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return false;
    }
}

bool FileValidation(string p)
{
    if (File.Exists(p + file))
        return true;

    try
    {
        if (PathValidation(p))
        {
            File.Create(p + file).Close(); //precisa criar o arquivo , ele fica aberto, portanto tem q fechar o arq deppois
            return true;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return false;
    }

    return false;
}

void AddPhrase(string s)
{
    if (FileValidation(path))
    {
        var reader = new StreamReader(path + file);
        var phrases = new List<string>();

        while (reader.Read() != -1)
        {
            phrases.Add(reader.ReadLine());

        }
        reader.Close();

        phrases.Add(s);

        var writer = new StreamWriter(path + file);

        foreach (var item in phrases)
        {
            writer.WriteLine(item);
        }

        writer.Close(); // quando ele fecha o arquivo ele grava as alteracoes
    }
}

void AddSimple(string s)
{
    File.AppendAllText(path + file, s);
}

void ShowPhrases()
{
    var reader = new StreamReader(path + file);
    Console.WriteLine(reader.ReadToEnd());
    reader.Close();
}

int MainMenu()
{
    Console.WriteLine("1-Adicionar frase no arquivo");
    Console.WriteLine("2- Mostrar frases d arquivo");
    Console.WriteLine("0 - sair");
    return int.Parse(Console.ReadLine());
}


while (true)
{
    switch (MainMenu())
    {
        case 1:
            Console.WriteLine("Informe sua frase desmotivacional: ");
            //AddPhrase(Console.ReadLine());
            AddSimple(Console.ReadLine());
            break;
        case 2:
            try
            {
                ShowPhrases();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 0:
            Console.WriteLine("Hasta la vista baby!");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("nao entendi");
            break;
    }
}
