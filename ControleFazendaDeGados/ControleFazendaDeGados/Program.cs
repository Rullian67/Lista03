
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.IO;

class Program
{
    struct Gados
    {
        public int codigo;
        public double leite;
        public double alim;
        public Nascimento nascimento;
        public char abate;
    }
    struct Nascimento
    {
        public int mes;
        public int ano;
    }

    static void addGados(List<Gados> lista, List<Nascimento> lista2)
    {
        Gados gadocadastrado = new Gados();
        Nascimento gadocadastrados = new Nascimento();
        Console.Write("Código do gado: ");
        gadocadastrado.codigo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Quantidade de leite produzida por semana: ");
        gadocadastrado.leite = Convert.ToDouble(Console.ReadLine());
        Console.Write("Quantidade de alimentos consumida por semana em kg: ");
        gadocadastrado.alim = Convert.ToDouble(Console.ReadLine());
        Console.Write("Mês de nascimento: ");
        gadocadastrados.mes = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ano de nascimento: ");
        gadocadastrados.ano = Convert.ToInt32(Console.ReadLine());
        gadocadastrado.abate = 'N';
        lista.Add(gadocadastrado);
        Console.WriteLine("Gado cadastrado com sucesso!");
    }

    static double TotalAlimentoConsumido(List<Gados> lista)
    {
        double totalAlimento = 0;
        foreach (Gados gado in lista)
        {
            totalAlimento += gado.alim;
        }
        Console.WriteLine($"Total de alimento consumido por semana: {totalAlimento} kg");
        return totalAlimento;
    }
    static double TotalLeiteProduzido(List<Gados> lista)
    {
        double totalLeite = 0;
        foreach (Gados gado in lista)
        {
            totalLeite += gado.leite;
        }
        Console.WriteLine($"Total de leite produzido por semana: {totalLeite} litros");
        return totalLeite;
    }

    static void salvarDados(List<Gados> lista, string nomeArquivo)
    {
        using (StreamWriter writer = new StreamWriter(nomeArquivo))
        {
            foreach (var gado in lista)
            {
                writer.WriteLine($"{gado.codigo};{gado.leite};{gado.alim};{gado.nascimento};{gado.abate}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");
    }

static void PreencherCampoAbate(List<Gados> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            Gados gado = lista[i];
            int idade = DateTime.Now.Year - gado.nascimento.ano;

            if (idade > 5 || gado.leite < 40)
            {
                gado.abate = 'S';
            }
            else
            {
                gado.abate = 'N';
            }

            lista[i] = gado;
        }
        Console.WriteLine("Campos de abate preenchidos com sucesso.");
    }
    static void AnimaisParaAbate(List<Gados> lista)
    {
        Console.WriteLine("Animais para abate:");
        foreach (Gados gado in lista)
        {
            if (gado.abate == 'S')
            {
                Console.WriteLine($"Código: {gado.codigo}, Idade: {DateTime.Now.Year - gado.nascimento.ano}, Produção de Leite: {gado.leite} litros por semana");
            }
        }
    }
    static void carregarDados(List<Gados> lista, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(';');
                Gados gado = new Gados
                {
                    codigo = int.Parse(campos[0]),
                    leite = double.Parse(campos[1]),
                    alim = double.Parse(campos[2]),
                    nascimento = new Nascimento
                    {
                        mes = int.Parse(campos[3].Split(';')[0]),
                        ano = int.Parse(campos[3].Split(';')[1])
                    },
                    abate = char.Parse(campos[4])
                };
                lista.Add(gado);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }



    static int menu()
        {
            int op;
            Console.WriteLine("*** Sistema de Controle de Gados C# ***");
            Console.WriteLine("1-Cadastrar");
            Console.WriteLine("2-Listar animais para o abate");
            Console.WriteLine("3-Total de leite produzido por semana");
            Console.WriteLine("4-Total de alimentos consumido por semana");
            Console.WriteLine("5-Animais selecionados para o abate");
            Console.WriteLine("0-Sair");
            Console.Write("Escolha uma opção:");
            op = Convert.ToInt32(Console.ReadLine());
            return op;
        }// fim funcao menu
        static void Main()
        {
            List<Gados> vetorGados = new List<Gados>();
            List<Nascimento> vetorNascimento = new List<Nascimento>();
            carregarDados(vetorGados, "dadosGados.txt");
            int op = 0;
            do
            {
                op = menu();
                switch (op)
                {
                    case 1:
                        addGados(vetorGados, vetorNascimento);
                        break;
                    case 2:
                    PreencherCampoAbate(vetorGados);
                        break;
                    case 3:
                        TotalLeiteProduzido(vetorGados);
                        break;
                    case 4:
                        TotalAlimentoConsumido(vetorGados);
                        break;
                case 5:
                    AnimaisParaAbate(vetorGados);
                    break;
                    case 0:
                        Console.WriteLine("Saindo");
                        salvarDados(vetorGados, "dadosGados.txt");
                        break;
                }// fim switch
                Console.ReadKey(); // pausa
                Console.Clear();

            } while (op != 0);

        }


    }
