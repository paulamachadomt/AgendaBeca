using System;
using System.Collections.Generic;
using System.Globalization;

namespace AgendaBeca.Entities
{
    class Agenda
    {
        private List<Pessoa> ListaPessoas { get; set; }
        private bool Logged { get; set; }

        public Agenda()
        {
            ListaPessoas = new List<Pessoa>();
        }

        public void Menu()
        {         
            Logged = true;

            while (Logged)
            {

                Console.WriteLine("================AGENDA BECA .NET================");
                Console.WriteLine();
                Console.WriteLine("Digite o número conforme a opção desejada: ");
                Console.WriteLine();
                Console.WriteLine("Opção 1: Cadastrar uma pessoa na agenda");
                Console.WriteLine("Opção 2: Exibir os dados de uma pessoa cadastrada na agenda");
                Console.WriteLine("Opção 3: Exibir os dados de todas as pessoas cadastradas na agenda");
                Console.WriteLine("Opção 4: Remover uma pessoa da agenda");
                Console.WriteLine("Opção 5: Sair da agenda");

                int opcaoMenu = int.Parse(Console.ReadLine());

                int index = -1;

                switch (opcaoMenu)
                {
                    case 1:
                        CadastraPessoas();
                        break;
                    case 2:
                        index = BuscaPessoa();
                        ImprimePessoa(index);
                        break;
                    case 3:
                        ImprimeAgenda();
                        break;
                    case 4:
                        index = BuscaPessoa();
                        RemovePessoa(index);
                        break;
                    case 5:
                        Console.WriteLine("Obrigada por utilizar a Agenda Beca .Net!");
                        Logged = false;
                        Console.Read();
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Verifique o menu e tente novamente...");
                        Console.Clear();
                        Menu();
                        break;
                }
            }
        }

        public void CadastraPessoas()
        {
            Console.Clear();

            int quantidadePessoas = 0;

            string escolha = "s".ToLower();

            while (escolha == "s" && quantidadePessoas < 10)
            {

                Pessoa pessoa = new Pessoa();
                Console.WriteLine("Digite os dados para o cadastro: ");
                Console.WriteLine();
                Console.Write("Nome: ");
                string nome = Console.ReadLine().ToLower();

                Console.Write("Data de nascimento (ano/mês/dia): ");
                DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

                Console.Write("Altura (Ex: 1.65): ");
                float altura = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                pessoa.Nome = nome;
                pessoa.DataNascimento = dataNascimento;
                pessoa.Altura = altura;

                ArmazenaPessoa(pessoa);

                Console.WriteLine("Cadastro efetuado com sucesso!");

                Console.WriteLine();

                Console.Write("Deseja cadastrar mais alguém? (S/N) ");

                escolha = Console.ReadLine().ToLower();

                if (escolha == "s")
                {
                    escolha = "s";
                }
                else
                {
                    escolha = "n";
                }
                Console.Clear();

                if (quantidadePessoas > 10)
                {
                    Console.WriteLine("Agenda cheia!");
                }
            }
        }

        public void ArmazenaPessoa(Pessoa pessoa)
        {
            ListaPessoas.Add(pessoa);
        }
        
        public int BuscaPessoa()
        {
            int index = -1;
            if (ListaPessoas.Count == 0)
            {
                Console.WriteLine("Agenda ainda está vazia!");
            }
            else
            {
                Console.Write("Digite o nome da pessoa cadastrada na agenda: ");
                string nome = Console.ReadLine().ToLower();                           

                for (int i = 0; i < ListaPessoas.Count; i++)
                {
                    if (ListaPessoas[i].Nome.Equals(nome))
                    {
                        index = i;
                    }
                    else if (!ListaPessoas[i].Nome.Equals(nome))
                    {
                        Console.Write("Pessoa não encontrada... Verifique e tente novamente.");
                    }
                }
            }           
            return index;
        }
        
        public void ImprimePessoa(int index)
        {
            try
            {
                Console.WriteLine(ListaPessoas[index].ToString());
                Console.WriteLine();
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Ocorreu um erro...");
            }           
        }

        public void ImprimeAgenda()
        {
            Console.Clear();
            foreach (Pessoa pessoa in ListaPessoas)
            {
                Console.WriteLine(pessoa.ToString());
                Console.WriteLine();
                Console.ReadLine();
            }
        }

        public void RemovePessoa(int index)
        {
            try
            {
                Console.Clear();
                ListaPessoas.RemoveAt(index);
                Console.WriteLine("Item excluído com sucesso!");
                Console.WriteLine();
                Console.ReadLine();
                
            }
            catch (Exception)
            {
                Console.WriteLine("Ocorreu um erro...");
                Console.WriteLine();
                Console.ReadLine();
            }        

        }
    }
}
