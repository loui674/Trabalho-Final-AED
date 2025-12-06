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

            public ListaFlexivel()
            {
                primeiro = ultimo = new Celula(); // célula cabeça
            }

            // ---------------------------------------------
            // INSERIR
            // ---------------------------------------------
            public void InserirFim(Customer x)
            {
                ultimo.Prox = new Celula(x);
                ultimo = ultimo.Prox;
            }

            // ---------------------------------------------
            // IMPRIMIR
            // ---------------------------------------------
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
            public Customer Pesquisar(string termo)
            {
                Celula i = primeiro.Prox;

                while (i != null)
                {
                    if (Combina(i.Elemento, termo))
                        return i.Elemento;

                    i = i.Prox;
                }

                return null;
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
                    c.City.ToLower().Contains(termo) ||
                    c.Country.ToLower().Contains(termo);
            }

        }
    }

        
    

