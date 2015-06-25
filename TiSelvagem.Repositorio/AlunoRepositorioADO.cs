using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiSelvagem.Dominio;
using TiSelvagem.Repositorio;

namespace TiSelvagem.Repositorio
{
    public class AlunoRepositorioADO
    {
        private Contexto contexto;

        public void Inserir(Aluno aluno)
        {
            string strQuery = string.Format("INSERT INTO Aluno (Nome,Mae,DataNascimento) VALUES ('{0}','{1}','{2}')",
                aluno.Nome, aluno.Mae, aluno.DataNascimento);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Alterar(Aluno aluno)
        {
            var strQuery = string.Format("UPDATE Aluno SET Nome = '{0}' , Mae = '{1}' , DataNascimento = '{2}' WHERE AlunoId = {3}", aluno.Nome,
                aluno.Mae, aluno.DataNascimento, aluno.Id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }

        }

        public void Salvar(Aluno aluno)
        {
            if (aluno.Id > 0)
                    Alterar(aluno);
            else
                    Inserir(aluno);
        }
        public void Deletar(int id)
        {
            var strQuery = string.Format("DELETE FROM Aluno WHERE AlunoId = {0}", id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public List<Aluno> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var sqlQuery = "SELECT * FROM Aluno";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(sqlQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }

        }

        public Aluno ListarAlunoPorId(int id)
        {
            using (contexto = new Contexto())
            {
                string strQuery = string.Format("SELECT * FROM Aluno WHERE AlunoId = {0}", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }
        private List<Aluno> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var alunos = new List<Aluno>();
            while (reader.Read())
            {
                alunos.Add(new Aluno()
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nome = reader[1].ToString(),
                    Mae = reader[2].ToString(),
                    DataNascimento = DateTime.Parse(reader[3].ToString())
                });
            }
            reader.Close();
            return alunos;
        }
    }
}
