using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace TiSelvagem.Dominio
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome do aluno")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o nome da mãe do aluno")]
        [DisplayName("Mãe")]
        public string Mae { get; set; }

        [Required(ErrorMessage = "Preencha a data de nascimento do aluno")]
        [DisplayName("Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
    }
}
