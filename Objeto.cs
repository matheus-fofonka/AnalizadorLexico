using System.Collections.Generic;

namespace AnalizadorLexico
{
    internal partial class Token
    {
        public TipoToken Tipo { get; set; }
        public Simbolo Simbolo { get; set; }

        public uint Linha { get; set; }
    }

    internal partial class Simbolo
    {
        public string texto { get; set; }
    }

    internal enum TipoToken
    {
        IDENTIFICADOR,
        NUMERO_INTEIRO,
        NUMERO_REAL,
        COMENTARIO,
        INT, DOUBLE, FLOAT, REAL, BREAK, CASE, CHAR, CONST, CONTINUE,
        ERRO
    }

    internal partial class Alfabeto
    {
        public List<char> Letras { get; set; }
        public List<char> Numeros { get; set; }

        public Alfabeto()
        {
            //Carrega os alfabetos via tabela ASCII por preguiça
            Letras = new List<char>();
            Numeros = new List<char>();
            CarregaLetras();
            CarregaNumeros();
        }

        private void CarregaNumeros()
        {
            //numeros
            for (int i = 48; i <= 57; i++)
            {
                Numeros.Add(((char)i));
            }
        }

        private void CarregaLetras()
        {
            //maiuscula
            for (int i = 65; i <= 90; i++)
            {
                Letras.Add(((char)i));
            }

            //minuscula
            for (int i = 97; i <= 122; i++)
            {
                Letras.Add(((char)i));
            }
        }
    }


  


}