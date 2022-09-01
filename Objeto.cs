namespace AnalizadorLexico
{
    internal partial class Token
    {
        public TipoToken Tipo { get; set; }
        public Simbolo Simbolo { get; set; }
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
}