using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final
{
    // =====================================================
    //                    PEDRO e MARIA
    //            (Base da Estrutura + Operações)
    // -----------------------------------------------------
    // Esta classe representa uma célula da Lista Encadeada.
    //
    // - Usamos esta estrutura na construção da Lista
    // (construtor, inserção e impressão). Pedro
    //
    // - Utilizamos a estrutura nos métodos de busca e
    // remoção, manipulando ponteiros entre as células. Maria
    //
    // Cada célula armazena um objeto Customer (Elemento)
    // e uma referência para a próxima célula (Prox).
    // =====================================================
   
    public class Celula
    {
        // -------------------------------------------
        // ELEMENTO ARMAZENADO NA CÉLULA
        // -------------------------------------------
        // Cada célula guarda um Customer, que representa
        // uma linha do arquivo CSV importado.
        
        public Customer Elemento { get; set; }
        // -------------------------------------------
        // REFERÊNCIA PARA A PRÓXIMA CÉLULA
        // -------------------------------------------
        // Isso permite que a lista seja ligada
        // dinamicamente e cresça conforme necessário.

        public Celula Prox { get; set; }
        // -------------------------------------------
        // CONSTRUTOR
        // -------------------------------------------
        // O parâmetro 'elemento' pode ser null, o que
        // permite que esta célula seja usada como
        // célula inicial na ListaFlexivel.
        public Celula(Customer elemento = null)
        {
            Elemento = elemento;
            Prox = null;
        }
    }
}
