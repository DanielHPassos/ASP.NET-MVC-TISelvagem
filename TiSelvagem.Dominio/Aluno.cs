using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiSelvagem.Dominio
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Mae { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
