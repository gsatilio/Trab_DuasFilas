using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trab_DuasFilas
{
    internal class Numero
    {
        int valor;
        Numero proximo;
        public Numero(int numero)
        {
            this.valor = numero;
            this.proximo = null;
        }
        public void setProximo(Numero num)
        {
            this.proximo = num;
        }
        public Numero getProximo()
        {
            return this.proximo;
        }
        public int getNumero()
        {
            return this.valor;
        }
        public override string? ToString()
        {
            return "" + valor;
        }
    }
}
