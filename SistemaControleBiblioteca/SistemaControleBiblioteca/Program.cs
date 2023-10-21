using System;
class Program
{
    struct Livros
    {
        public string titulo;
        public string autor;
        public int ano;
        public int prateleira;
    }
    static void addLivros(List<Livros> lista)
    {
        Livros livroscadastrados = new Livros();
        Console.Write("Título do livro: ");
        livroscadastrados.titulo = Console.ReadLine();
        Console.Write("Autor do livro: ");
        livroscadastrados.autor = Console.ReadLine();
        Console.Write("Ano do livro: ");
        livroscadastrados.ano = Convert.ToInt32(Console.ReadLine());
        Console.Write("Prateleira do livro: ");
        livroscadastrados.prateleira = Convert.ToInt32(Console.ReadLine());


        lista.Add(livroscadastrados);
        Console.WriteLine("Livro cadastrado com sucesso!");
    }
    static void listarLivros(List<Livros> lista)
    {
        Console.WriteLine("Lista de Livros:");
        foreach (Livros livro in lista)
        {
            Console.WriteLine("Titulo:" + livro.titulo);
            Console.WriteLine($"Autor:" + livro.autor);
            Console.WriteLine($"Ano:" + livro.ano );
            Console.WriteLine($"Prateleira:" + livro.prateleira);
            Console.WriteLine();
        }
    }

    static void buscarTitulo(List<Livros> lista, string nomeTitulo)
    {
        int qtd = lista.Count();
        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].titulo.ToUpper().Contains(nomeTitulo.ToUpper()))
            {
                Console.WriteLine("\t*** Dados do Livro ***");
                Console.WriteLine("Nome:" + lista[i].titulo);
                Console.WriteLine("Prateleira:" + lista[i].prateleira);
            }// fim 

        }// fim for
    }// fim funcao
    static void buscarAno(List<Livros> lista, int nomeAno)
    {
        int qtd = lista.Count();
        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].ano < nomeAno)
                {
                Console.WriteLine("\t*** Livros mais novos que o ano escolhido ***");
                Console.WriteLine("Título:" + lista[i].titulo);
                Console.WriteLine("Autor:" + lista[i].autor);
                Console.WriteLine("Ano:" + lista[i].ano);
                Console.WriteLine("Prateleira:" + lista[i].prateleira);
            }// fim 

        }// fim for
    }// fim funcao
    static int menu()
    {
        int op;
        Console.WriteLine("*** Sistema de Controle de livros C# ***");
        Console.WriteLine("1-Cadastrar");
        Console.WriteLine("2-Listar");
        Console.WriteLine("3-Buscar por título");
        Console.WriteLine("4-Buscar por Ano");
        Console.WriteLine("0-Sair");
        Console.Write("Escolha uma opção:");
        op = Convert.ToInt32(Console.ReadLine());
        return op;
    }// fim funcao menu
    static void Main()
    {
        List<Livros> vetorLivros = new  List<Livros>();
        int op = 0;
        do
        {
            op = menu();
            switch (op)
            {
                case 1:
                    addLivros(vetorLivros);
                    break;
                case 2:
                    listarLivros(vetorLivros);
                    break;
                case 3:
                    Console.Write("Título para busca:");
                    string nomeTitulo = Console.ReadLine();
                    buscarTitulo(vetorLivros, nomeTitulo);
                    break;
                    case 4:
                    Console.Write("Ano para busca:");
                    int nomeAno = Convert.ToInt32(Console.ReadLine());
                    buscarAno(vetorLivros, nomeAno);
                    break;
                case 0:
                    Console.WriteLine("Saindo");
                    break;
            }// fim switch
            Console.ReadKey(); // pausa
            Console.Clear();

        } while (op != 0);

    }


}
