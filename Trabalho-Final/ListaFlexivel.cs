using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final
{
    public class ListaFlexivel
    {
        private Celula primeiro;
        private Celula ultimo;

        // =====================================================
        //                    PEDRO (ESTRUTURA BASE)
        //      Construtor, InserirFim, Imprimir
        // =====================================================

        // -----------------------------
        // CONSTRUTOR (CÉLULA CABEÇA)
        // -----------------------------
        // O construtor inicializa a lista criando uma célula cabeça (sentinela).
        // Essa célula não armazena dados, mas serve como ponto fixo para facilitar
        // as operações de inserção, remoção e impressão.
        // Tanto 'primeiro' quanto 'ultimo' começam apontando para essa célula.
        public ListaFlexivel()
        {
            primeiro = ultimo = new Celula();
        }

        // -----------------------------
        // INSERIR NO FINAL
        // -----------------------------
        // Insere um novo Customer no final da lista encadeada.
        // O ponteiro 'ultimo' sempre aponta para a última célula válida,
        // o que permite que a inserção aconteça em tempo constante (O(1)).
        // A nova célula é adicionada ao final e atualizamos o ponteiro 'ultimo'.

        public void InserirFim(Customer x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }


        // -----------------------------
        // IMPRIMIR LISTA
        // -----------------------------
        // Percorre a lista a partir da primeira célula útil (ignorando a cabeça)
        // e imprime cada elemento usando o método ToString() da classe Customer.
        // O laço se encerra quando o ponteiro 'i' chega a null (fim da lista).
        public void Imprimir()
        {
            Celula i = primeiro.Prox;
            while (i != null)
            {
                Console.WriteLine(i.Elemento.ToString());
                i = i.Prox;
            }
        }

        // =====================================================
        //        MARIA LUISA (REMOVER + PESQUISAR)
        // =====================================================

        // -----------------------------
        // MÉTODO REMOVER
        // -----------------------------
        public bool Remover(string termo)
        {
            Celula anterior = primeiro;
            Celula atual = primeiro.Prox;

            while (atual != null)
            {
                if (Combina(atual.Elemento, termo))
                {
                    anterior.Prox = atual.Prox;

                    if (atual == ultimo)
                        ultimo = anterior;

                    CorrigeIndex(atual.Prox);
                    return true;
                }

                anterior = atual;
                atual = atual.Prox;
            }

            return false;
        }

        // -----------------------------
        // MÉTODO PESQUISAR
        // -----------------------------
        public ListaFlexivel Pesquisar(string termo)
        {
            ListaFlexivel listaPesq = new ListaFlexivel();
            Celula i = primeiro.Prox;
            while (i != null)
            {
                if (Combina(i.Elemento, termo))
                    listaPesq.InserirFim(i.Elemento);
                i = i.Prox;
            }

            return listaPesq;
        }

        // -------------------------------------
        // MÉTODO AUXILIAR PARA COMPARAÇÃO
        // -------------------------------------
        private bool Combina(Customer c, string termo)
        {
            termo = termo.ToLower();

            return
            c.FirstName.ToLower().Contains(termo) ||
            c.LastName.ToLower().Contains(termo) ||
            c.Email.ToLower().Contains(termo) ||
            c.Company.ToLower().Contains(termo) ||
            c.City.ToLower().Contains(termo) ||
            c.Country.ToLower().Contains(termo) ||
            c.Phone1.ToLower().Contains(termo) ||
            c.Phone2.ToLower().Contains(termo) ||
            c.Website.ToLower().Contains(termo) ||
            c.SubscriptionDate.ToLower().Contains(termo);
        }

        // =====================================================
        //        JOÃO AMARAL (MAIN + LIGAÇÃO DOS MÉTODOS)
        // =====================================================

        // -----------------------------
        // Corrige Index
        // -----------------------------
        // Função utilizada pela função remover, que visa corrigir o indice dos elementos após a remoção
        public void CorrigeIndex(Celula noInicio)
        {
            Celula i = noInicio;
            while (i != null)
            {
                i.Elemento.Index--;
                i = i.Prox;
            }
        }

        // -----------------------------
        // Conta os Customers da Lista - João
        // -----------------------------
        // Essa função conta todos elementos da lista para gerar um index correto na criação de um novo customer
        public int ContarElementos()
        {
            Celula i = primeiro.Prox;
            int cont = 0;

            while (i != null)
            {
                cont++;
                i = i.Prox;
            }
            return cont;
        }
    }
}