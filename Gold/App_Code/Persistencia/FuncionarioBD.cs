using Gold.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Gold.Persistencia
{

    /// <summary>
    /// Summary description for FuncionarioBD
    /// </summary>
    public class FuncionarioBD
    {

        public bool Insert(Funcionario funcionario)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO TBL_FUNCIONARIO (FUN_ID, FUN_NOME, FUN_CPF, FUN_SENHA, FUN_ATIVADO) VALUES (?id, ?nome, ?cpf, ?senha, ?ativado)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?id", funcionario.ID));
            objCommand.Parameters.Add(Mapped.Parameter("?nome", funcionario.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?cpf", funcionario.CPF));
            objCommand.Parameters.Add(Mapped.Parameter("?senha", funcionario.Senha));
            objCommand.Parameters.Add(Mapped.Parameter("?ativado", funcionario.Ativado));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }


        public Funcionario Select(int id)
        {
            Funcionario obj = null;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM TBL_FUNCIONARIO WHERE FUN_ID = ?codigo", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Funcionario();
                obj.ID = Convert.ToInt32(objDataReader["FUN_ID"]);
                obj.Nome = Convert.ToString(objDataReader["FUN_NOME"]);
                obj.CPF = Convert.ToInt32(objDataReader["FUN_CPF"]);
                obj.Ativado = Convert.ToBoolean(objDataReader["FUN_ATIVADO"]);
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return obj;
        }

        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM TBL_FUNCIONARIO", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }



        public int Logar(string CPF, string Senha)
        {
            int codigo = 0;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM TBL_FUNCIONARIO WHERE FUN_CPF = ?cpf AND FUN_SENHA= ?senha FUN_ATIVADO=1", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cpf", CPF));
            objCommand.Parameters.Add(Mapped.Parameter("?senha", Senha));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                codigo = Convert.ToInt32(objDataReader["FUN_ID"]);
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return codigo;
        }


        public FuncionarioBD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

}