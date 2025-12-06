using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final
{
    public class Celula
    {
        public Customer Elemento { get; set; }
        public Celula Prox { get; set; }

        public Celula(Customer elemento = null)
        {
            Elemento = elemento;
            Prox = null;
        }
    }
}
