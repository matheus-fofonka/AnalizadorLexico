using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AnalizadorLexico
{
    internal partial class FormIdentificador : Form
    {
        public List<Token> ListaTokens = new List<Token>();
        public List<Token> ListaErros = new List<Token>();
        public List<Simbolo> ListaSimbolos = new List<Simbolo>();

        private List<string> buffer = new List<string>();

        private Token tokenAtual = null;
        private string itemAtual = null;
        private uint linha = 1;

        private bool controleIdentificaTextos = false; private bool controleIdentificaNumeros = false;

        public FormIdentificador(List<string> pBuffer)
        {
            InitializeComponent();

            this.buffer = pBuffer;
        }

        public void Identificar()
        {
            foreach (var item in buffer)
            {
                itemAtual = item;
                tokenAtual = null;
                controleIdentificaTextos = false; controleIdentificaNumeros = false;
                bgWorkerIdentificaTextos.RunWorkerAsync(); bgWorkerIdentificaNumeros.RunWorkerAsync();

                while (tokenAtual == null || !controleIdentificaTextos || !controleIdentificaNumeros)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);

                    if (controleIdentificaTextos &&
                        controleIdentificaNumeros &&
                        tokenAtual == null)
                    {
                        tokenAtual = new Token()
                        {
                            Simbolo = new Simbolo() { texto = item },
                            Tipo = TipoToken.ERRO
                        };
                    }
                }
                tokenAtual.Linha = linha;

                if (tokenAtual.Tipo != TipoToken.ERRO && tokenAtual.Tipo != TipoToken.COMENTARIO)
                {
                    if (tokenAtual.Tipo == TipoToken.IDENTIFICADOR)
                    {
                        if (!ListaSimbolos.Exists(x => x.texto == tokenAtual.Simbolo.texto))
                            ListaSimbolos.Add(tokenAtual.Simbolo);
                        else
                            tokenAtual.Simbolo = ListaSimbolos.FirstOrDefault(x => x.texto == tokenAtual.Simbolo.texto);
                    }
                    else if (tokenAtual.Simbolo != null && tokenAtual.Simbolo.texto != null)
                        ListaSimbolos.Add(tokenAtual.Simbolo);

                    ListaTokens.Add(tokenAtual);
                }
                else if (tokenAtual.Tipo == TipoToken.COMENTARIO)
                    ListaTokens.Add(tokenAtual);
                else
                    ListaErros.Add(tokenAtual);

                linha++;
            }

            var a = 0;
        }

        private void bgWorkerIdentificaTextos_DoWork(object sender, DoWorkEventArgs e)
        {
            if (itemAtual.Length >= 2 && itemAtual[0].ToString() + itemAtual[1].ToString() == "//")
            {
                Simbolo simbolo = new Simbolo()
                {
                    texto = itemAtual
                };
                Token token = new Token()
                {
                    Simbolo = simbolo,
                    Tipo = TipoToken.COMENTARIO
                };
                tokenAtual = token;
                return;
            }
            uint num = 100;
            if (!uint.TryParse(itemAtual[0].ToString(), out num))
            {
                //SWITCH RESERVADAS
                switch (itemAtual)
                {
                    case "int":
                        tokenAtual = new Token() { Simbolo = new Simbolo(), Tipo = TipoToken.INT }; return;
                        break;

                    case "double":
                        tokenAtual = new Token() { Simbolo = new Simbolo(), Tipo = TipoToken.DOUBLE }; return;
                        break;

                    case "float":
                        tokenAtual = new Token() { Simbolo = new Simbolo(), Tipo = TipoToken.FLOAT }; return;
                        break;

                    case "real":
                        tokenAtual = new Token() { Simbolo = new Simbolo(), Tipo = TipoToken.REAL }; return;
                        break;

                    case "break":
                        tokenAtual = new Token() { Simbolo = new Simbolo(), Tipo = TipoToken.BREAK }; return;
                        break;

                    case "case":
                        tokenAtual = new Token() { Simbolo = new Simbolo(), Tipo = TipoToken.CASE }; return;
                        break;

                    case "char":
                        tokenAtual = new Token() { Simbolo = new Simbolo(), Tipo = TipoToken.CHAR }; return;
                        break;

                    case "const":
                        tokenAtual = new Token() { Simbolo = new Simbolo(), Tipo = TipoToken.CONST }; return;
                        break;

                    case "continue":
                        tokenAtual = new Token() { Simbolo = new Simbolo(), Tipo = TipoToken.CONTINUE }; return;
                        break;
                }

                bool valido = true;
                Alfabeto alfabeto = new Alfabeto();
                foreach (var item in itemAtual)
                {
                    if (!(alfabeto.Letras.Contains(item) || alfabeto.Numeros.Contains(item)))
                        valido = false;
                }

                if (valido)
                {
                    Simbolo simbolo = new Simbolo()
                    {
                        texto = itemAtual
                    };
                    Token token = new Token()
                    {
                        Simbolo = simbolo,
                        Tipo = TipoToken.IDENTIFICADOR
                    };
                    tokenAtual = token;
                    return;
                }
            }
        }

        private void bgWorkerIdentificaTextos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            controleIdentificaTextos = true;
        }

        private void bgWorkerIdentificaNumeros_DoWork(object sender, DoWorkEventArgs e)
        {
            uint num = 100;
            switch (itemAtual.Length)
            {
                case 1:
                case 2:
                    if (uint.TryParse(itemAtual, out num))
                    {
                        Simbolo simbolo = new Simbolo()
                        {
                            texto = itemAtual
                        };
                        Token token = new Token()
                        {
                            Simbolo = simbolo,
                            Tipo = TipoToken.NUMERO_INTEIRO
                        };
                        tokenAtual = token;
                    }
                    break;

                case 4:
                    if (itemAtual[1] == '.' &&
                       uint.TryParse(itemAtual[0].ToString(), out num) &&
                      uint.TryParse(itemAtual[2] + itemAtual[3].ToString(), out num))
                    {
                        Simbolo simbolo = new Simbolo()
                        {
                            texto = itemAtual
                        };
                        Token token = new Token()
                        {
                            Simbolo = simbolo,
                            Tipo = TipoToken.NUMERO_REAL
                        };
                        tokenAtual = token;
                    }

                    break;

                case 5:

                    if (itemAtual[2] == '.' &&
                   uint.TryParse(itemAtual[0].ToString() + itemAtual[1].ToString(), out num) &&
                  uint.TryParse(itemAtual[3] + itemAtual[4].ToString(), out num))
                    {
                        Simbolo simbolo = new Simbolo()
                        {
                            texto = itemAtual
                        };
                        Token token = new Token()
                        {
                            Simbolo = simbolo,
                            Tipo = TipoToken.NUMERO_REAL
                        };
                        tokenAtual = token;
                    }
                    break;

                default:
                    break;
            }
        }

        private void bgWorkerIdentificaNumeros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            controleIdentificaNumeros = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;
                return handleParam;
            }
        }
    }
}