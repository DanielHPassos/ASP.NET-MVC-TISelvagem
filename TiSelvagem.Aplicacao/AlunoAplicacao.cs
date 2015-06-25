using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiSelvagem.Dominio;
using TiSelvagem.Repositorio;

namespace TiSelvagem.Aplicacao
{
    public class AlunoAplicacao
    {
        private readonly AlunoRepositorioADO repositorio;

        public AlunoAplicacao()
        {
            repositorio = new AlunoRepositorioADO();
        }
        public void Salvar(Aluno aluno)
        {
            repositorio.Salvar(aluno);
        }
        public void Deletar(int id)
        {
            repositorio.Deletar(id);
        }

        public List<Aluno> ListarTodos()
        {
           return repositorio.ListarTodos();

        }

        public Aluno ListarAlunoPorId(int id)
        {
            return repositorio.ListarAlunoPorId(id);
        }
        
    }
}
