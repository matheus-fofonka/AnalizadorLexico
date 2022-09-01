using System.Collections.Generic;
using System.ComponentModel;
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
                            Simbolo = new Simbolo() { texto = linha.ToString() },
                            Tipo = TipoToken.ERRO
                        };
                    }
                }

                if (tokenAtual.Tipo != TipoToken.ERRO)
                {
                    if (tokenAtual.Tipo == TipoToken.IDENTIFICADOR)
                    {
                        if (!ListaSimbolos.Contains(tokenAtual.Simbolo))
                            ListaSimbolos.Add(tokenAtual.Simbolo);
                    }
                    else
                        ListaSimbolos.Add(tokenAtual.Simbolo);

                    ListaTokens.Add(tokenAtual);
                }
                else
                {
                    ListaErros.Add(tokenAtual);
                }

                linha++;
            }

            var a = 0;
        }

        private void bgWorkerIdentificaTextos_DoWork(object sender, DoWorkEventArgs e)
        {
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
                   uint.TryParse(itemAtual[0].ToString()+ itemAtual[1].ToString(), out num) &&
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