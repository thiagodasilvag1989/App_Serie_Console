using App_Serie_Console.Classes;
using System;

namespace App_Serie_Console
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
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Opção Inválida!"); break ;
                }
                Console.WriteLine();
                Console.WriteLine("Digite Qualquer Tecla para Continuar");
                Console.ReadKey();
                Console.Clear();
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Deseja excluir série? (S/N)?");
            char s = char.Parse(Console.ReadLine().ToUpper());
            if (s.Equals('S'))
            {
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());
                repositorio.Exclui(indiceSerie);
                Console.WriteLine("");
                Console.WriteLine("Série excluída com sucesso!");
                Console.WriteLine("");
            }
            else if (s.Equals('N'))
            {
                //Console.WriteLine("ok");
                return;
            }
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie + Environment.NewLine);
        }

        private static void validar(out int entradaGenero, out string entradaTitulo, out int entradaAno, out string entradaDescricao)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write(" " + Environment.NewLine);
            Console.Write("Digite o gênero entre as opções acima: ");
            entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            entradaDescricao = Console.ReadLine();
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            int entradaGenero, entradaAno;
            string entradaTitulo, entradaDescricao;
            validar(out entradaGenero, out entradaTitulo, out entradaAno, out entradaDescricao);

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
            Console.WriteLine();
            Console.WriteLine("Série atualizada com sucesso!");
            Console.WriteLine();
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries" + Environment.NewLine);

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada." + Environment.NewLine);
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série: ");

            int entradaGenero, entradaAno;
            string entradaTitulo, entradaDescricao;
            validar(out entradaGenero, out entradaTitulo, out entradaAno, out entradaDescricao);

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                    descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
            Console.WriteLine();
            Console.WriteLine("Série inserida com sucesso!" + Environment.NewLine);
            Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("////////////////////////////////////////////////////");
            Console.WriteLine("|||||||||||    Catálogos de Séries     |||||||||||||");
            Console.WriteLine("////////////////////////////////////////////////////");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
