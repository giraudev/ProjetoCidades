using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjetoCidades.Models;

namespace ProjetoCidades.Repositorio
{
    public class CidadeRepositorio
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rd;

        string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=ProjetoCidades; user id = sa; password = senai@123;";

        public List<Cidade> Listar()
        {

            List<Cidade> listCidades = new List<Cidade>();

            con = new SqlConnection(connectionString);
            string SqlQuery = "select * from Cidades";

            //passo o comando onde indico onde a query será conectada
            cmd = new SqlCommand(SqlQuery, con);
            con.Open();
            rd = cmd.ExecuteReader();

            //loop para add dados na lista
            while (rd.Read())
            {
                Cidade cidade = new Cidade();
                cidade.Id = Convert.ToInt16(rd["id"]);
                cidade.Nome = rd["Nome"].ToString();
                cidade.Estado = rd["Estado"].ToString();
                cidade.Habitantes = Convert.ToInt16(rd["Habitantes"]);

                listCidades.Add(cidade);
            }

            con.Close();

            return listCidades;
        }

        public List<Cidade> Cadastrar(Cidade cidade)
        {

            List<Cidade> listCidades = new List<Cidade>();

            con = new SqlConnection(connectionString);
            //colocamos '+" para strings, se for habitantes nao precisa de '
            string SqlQuery = "insert into Cidades (Nome, Estado, Habitantes) values ('" + cidade.Nome + "','" + cidade.Estado + "'," + cidade.Habitantes + ")";
            cmd = new SqlCommand(SqlQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return listCidades;
        }

        public Cidade ListarCidades(int id)
        {
            Cidade cidade = new Cidade();
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cidades where Id = @i order by Id";
                cmd.Parameters.AddWithValue("@i", id);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    cidade.Id = rd.GetInt32(0);
                    cidade.Nome = rd.GetString(1);
                    cidade.Estado = rd.GetString(2);
                    cidade.Habitantes = rd.GetInt32(3);
                }
            }
            catch (SqlException se)
            {
                throw new Exception(
                    "Erro ao tentar ler a tabela de cidades" + se.Message);
            }
            catch (Exception e)
            {
                throw new Exception(
                    "Erro ao tentar ler a tabela de cidades" + e.Message
                );
            }
            finally
            {
                con.Close();
            }
            return cidade;
        }
    

    public string Editar(Cidade cidade)
    {
        string msg="";
        try
        {
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update Cidades set Nome = @n, Estado = @e , Habitantes = @h where Id = @i";
            cmd.Parameters.AddWithValue("@n", cidade.Nome);
            cmd.Parameters.AddWithValue("@e", cidade.Estado);
            cmd.Parameters.AddWithValue("@h", cidade.Habitantes);
            cmd.Parameters.AddWithValue("@i", cidade.Id);
            con.Open();

            int r = cmd.ExecuteNonQuery();

            if (r > 0)
                msg = "Atualização Efetuada";
            else
                msg = "Não foi possível atualizar";
            cmd.Parameters.Clear();

        }
        catch (SqlException se)
        {
            throw new Exception("Erro ao tentar atualizar dados " + se.Message);
        }
        catch (System.Exception e)
        {
            throw new Exception("Erro ao tentar atualizar dados " + e.Message);
        }
        finally
        {
            con.Close();
        }

        return msg;
    }

    public string Excluir(int id){
        string msg="";

        try{
            con = new SqlConnection(connectionString);
            con.Open();
            cmd=new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Cidades where id=@i";
            cmd.Parameters.AddWithValue("@i",id);
            int r = cmd.ExecuteNonQuery();

            if(r>0)
            msg = "Registro apagado.";
            else
            msg = "Não foi possível apagar";

            cmd.Parameters.Clear();
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar apagar os dados na tabela. "+se.Message);
            }
            catch(Exception e){
                throw new Exception("Erro ao tentar apagar os dados na tabela. "+e.Message);
            }
            finally{
                con.Close();
            }
            return msg;
    }
}
}
