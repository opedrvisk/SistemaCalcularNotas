using System;
using System.Collections.Generic;

namespace AplicativoNotas
{
    class Program
    {
        static List<Nota> notas = new List<Nota>();

        static void Main(string[] args)
        {
            Menu(); 
        }

        static void Menu()
        {
            bool execucao = true;

            while (execucao)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Adicionar nota");
                Console.WriteLine("2 - Visualizar notas");
                Console.WriteLine("3 - Editar nota");
                Console.WriteLine("4 - Excluir nota");
                Console.WriteLine("5 - Sair");

                int opcao;
                bool numeroValido = int.TryParse(Console.ReadLine(), out opcao);

                if (!numeroValido)
                {
                    Console.WriteLine("Entrada inválida. Digite um número.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        AdicionarNota();
                        break;
                    case 2:
                        VisualizarNotas();
                        break;
                    case 3:
                        EditarNota();
                        break;
                    case 4:
                        ExcluirNota();
                        break;
                    case 5:
                        execucao = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void AdicionarNota()
        {
            Console.WriteLine("Digite o título da matéria: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digit a sua nota: ");
            string conteudo = Console.ReadLine();

            Nota nota = new Nota(titulo, conteudo);
            notas.Add(nota);

            Console.WriteLine("Nota adicionada com sucesso.");
        }

        static void VisualizarNotas()
        {
            if (notas.Count == 0)
            {
                Console.WriteLine("Nenhuma nota cadastrada.");
                return;
            }

            foreach (Nota nota in notas)
            {
                Console.WriteLine("Título: " + nota.Titulo);
                Console.WriteLine("Conteúdo: " + nota.Conteudo);
                Console.WriteLine("----------------------");
            }
        }

        static void EditarNota()
        {
            Console.WriteLine("Digite o título da nota que deseja editar: ");
            string titulo = Console.ReadLine();

            Nota nota = notas.Find(n => n.Titulo == titulo);

            if (nota != null)
            {
                Console.WriteLine("Digite o novo título da nota: ");
                string novoTitulo = Console.ReadLine();

                Console.WriteLine("Digite o novo conteúdo da nota: ");
                string novoConteudo = Console.ReadLine();

                nota.Titulo = novoTitulo;
                nota.Conteudo = novoConteudo;

                Console.WriteLine("Nota editada com sucesso.");
            }
            else
            {
                Console.WriteLine("Nota não encontrada.");
            }
        }

        static void ExcluirNota()
        {
            Console.WriteLine("Digite o título da nota que deseja excluir: ");
            string titulo = Console.ReadLine();

            Nota nota = notas.Find(n => n.Titulo == titulo);

            if (nota != null)
            {
                notas.Remove(nota);
                Console.WriteLine("Nota excluída com sucesso.");
            }
            else
            {
                Console.WriteLine("Nota não encontrada.");
            }
        }
    }

    class Nota
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        public Nota(string titulo, string conteudo)
        {
            Titulo = titulo;
            Conteudo = conteudo;
        }
    }
}
