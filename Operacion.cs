using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operacion
    {

        private Numeracion primerOperando; // atributo
        private Numeracion segundoOperando;


        public Numeracion PrimerOperando
        {
            get { return this.primerOperando; }

            set { this.primerOperando = value; }
        }

        public Numeracion SegundoOperando
        {
            get { return this.segundoOperando; }

            set { this.segundoOperando = value; }
        }

        public Operacion(Numeracion primerOperando, Numeracion segundoOperando)
        {
            this.primerOperando = primerOperando;
            this.segundoOperando = segundoOperando;
        }

        public Numeracion Operar(char operador)
        {

            Numeracion resul = new Numeracion(double.MinValue, Numeracion.ESistema.Decimal);

            switch (operador)
            {
                case '-':
                    resul = PrimerOperando - SegundoOperando;
                    break;
                case '*':
                    resul = PrimerOperando * SegundoOperando;
                    break;
                case '/':
                    if (double.Parse(SegundoOperando.Valor) != 0)
                    {
                        resul = PrimerOperando / SegundoOperando;
                    }
                    break;
                default:

                    resul = PrimerOperando + SegundoOperando;
                    break;
            }
            Numeracion retorno = new Numeracion(resul.Valor, Numeracion.ESistema.Decimal);
            return retorno;
        }
    }
}
