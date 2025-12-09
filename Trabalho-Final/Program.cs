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
            CSVReader reader= new CSVReader();
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
                        reader.Start();
                        break;

                    case 2:
                        Console.Clear();
                        Customer cliente = CriaCustomer(lista);
                        lista.InserirFim(cliente);
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
                        ListaFlexivel listaResult = new ListaFlexivel();
                        System.Console.WriteLine("==============================================");
                        System.Console.WriteLine("Para realizar a pesquisa digite o termo de busca relativo ao cliente, como nome, telefone, email, cidade...");
                        termo = Console.ReadLine();
                        System.Console.WriteLine("========== Resultados da pesquisa ============");

                        listaResult = lista.Pesquisar(termo);
                        if (listaResult.ContarElementos() > 0)
                            listaResult.Imprimir();
                        foreach (Customer c in listaResult)
                            System.Console.WriteLine(c.ToString());
                        else
                            System.Console.WriteLine("Não foram encontrados resultados na pesquisa");
                        break;

                    case 5:
                        Console.Clear();
                        System.Console.WriteLine("==============================================");
                        System.Console.WriteLine("========= Impressão de Lista Completa ========");
                        System.Console.WriteLine("==============================================");
                        lista.Imprimir();
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
            string caminho= "Trabalho-Final-AED/Trabalho-Final/dados";
            string[] arquivos = Directory.GetFiles(caminho);
            Console.WriteLine("Arquivos encontrados");

            Console.Clear();
            System.Console.WriteLine("Selecione o arquivo que deseja importar:");
            
            // Um dos arquivos importados é escolhido para ser passado como vetor, transformando
            // seus dados em dados úteis.
            int cont=0;
            foreach (string arquivo in arquivos)
            {
            System.Console.WriteLine(cont+".");
            Console.WriteLine(Path.GetFileName(arquivo));
            cont++;
            }
            // Index do array (dos documentos) é coletado.
            cont=int.Parse(Console.ReadLine());
            // Finalmente, o caminho do arquivo principal é extraído.
            caminho=arquivos[cont];

            //O leitor do documento é criado.
            StreamReader reader= null;
            if (File.Exists(caminho))
            {
                //abrindo documento...
                reader= new StreamReader(File.OpenRead(caminho));

                //loop de leitura do documento...
                while (!reader.EndOfStream)
                {
                    var line= reader.ReadLine();
                    var valores= line.Split(',');
                    
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

            x.CustomerId = CriaGuid();

            x.FirstName = valores[0];

            x.LastName = valores[1];

            x.Company = valores[2];

            x.Country = valores[3];

            x.Phone1 = valores[4];

            x.Phone2 = valores[5];

            x.Email = valores[6];

            x.SubscriptionDate = valores[7];

            x.Website = valores[8];

            return x;
            }

            static string CriaGuid()
            {
            Guid novoId = Guid.NewGuid();
            string idSemHifens = novoId.ToString("N");
            return idSemHifens;
            }    

}
}
