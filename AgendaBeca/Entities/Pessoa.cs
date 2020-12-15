using System;

namespace AgendaBeca.Entities
{
    class Pessoa
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public float Altura { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(string nome, DateTime dataNascimento, float altura)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Altura = altura;
        }

        public int CalcularIdade()
        {
            DateTime diaAtual = DateTime.Now;
            TimeSpan idadeSemFormatacao = diaAtual.Subtract(DataNascimento);
            string idadeString = (idadeSemFormatacao.TotalDays / 365).ToString("F0");
            int idade = int.Parse(idadeString);
            return idade;
        }

        public override string ToString()
        {
            return "Nome: " + Nome + ", \nData de nascimento: " + DataNascimento.ToShortDateString() + "\nIdade: " + CalcularIdade() + " anos, \nAltura: " + Altura.ToString("F2");
        }
    }
}
