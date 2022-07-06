using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }
    static void Menu()
    {
        Console.WriteLine();
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Abrir e Editar arquivo de texto");
        Console.WriteLine("2 - Criar novo arquivo");
        Console.WriteLine("3 - Sair");

        short opcao = short.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1: Abrir(); break;
            case 2: Criar(); break;
            case 3: System.Environment.Exit(0); break;
            default: Console.WriteLine("Opção inválida."); Menu(); break;
        }
    }
    static void Abrir()
    {
        Console.Clear();
        Console.WriteLine("digite o caminho do arquivo: ");
        string local = Console.ReadLine();

        using (var file = new StreamReader(local))
        {
            string texto = file.ReadToEnd();
            Console.WriteLine("Seu texto: " + "\n" + texto);
            Editar(texto);
        }
        Console.WriteLine();
        Console.ReadLine();

    }
    static void Editar(string txt)
    {
        Console.WriteLine("Digite o novo texto: ");
        txt = "";
        do
        {
            txt += Console.ReadLine();
            txt += Environment.NewLine;

        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);
        Console.WriteLine(txt);
        Salvar(txt);
    }
    static void Criar()
    {
        Console.WriteLine("Se quiser sair, digite ESC");
        Console.WriteLine("Digite seu texto: ");
        string texto = "";
        do
        {
            texto += Console.ReadLine();
            texto += Environment.NewLine;

        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);

        Console.WriteLine(texto);
        Salvar(texto);
    }
    static void Salvar(string texto)
    {
        Console.Clear();
        Console.WriteLine("digite onde você quer salvar o Arquivo: ");
        var local = Console.ReadLine();

        using (var file = new StreamWriter(local))
        {
            file.Write(texto);
        }
        Console.WriteLine($"Arquivo {local} salvo com sucesso!");
        Console.ReadLine();
        Menu();
    }
}

