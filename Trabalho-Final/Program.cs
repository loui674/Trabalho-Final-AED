using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  
Integrantes:
Ana Luiza Damasceno Miranda
Christian Augusto Soares Diniz
João Vitor Alves Amaral
Maria Luisa Couto Fernandes
Pedro Martins Assunção de Oliveira
 */

// ===============================================
//                JOÃO AMARAL - MENU              
// ===============================================
namespace Trabalho_Final
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListaFlexivel lista = new ListaFlexivel();
            ListaFlexivel listaResult;
            CSVReader reader = new CSVReader();
            Customer cliente;
            bool sair = false;
            string termo;
            int index;

            while (sair == false)
            {
                Console.Clear();
                System.Console.WriteLine("============================================");
                System.Console.WriteLine("============= Gerenciador de Dados =========");
                System.Console.WriteLine("============================================");
                System.Console.WriteLine("Selecione uma opção:");
                System.Console.WriteLine("1)Carregar arquivos CSV\n2)Adicionar um novo Customer\n3)Remover Customer\n4)Pesquisar na Lista\n5)Imprimir Lista\n0)Sair\n\nObs: a remoção de customer é feita baseado no Index, faça uma pesquisa antes de selecionar a opção");
                int op = int.Parse(Console.ReadLine());
                System.Console.WriteLine("============================================");
                switch (op)
                {
                    case 1:
                        reader.start(lista);
                        break;

                    case 2:
                        Console.Clear();
                        Customer cliente1 = CriaCustomer(lista);
                        lista.InserirFim(cliente1);
                        break;

                    case 3:
                        Console.Clear();
                        System.Console.WriteLine("=============================================");
                        System.Console.WriteLine("Digite o index do Customer que deseja remover");
                        System.Console.WriteLine("=============================================");
                        index = int.Parse(Console.ReadLine());
                        if (lista.Remover(index) == true)
                            System.Console.WriteLine("Cliente removido com sucesso!");
                        else
                            System.Console.WriteLine("Cliente não encontrado");
                        break;

                    case 4:
                        Console.Clear();
                        System.Console.WriteLine("==============================================");
                        System.Console.WriteLine("Para realizar a pesquisa digite o termo de busca relativo ao cliente, como nome, telefone, email, cidade...");
                        termo = Console.ReadLine();
                        System.Console.WriteLine("========== Resultados da pesquisa ============");

                        lista.neoPesquisar(termo);
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        System.Console.WriteLine("==============================================");
                        System.Console.WriteLine("========= Impressão de Lista Completa ========");
                        System.Console.WriteLine("==============================================");
                        lista.Imprimir();
                        Console.ReadKey();
                        break;

                    case 0:
                        System.Console.WriteLine("Encerrando programa...");
                        sair = true;
                        break;

                    default:
                        System.Console.WriteLine("Selecione uma opção válida");
                        break;
                }


            }
        }

        // -----------------------------
        // REQUISITA OS DADOS DO CUSTOMER - João
        // -----------------------------
        // Essa função solicita os dados do customer
        // Para que eles sejam utilizados pelo parâmetro da função InserirFim

        static Customer CriaCustomer(ListaFlexivel lista)
        {
            Console.Clear();

            Customer x = new Customer();

            x.Index = lista.ContarElementos() + 1;

            x.CustomerId = CriaGuid();

            System.Console.WriteLine("Insira o primeiro nome do customer");
            x.FirstName = Console.ReadLine();

            System.Console.WriteLine("Insira o último nome do customer");
            x.LastName = Console.ReadLine();

            System.Console.WriteLine("Insira o a companhia do customer");
            x.Company = Console.ReadLine();

            System.Console.WriteLine("Insira a cidade do customer");
            x.City = Console.ReadLine();

            System.Console.WriteLine("Insira o país do customer");
            x.Country = Console.ReadLine();

            System.Console.WriteLine("Insira o telefone 1 do customer");
            x.Phone1 = Console.ReadLine();

            System.Console.WriteLine("Insira o telefone 2 do customer");
            x.Phone2 = Console.ReadLine();

            System.Console.WriteLine("Insira o Email do customer");
            x.Email = Console.ReadLine();

            System.Console.WriteLine("Insira a data de inscrição do customer");
            x.SubscriptionDate = Console.ReadLine();

            System.Console.WriteLine("Insira o site do customer");
            x.Website = Console.ReadLine();

            return x;
        }

        // -----------------------------
        // CRIADOR DE GUID - João
        // -----------------------------
        // Essa função gera um código guid simples
        // Para que ele seja utilizado pela função CriaCustomer como um id único para cada Customer
        static string CriaGuid()
        {
            Guid novoId = Guid.NewGuid();
            string idSemHifens = novoId.ToString("N");
            return idSemHifens;
        }
    }
    internal class CSVReader
    {
        public void start(ListaFlexivel lista)
        {
            // A pasta onde ficará os documentos importados é passada pelo "caminho" abaixo:
            string caminho = "dados";
            string[] arquivos = Directory.GetFiles(caminho);
            Console.WriteLine("Arquivos encontrados");

            Console.Clear();
            System.Console.WriteLine("=============================================");
            System.Console.WriteLine("Selecione o arquivo que você deseja importar:");
            System.Console.WriteLine("=============================================");
            System.Console.WriteLine();

            // Um dos arquivos importados é escolhido para ser passado como vetor, transformando
            // seus dados em dados úteis.
            int cont = 0;
            foreach (string arquivo in arquivos)
            {
                System.Console.WriteLine(cont + ".");
                Console.WriteLine(Path.GetFileName(arquivo));
                cont++;
            }
            // Index do array (dos documentos) é coletado.
            cont = int.Parse(Console.ReadLine());
            // Finalmente, o caminho do arquivo principal é extraído.
            caminho = arquivos[cont];

            //O leitor do documento é criado.
            StreamReader reader = null;
            if (File.Exists(caminho))
            {
                //abrindo documento...
                reader = new StreamReader(File.OpenRead(caminho));

                //loop de leitura do documento...
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var valores = line.Split(',');

                    // A lista é alimentada com objetos contendo os elementos extraídos do 
                    // documento
                    Customer cliente = CriaCustomerCSV(lista, valores);
                    lista.InserirFim(cliente);
                }
            }

        }
        //Função que alimenta o objeto com os elementos:
        static Customer CriaCustomerCSV(ListaFlexivel lista, string[] valores)
        {
            Console.Clear();

            Customer x = new Customer();

            x.Index = lista.ContarElementos() + 1;

            x.CustomerId = valores[1];

            x.FirstName = valores[2];

            x.LastName = valores[3];

            x.Company = valores[4];

            x.City = valores[5];

            x.Country = valores[6];

            x.Phone1 = valores[7];

            x.Phone2 = valores[8];

            x.Email = valores[9];

            x.SubscriptionDate = valores[10];

            x.Website = valores[11];

            return x;
        }

    }
}
