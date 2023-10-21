
using System;
class Program
{
    struct Jogos
    {
        public string titulo;
        public string console;
        public int ano;
        public int ranking;
        public Emprestimos Emprestimo;
    }
    struct Emprestimos
    {
        public DateTime data;
        public string nome;
        public char emprestado;
    }

    static void addJogos(List<Jogos> lista)
    {
        Jogos jogosscadastrados = new Jogos();
        Console.Write("Título do jogo: ");
        jogosscadastrados.titulo = Console.ReadLine();
        Console.Write("Console do jogo: ");
        jogosscadastrados.console = Console.ReadLine();
        Console.Write("Ano do jogo: ");
        jogosscadastrados.ano = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ranking do jogo: ");
        jogosscadastrados.ranking = Convert.ToInt32(Console.ReadLine());
        jogosscadastrados.Emprestimo = new Emprestimos { emprestado = 'N', data = DateTime.MinValue, nome = string.Empty };
        lista.Add(jogosscadastrados);
        Console.WriteLine("Jogo cadastrado com sucesso!");
    }
    static void listarJogos(List<Jogos> listaEmprestimos)
    {
        Console.WriteLine("Lista de Jogos:");
        foreach (Jogos jogo in listaEmprestimos)
        {
            Console.WriteLine("Titulo:" + jogo.titulo);
            Console.WriteLine($"Console:" + jogo.console);
            Console.WriteLine($"Ano:" + jogo.ano);
            Console.WriteLine($"Ranking:" + jogo.ranking);
            Console.WriteLine("Empréstimo:");
            Console.WriteLine($"Emprestado: {jogo.Emprestimo.emprestado}");
            if (jogo.Emprestimo.emprestado == 'S')
            {
                Console.WriteLine($"Nome da Pessoa: {jogo.Emprestimo.nome}");
                Console.WriteLine($"Data do Empréstimo: {jogo.Emprestimo.data}");
            }

            Console.WriteLine();
        }
    }
    static void emprestimoJogos(List<Jogos> listaJogos, List<Jogos> listaEmprestimos)
    {
        Console.Write("Digite o título do jogo a ser emprestado: ");
        string tituloEmprestimo = Console.ReadLine();
        bool encontrado = false;

        foreach (Jogos jogo in listaJogos)
        {
            if (string.Equals(jogo.titulo, tituloEmprestimo, StringComparison.OrdinalIgnoreCase) && jogo.Emprestimo.emprestado == 'N')
            {
                var jogoEmprestado = jogo;
                Console.Write("Data do empréstimo: ");
                string dataString = Console.ReadLine();
                jogoEmprestado.Emprestimo.data = DateTime.Now;
                Console.Write("Digite o nome da pessoa que pegou o jogo emprestado: ");
                jogoEmprestado.Emprestimo.nome = Console.ReadLine();
                jogoEmprestado.Emprestimo.emprestado = 'S';

                listaEmprestimos.Add(jogoEmprestado);
                Console.WriteLine("Jogo emprestado com sucesso!");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Jogo não encontrado ou já emprestado.");
        }
    }


    static void devolverJogos(List<Jogos> listaEmprestimos)
    {
        Console.Write("Digite o título do jogo a ser devolvido: ");
        string tituloEmprestimo = Console.ReadLine();
        bool encontrado = false;
        for (int i = 0; i < listaEmprestimos.Count; i++)
        {
            if (string.Equals(listaEmprestimos[i].titulo, tituloEmprestimo, StringComparison.OrdinalIgnoreCase) && listaEmprestimos[i].Emprestimo.emprestado == 'S')
            {
                var jogo = listaEmprestimos[i];
                jogo.Emprestimo.emprestado = 'N';
                jogo.Emprestimo.data = DateTime.Now;
                Console.Write("Digite o nome da pessoa que quer devolver o jogo: ");
                jogo.Emprestimo.nome = Console.ReadLine();

                Console.WriteLine("Jogo devolvido com sucesso!");
                encontrado = true;
                break;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("Jogo não encontrado ou já devolvido.");
        }
    }


    static void buscarTitulo(List<Jogos> lista, string nomeTitulo)
    {
        int qtd = lista.Count();
        for (int i = 0; i < qtd; i++)
        {
            if (lista[i].titulo.ToUpper().Contains(nomeTitulo.ToUpper()))
            {
                Console.WriteLine("\t*** Dados do Jogo ***");
                Console.WriteLine("Título:" + lista[i].titulo);
                Console.WriteLine("Console:" + lista[i].console);
                Console.WriteLine("Ano:" + lista[i].ano);
                Console.WriteLine("Ranking:" + lista[i].ranking);
                Console.WriteLine("Empréstimos:" + lista[i].Emprestimo.emprestado);

            }// fim 

        }// fim for
    }// fim funcao
    static void ListarJogosEmprestados(List<Jogos> listaEmprestimos)
    {

        for (int i = 0; i < listaEmprestimos.Count; i++)
        {
            if (listaEmprestimos[i].Emprestimo.emprestado == 'S')
            {
                var jogo = listaEmprestimos[i];
                Console.WriteLine("Título: " + jogo.titulo);
                Console.WriteLine("Console: " + jogo.console);
                Console.WriteLine("Nome da pessoa que pegou emprestado: " + jogo.Emprestimo.nome);
                Console.WriteLine("Data do empréstimo: " + jogo.Emprestimo.data);
                Console.WriteLine();
            }
        }
    }

static int menu()
    {
        int op;
        Console.WriteLine("*** Sistema de Controle de Jogos C# ***");
        Console.WriteLine("1-Cadastrar");
        Console.WriteLine("2-Listar");
        Console.WriteLine("3-Buscar por título");
        Console.WriteLine("4-Empréstimo de Jogos");
        Console.WriteLine("5. Devolver Jogo");
        Console.WriteLine("6. Listar Jogos Emprestados");
        Console.WriteLine("0-Sair");
        Console.Write("Escolha uma opção:");
        op = Convert.ToInt32(Console.ReadLine());
        return op;
    }// fim funcao menu
    static void Main()
    {
        List<Jogos> vetorJogos = new List<Jogos>();
        List<Jogos> vetorEmprestimo = new List<Jogos>();
        int op = 0;
        do
        {
            op = menu();
            switch (op)
            {
                case 1:
                    addJogos(vetorJogos);
                    break;
                case 2:
                    listarJogos(vetorEmprestimo);
                    break;
                case 3:
                    Console.Write("Título para busca:");
                    string nomeTitulo = Console.ReadLine();
                    buscarTitulo(vetorJogos, nomeTitulo);
                    break;
                case 4:
                    emprestimoJogos(vetorJogos,vetorEmprestimo);
                    break;
                case 5:
                    devolverJogos(vetorEmprestimo);
                    break;
                case 6:
                    ListarJogosEmprestados(vetorEmprestimo);
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