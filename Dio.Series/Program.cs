using System;
using Dio.Series.Enums;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }

            Console.WriteLine("Obrigado por utilizar os nossos serviços!");
            Console.ReadLine();
        }

        private static void VisualizarSeries()
        {
            Console.WriteLine("Digite o ID da série que deseja visualizar:");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.GetByID(idSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSeries()
        {
            Console.WriteLine("Digite o ID da série a ser excluída:");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Delete(idSerie);
        }

        private static void AtualizarSeries()
        {
            Console.WriteLine("Digite o ID da série a ser atualizada:");
            int idSerie = int.Parse(Console.ReadLine());

            Serie novaSerie = RequererDadosSerieUsuario(idSerie);
            repositorio.Update(novaSerie);
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir uma nova série:");

            Serie novaSerie = RequererDadosSerieUsuario(repositorio.NextId());
            repositorio.Insert(novaSerie);
        }

        private static Serie RequererDadosSerieUsuario(int idSerie)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string descricao = Console.ReadLine();

            return new Serie(idSerie, (Genero)genero, titulo, descricao, ano);

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries: ");
            var lista = repositorio.GetAll();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1} {2}", serie.GetId(), serie.GetTitulo(), (serie.GetExcluido() ? "** Excluído **" : ""));
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1. Listar Séries");
            Console.WriteLine("2. Inserir uma nova Série");
            Console.WriteLine("3. Atualizar uma Série já cadastrada");
            Console.WriteLine("4. Excluir uma Série existente");
            Console.WriteLine("5. Visualizar detalhes de uma Série existente");

            Console.WriteLine("C. Limpar a tela");
            Console.WriteLine("X. Sair do programa");

            return Console.ReadLine().ToUpper();

        }
    }
}
