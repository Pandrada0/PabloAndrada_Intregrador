using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numeracion
    {
        private ESistema sistema;
        private double valorNumerico;

        public ESistema Sistema
        {

            get
            {
                return this.sistema;
            }

        }
        public string Valor
        {
            get
            {
                return this.valorNumerico.ToString();
            }
        }

        public Numeracion(double valorNumerico, ESistema sistema)
        {
            this.sistema = sistema;
            this.valorNumerico = valorNumerico;
        }

        public Numeracion(string valor, ESistema sistema)
        {
            InicializarValores(valor, sistema);

        }

        private void InicializarValores(string valor, ESistema sistema)
        {
            double valorDouble;

            if (EsBinario(valor))
            {
                valorDouble = BinarioADecimal(valor);
                this.valorNumerico = valorDouble;
            }
            else if (double.TryParse(valor, out valorDouble))
            {
                this.valorNumerico = valorDouble;
            }
            else
            {
                this.valorNumerico = double.MinValue;

            }
        }

        public string ConvertirA(ESistema sistema)
        {
            if (sistema == ESistema.Decimal)
            {
                return BinarioADecimal(this.Valor).ToString();
            }
            else
            {
                return DecimalABinario(this.Valor);
            }
        }

        private bool EsBinario(string valor)
        {
            foreach (char item in valor)
            {
                if (item != '0' && item != '1')
                {
                    return false;
                }
            }
            return true;
        }

        private double BinarioADecimal(string valor)
        {
            double resultado = 0;

            if (EsBinario(valor))
            {
                resultado = Convert.ToInt32(valor, 2);
            }
            return resultado;
        }

        private string DecimalABinario(int valor)
        {

            if (valor < 0)
            {
                valor *= -1;
            }

            return Convert.ToString(valor, 2);

        }
        private string DecimalABinario(string valor)
        {
            string retorno = "Numero Invalido";

            if (int.TryParse(valor, out int numero))
            {
                retorno = DecimalABinario(numero);

            }
            return retorno;

        }

        public static bool operator !=(ESistema sistema, Numeracion numeracion)
        {
            return !(numeracion.sistema == sistema);
        }
        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return !(n1.sistema == n2.sistema);
        }
        public static  Numeracion operator -(Numeracion n1, Numeracion n2)
        {
            double resultado; 
            resultado = double.Parse(n1.ConvertirA(ESistema.Decimal)) - double.Parse(n2.ConvertirA(ESistema.Decimal));
            Numeracion resta = new Numeracion(resultado,ESistema.Decimal);
            return resta;
        }

        public static Numeracion operator *(Numeracion n1, Numeracion n2)
        {
            double resultado;
            resultado = double.Parse(n1.ConvertirA(ESistema.Decimal)) * double.Parse(n2.ConvertirA(ESistema.Decimal));
            Numeracion multiplicacion = new Numeracion(resultado, ESistema.Decimal);
            return multiplicacion;
        }

        public static Numeracion operator +(Numeracion n1, Numeracion n2)
        {
            double resultado;
            resultado = double.Parse(n1.ConvertirA(ESistema.Decimal)) + double.Parse(n2.ConvertirA(ESistema.Decimal));
            Numeracion multiplicacion = new Numeracion(resultado, ESistema.Decimal);
            return multiplicacion;
        }

        public static Numeracion operator /(Numeracion n1, Numeracion n2)
        {
            Numeracion resultado = n2;

            if (double.Parse(n2.ConvertirA(ESistema.Decimal)) != 0)
            {
                resultado = new Numeracion(double.Parse(n1.ConvertirA(ESistema.Decimal)) / double.Parse(n2.ConvertirA(ESistema.Decimal)), ESistema.Decimal);
            }
            return resultado;
        }

        public static bool operator ==(ESistema sistema, Numeracion numeracion)
        {
            return numeracion.sistema == sistema;
        }
        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            return n1.sistema == n2.sistema;
        }


        public enum ESistema
        {
            Decimal,
            Binario
        }

    }


}