using System;
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
            string SqlQuery = "insert into Cidades (Nome, Estado, Habitantes) values ('"+cidade.Nome+"','"+cidade.Estado+"',"+cidade.Habitantes+")";
            cmd = new SqlCommand(SqlQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return listCidades;
        }
    }
}
