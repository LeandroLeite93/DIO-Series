using System;

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
                   ListarSerie();
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
                   throw new ArgumentOutOfRangeException();
               }
               opcaoUsuario = ObterOpcaoUsuario();
           }
             Console.WriteLine("Obrigado Por Utilizar Nossos Serviços.");
             Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da Serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie); 
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da Serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da Serie");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genêro entre as Opção Acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Serie: ");
            string entradaDescriçao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescriçao);

            repositorio.Atualiza(indiceSerie, atualizarSerie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Genêro entre as Opções a Cima"); 
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Serie");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Serie");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo, 
                                         ano: entradaAno, 
                                         descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar Series");

            var lista = repositorio.Lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Listar Series");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcuido();
                if(!excluido){ 
                Console.WriteLine("#DIO {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Series Ao Seu Dispor");
            Console.WriteLine("Informe sua Opção Desejada: ");

            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir Nova Serie");
            Console.WriteLine("3 - Atualizar Series");
            Console.WriteLine("4 - Vizualizar Serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string ObterOpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return ObterOpcaoUsuario;
        }
    }
}
