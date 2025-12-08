using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Customer cliente;
            bool sair = false;
            string nome;

            while (sair == false)
            {
                Console.Clear();
                System.Console.WriteLine("============================================");
                System.Console.WriteLine("============= Gerenciador de Dados =========");
                System.Console.WriteLine("============================================");
                System.Console.WriteLine("Selecione uma opção:");
                System.Console.WriteLine("1)Carregar arquivos CSV\n2)Adicionar um novo Customer\n3)Remover Customer\n4)Pesquisar na Lista\n5)Imprimir Lista\n0)Sair");
                int op = int.Parse(Console.ReadLine());
                System.Console.WriteLine("============================================");
                switch (op)
                {
                    case 1:
                        CarregaDados(lista);
                        break;
                    case 2:
                        Console.Clear();
                        Customer cliente = CriaCustomer(lista);
                        lista.InserirFim(cliente);
                        break;
                    case 3:
                        Console.Clear();
                        System.Console.WriteLine("=============================================");
                        System.Console.WriteLine("Digite o nome do Customer que deseja remover");
                        nome = Console.ReadLine();
                        System.Console.WriteLine("=============================================");
                        if (lista.Pesquisar(nome) != null)
                            System.Console.WriteLine("Cliente removido com sucesso!");
                        else
                            System.Console.WriteLine("Cliente não encontrado");
                        break;
                    case 4:
                        Console.Clear();
                        System.Console.WriteLine("==============================================");
                        System.Console.WriteLine("Digite o nome do Customer que deseja pesquisar");
                        nome = Console.ReadLine();
                        System.Console.WriteLine("==============================================");
                        cliente = lista.Pesquisar(nome);
                        if (cliente != null)
                            System.Console.WriteLine(cliente.ToString());
                        else
                            System.Console.WriteLine("Cliente não encontrado");
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
}
