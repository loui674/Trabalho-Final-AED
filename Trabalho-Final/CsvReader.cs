namespace Trabalho_Final
{
    public class CSVReader
    {
        public void Start()
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
                    Customer cliente = CriaCustomerCSV(lista);
                    lista.InserirFim(cliente);
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
            //Função que cria um guid:
            static string CriaGuid()
            {
            Guid novoId = Guid.NewGuid();
            string idSemHifens = novoId.ToString("N");
            return idSemHifens;
            }
            
        }

        

    }
}