using System;
using System.Collections.Generic;
using DIO.Series.Classes;
using DIO.Series.Enum; 

namespace DIO.Series
{
    class Program
    {
        #region CONSTANTES

        private const int LISTAR_SERIES = 1;

        private const int INSERIR_NOVA_SERIE = 2;

        private const int ATUALIZAR_SERIES = 3;

        private const int EXCLUIR_SERIE = 4;

        private const int VISUALIZAR_SERIE = 5;

        private const int LIMPAR_TELA = 6;

        private const int SAIR = 7;
        #endregion

        private static SeriesRepositorio repositirio = new SeriesRepositorio();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                int opcao = ExibirObjecoes();

                GerenciarOpcao(opcao);
            } 
        }

        /// <summary>
        /// Método que executa opcao selecionada
        /// </summary>
        /// <param name="opcao">Recebe um inteiro que representa opcao selecionada</param>
        private static void GerenciarOpcao(int opcao)
        { 
            Console.Clear();

            switch (opcao)
            {
                case LISTAR_SERIES:
                    ListarSeries();
                    break;

                case INSERIR_NOVA_SERIE:
                    Console.WriteLine("Inserir nova série!"); 
                    repositirio.Inserir(ExibiCadastro());
                    break;

                case ATUALIZAR_SERIES:
                    Console.WriteLine("Atualizar série!");
                    AtualizarSeries();
                    break;

                case EXCLUIR_SERIE:
                    Console.WriteLine("Excluir série!");
                    ExcluirSerie();
                    break;

                case VISUALIZAR_SERIE:
                    Console.Write($"Visualizar série");
                    VisualizarSerie();
                    break;

                case LIMPAR_TELA:
                    Console.Clear();
                    break;

                case SAIR:
                    Sair();
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Opção nao cadastrada no menu."); 
            } 
        }

        private static void VisualizarSerie()
        {
            Console.Write($"Digite o id da série: ");
            
            if(int.TryParse(Console.ReadLine(),out int valor))
            {
                Serie serie = repositirio.GetEntidade(valor);

                if(serie != null)
                {
                    Console.WriteLine(serie.ToString());

                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();

                    Console.Write($"Série nao encontrada");

                    Console.ReadKey();
                }
            }
        }

        private static void ExcluirSerie()
        {
            Console.Write($"{Environment.NewLine}Insira o id da serie a ser excluida: ");

            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                if (repositirio.ListaDeSeries.Contains(repositirio.GetEntidade(valor)))
                {
                    repositirio.Excluir(valor);  
                }
                else
                {
                    Console.WriteLine("Série nao escontrada!"); 
                }
            }
        }

        private static void AtualizarSeries()
        {   
            Console.Write($"{Environment.NewLine}Insira o id da serie a ser atualizada: ");

            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                if (repositirio.ListaDeSeries.Contains(repositirio.GetEntidade(valor)))
                {
                    repositirio.Atualizar(valor, ExibiCadastro()); 

                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Série nao escontrada!");

                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Método que fianliza a aplicacao.
        /// </summary>
        private static void Sair()
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// Método responsavel por adicionar uma nova serie no repositorio.
        /// <remarks>Quando o valor é diferente de -1 ele ira adicionar o valor fornecido no id do novo cadastro</remarks>
        /// </summary>
        private static Serie ExibiCadastro(int id = -1)
        { 

            foreach (int valorEnum in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{valorEnum} . {System.Enum.GetName(typeof(Genero), valorEnum)}");
            } 
            Console.Write($"{Environment.NewLine}Digite o gênero conforme as opçoes acima:");
            
            if(int.TryParse(Console.ReadLine(), out int valor))
            {
                string titulo;

                int ano;

                string descricao;

                if (System.Enum.IsDefined(typeof(Genero), valor))
                {
                    Console.Write($"Digite o título da série: ");

                    titulo = Console.ReadLine();

                    Console.Write($"Digite o ano da série: ");
                    
                    while(!int.TryParse(Console.ReadLine(), out ano))
                    {

                        Console.WriteLine("O valor digitado nao está correto");

                    }

                    Console.Write($"Digite a descricao da série: ");

                    descricao = Console.ReadLine();

                    Serie novaSerie;

                    if (id < 0)
                    { 
                        novaSerie = new Serie(repositirio.ProximoId(), (Genero)valor, titulo, descricao, ano);
                    }
                    else
                    {
                        novaSerie = new Serie(id, (Genero)valor, titulo, descricao, ano);
                    }  
                    return novaSerie;
                }
                else
                {
                    Console.WriteLine($"Opção nao encontrada");

                    Console.ReadKey(); 
                     
                }
            }
            return null;
        }
        /// <summary>
        /// Métoro responsavel por exibir a lista de todas as series cadastradas.
        /// </summary>
        private static void ListarSeries()
        {
            Console.WriteLine($"Lista de séries: ");

            List<Serie> lista = repositirio.ListaDeSeries;

            if(lista.Count > 0)
            {
                foreach (Serie item in lista)
                {
                    Console.WriteLine($"#ID {item.GetId()}: - {item.GetTitulo()}  {(item.GetStatus() ? "Excluído" : "")}");
                }

                Console.ReadKey(); 
            }
            else
            {
                Console.WriteLine("Nenhuma séries cadastradas. Precione qualquer botão para retornar ao menu inicial");

                Console.ReadKey(); 
            }
        }

        /// <summary>
        /// Métoro responsavel por estrutura e exibir menu no console.
        /// </summary>
        /// <returns></returns>
        private static int ExibirObjecoes()
        {
            Console.WriteLine($"DIO séries ao seu dispor! {Environment.NewLine}{Environment.NewLine}" +
                              $"Informe a opção desejada: {Environment.NewLine}{Environment.NewLine}" +
                              $"1 - Listar Séries {Environment.NewLine}" +
                              $"2 - Inserie nova série {Environment.NewLine}" +
                              $"3 - Atualizar série {Environment.NewLine}" +
                              $"4 - Exluir série {Environment.NewLine}" +
                              $"5 - Visualizar série {Environment.NewLine}" +
                              $"6 - Limpar tela {Environment.NewLine}" +
                              $"7 - Sair {Environment.NewLine}");

            if(int.TryParse(Console.ReadLine(), out int valor))
            {  
                return valor;
            }
            else
            {  
                return ExibirObjecoes();
            } 
        }
    }
}
