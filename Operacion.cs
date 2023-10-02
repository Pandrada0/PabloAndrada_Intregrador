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
            double aux1 = double.Parse(this.primerOperando.Valor);
            double aux2 = double.Parse(this.segundoOperando.Valor);
            double aux3;
            aux3 = aux1 + aux2;
            Numeracion resul = new Numeracion(double.MinValue, Numeracion.ESistema.Decimal);
            return resul;

            //switch (operador)
            //{
            //    case '-':
            //        //resul = PrimerOperando - SegundoOperando;
            //        break;
            //    case '*':
            //        //resul = PrimerOperando * SegundoOperando;
            //        break;
            //    case '/':
            //        //if (double.Parse(SegundoOperando.Valor) != 0)
            //        //{
            //        //    resul = PrimerOperando / SegundoOperando;
            //        //}
            //        break;
            //    default:
                                
            //        break;
            //}
        }
    }
}
