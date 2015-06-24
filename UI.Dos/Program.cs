using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using TiSelvagem.Aplicacao;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
           

            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o nome da mae do aluno: ");
            string mae = Console.ReadLine();
            Console.Write("Digite a data de nascimento: ");
            string dtNascimento = Console.ReadLine();


        
            var dados = new AlunoAplicacao().ListarTodos();
            foreach (var aluno in dados)
            {
                Console.WriteLine("Id: {0} \nNome: {1}\nMae: {2}\nData de Nascimento: {3}", aluno.Id,aluno.Nome,aluno.Mae,aluno.DataNascimento);
            }

            Console.ReadKey();
        }
    }
}
