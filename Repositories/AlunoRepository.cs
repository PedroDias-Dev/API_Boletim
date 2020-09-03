using API_Boletim.Domain;
using API_Boletim.Interfaces;
using APIBoletim.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace API_Boletim.Repositories
{
    public class AlunoRepository : IAluno
    {
        BoletimContext conexao = new BoletimContext();

        SqlCommand cmd = new SqlCommand();
        public Aluno Alterar(int id, Aluno a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Aluno SET Nome = @nome, RA = @ra, Idade = @idade WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA);
            cmd.Parameters.AddWithValue("@idade", a.Idade);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            return a;
        }

        public Aluno BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Aluno WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Aluno aluno = new Aluno();

            while (dados.Read())
            {
                aluno.IdAluno = Convert.ToInt32(dados.GetValue(0));
                aluno.Nome = dados.GetValue(1).ToString();
                aluno.RA = dados.GetValue(2).ToString();
                aluno.Idade = Int32.Parse(dados.GetValue(3).ToString());
            }

            conexao.Desconectar();

            return aluno;
        }

        public Aluno Cadastrar(Aluno a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Aluno (Nome, RA, Idade) " +
                "VALUES" +
                "(@nome, @ra, @idade)";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            cmd.ExecuteNonQuery();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Aluno WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@id", id);

            //Use o NonQuery para comandos DML
            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        
        public List<Aluno> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Aluno";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Aluno> alunos = new List<Aluno>();

            while(dados.Read())
            {
                alunos.Add(
                    new Aluno()
                    {
                        IdAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        RA = dados.GetValue(2).ToString(),
                        Idade = Int32.Parse(dados.GetValue(3).ToString())
                    }
                );
            }

            conexao.Desconectar();

            return alunos;
        }
    }
}
