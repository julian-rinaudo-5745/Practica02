using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Practica02.DTOs;
using Practica02.Interfaces;
using Practica02.Models;

namespace Practica02.Repository
{
    public class ArticuloRepository : IAplicacion
    {
        const string CNN_STRING = "Server=localhost;Database={database}};User Id={userName};Password={userPass};TrustServerCertificate=True;";

        public void Agregar(CrearArticuloDto articulo)
        {
            using (var cnn = new SqlConnection(CNN_STRING))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("SP_INSERTAR_ARTICULO", cnn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("nombre", articulo.Nombre);
                cmd.Parameters.AddWithValue("precio_unitario", articulo.PrecioUnitario);

                int filasAfectadas = cmd.ExecuteNonQuery();

            }

        }

        public void Editar(int id, EditarArticuloDto articulo)
        {

            using (var cnn = new SqlConnection(CNN_STRING))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("SP_EDITAR_ARTICULO", cnn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("nombre", articulo.Nombre);
                cmd.Parameters.AddWithValue("precio_unitario", articulo.PrecioUnitario);

                int filasAfectadas = cmd.ExecuteNonQuery();

            };

        }

        public void Eliminar(int id)
        {
            using (var cnn = new SqlConnection(CNN_STRING))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("SP_ELIMINAR_ARTICULO", cnn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("id", id);

                cmd.ExecuteNonQuery();

            }
        }

        public List<Articulo> ObtenerTodos()
        {
            List<Articulo> listArticulos = new List<Articulo>();


            using (var cnn = new SqlConnection(CNN_STRING))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("SP_OBTENER_ARTICULOS", cnn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Articulo articulo = new Articulo()
                    {
                        Id = (int)reader["id"],
                        Nombre = (string)reader["nombre"],
                        PrecioUnitario = (decimal)reader["precio_unitario"]
                    };

                    listArticulos.Add(articulo);
                }

            }

            return listArticulos;
        }

        public Articulo ObtenerPorId(int id)
        {
            Articulo articulo = new Articulo();


            using (var cnn = new SqlConnection(CNN_STRING))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("SP_OBTENER_ARTICULO", cnn);

                cmd.Parameters.AddWithValue("id", id);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    articulo.Id = (int)reader["id"];
                    articulo.Nombre = (string)reader["nombre"];
                    articulo.PrecioUnitario = (decimal)reader["precio_unitario"];

                }

            }

            return articulo;

        }
    }
}