using static teste_temp.Program;

namespace teste_temp
{
    internal class Program
    {

        public struct DadosCadastrais 
        {
            public string nome_da_rua;
            public string nome;
            public UInt32 num_da_casa;
            public DateTime data_de_nasc;
        }

        public enum Retorno_e
        { 
            sucesso = 0,
            excecao = 1,
            sair    = 2,
        }


        static void Main(string[] args)
        {
            List<DadosCadastrais> usuarios_cadastrados = new List<DadosCadastrais>();
            Retorno_e retorno = Retorno_e.sucesso;
            string opcao;


            do
            {
                Console.WriteLine("Bem-Vindo ao sistema de cadastro");
                Console.WriteLine("Menu");
                Console.WriteLine("[C] Cadastar \n[S] sair");

                opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();

                Console.Clear();

                if (opcao == "c")
                {

                    Exibir_mensagens("Você iniciou o cadastro de usuarios, pressione qualquer tecla.");
                    Cadastrar(ref usuarios_cadastrados);
                    retorno = Retorno_e.sucesso;
                } 
                else if(opcao == "s")
                {
                    Exibir_mensagens("Você encerrou o programa.");
                    retorno = Retorno_e.sair;
                }
                else
                {
                    Exibir_mensagens("Parece que você tentou um comando que não existe. Tente novamente");
                }


            } while (retorno != Retorno_e.sair);
        }

        public static void Exibir_mensagens (string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.ReadLine(); 
            Console.Clear();

        }

        public static void Cadastrar(ref List<DadosCadastrais> usuarios_cadastrados)
        {
            DadosCadastrais usuario_atual;

            usuario_atual.nome = "";
            usuario_atual.nome_da_rua = "";
            usuario_atual.num_da_casa = 0;
            usuario_atual.data_de_nasc = new DateTime();

            if (PegarString(ref usuario_atual.nome, "Informe o nome do usuario.", "O nome do usuario é:") != Retorno_e.sucesso)
            {
                return;   
            }
            if (PegarString(ref usuario_atual.nome_da_rua, "Informe o nome da rua.", "O nome da rua é:") != Retorno_e.sucesso)
            {
                return;
            }
            if (PegarNumero(ref usuario_atual.num_da_casa, "Informe o numero da casa.", "O numero da casa é:") != Retorno_e.sucesso)
            {
                return;
            }
            if (PegarData(ref usuario_atual.data_de_nasc, "Informe a data de nascimento como dd/mm/aa.", "A data de nascimento é:") != Retorno_e.sucesso)
            {
                return;
            }

            usuarios_cadastrados.Add(usuario_atual);
        
        }

        public static Retorno_e PegarString(ref string minhaString, string mensagem, string confirmação)
        {
            Retorno_e retorno = Retorno_e.sucesso;
            string temp;
            string opcao;

            do
            {
                Console.WriteLine(mensagem);
                temp = Console.ReadLine();
                Console.Clear();


                Console.WriteLine(confirmação + temp);
                Console.WriteLine("[C] Confirmar \n[T] Tentar de novo. \n[S] sair.");
                opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();


                Console.Clear();
                if (opcao == "c") 
                {
                    minhaString = temp;

                    Exibir_mensagens("Nome do usuario cadastrado!!! pressione enter.");
                    retorno = Retorno_e.sucesso;
                }
                else if (opcao == "t")
                {
                    retorno = Retorno_e.excecao;
                }
                else if (opcao == "s")
                {
                    Exibir_mensagens("Você está voltando para o menu.");
                    retorno = Retorno_e.sair;
                }
                else
                {
                    Exibir_mensagens("Parece que você tentou um comando que não existe. Tente novamente!");
                    retorno = Retorno_e.excecao;
                }
                

            } while (retorno == Retorno_e.excecao);


            return retorno;
        }

        public static Retorno_e PegarNumero(ref UInt32 meu_numero, string mensagem, string confirmação)
        {
            Retorno_e retorno = Retorno_e.sucesso;
            UInt32 temp;
            string opcao;

            do
            {
                Console.WriteLine(mensagem);
                

                try
                {
                    temp =  Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine(confirmação + temp);
                    Console.WriteLine("[C] Confirmar \n[T] Tentar de novo. \n[S] sair.");
                    opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();


                    Console.Clear();
                    if (opcao == "c")
                    {
                        meu_numero = temp;
                        Exibir_mensagens("Nome do usuario cadastrado!!! pressione enter.");
                        retorno = Retorno_e.sucesso;
                    }
                    else if (opcao == "t")
                    {
                        retorno = Retorno_e.excecao;
                    }
                    else if (opcao == "s")
                    {
                        Exibir_mensagens("Você está voltando para o menu.");
                        retorno = Retorno_e.sair;
                    }
                    else
                    {
                        Exibir_mensagens("Parece que você tentou um comando que não existe. Tente novamente!");
                        retorno = Retorno_e.excecao;
                    }

                }
                catch (Exception)
                {
                    retorno = Retorno_e.excecao;
                    Exibir_mensagens("Houve algum erro no formato da data. Tente novamente!");
                }

            } while (retorno == Retorno_e.excecao);


            return retorno;
        }

        public static Retorno_e PegarData(ref DateTime meu_numero, string mensagem, string confirmação)
        {
            Retorno_e retorno = Retorno_e.sucesso;
            DateTime temp;
            string opcao;

            do
            {
                Console.WriteLine(mensagem);


                try
                {
                    temp = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine(confirmação + temp.Day + temp.Month + temp.Year);
                    Console.WriteLine("[C] Confirmar \n[T] Tentar de novo. \n[S] sair.");
                    opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();


                    Console.Clear();
                    if (opcao == "c")
                    {
                        meu_numero = temp;
                        Exibir_mensagens("Nome do usuario cadastrado!!! pressione enter.");
                        retorno = Retorno_e.sucesso;
                    }
                    else if (opcao == "t")
                    {
                        retorno = Retorno_e.excecao;
                    }
                    else if (opcao == "s")
                    {
                        Exibir_mensagens("Você está voltando para o menu.");
                        retorno = Retorno_e.sair;
                    }
                    else
                    {
                        Exibir_mensagens("Parece que você tentou um comando que não existe. Tente novamente!");
                        retorno = Retorno_e.excecao;
                    }

                }
                catch (Exception)
                {
                    retorno = Retorno_e.excecao;
                    Exibir_mensagens("Apenas números são aceitos. Tente novamente!");
                }

            } while (retorno == Retorno_e.excecao);


            return retorno;
        }
    }
}
