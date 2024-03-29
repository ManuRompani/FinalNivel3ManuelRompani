﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace AccesoDatos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        //Constructor, inicia conexion y comando
        public AccesoDatos()
        {
            conexion = new SqlConnection("workstation id=CATALOGO_WEB_ROMPANI.mssql.somee.com;packet size=4096;user id=ManuelRompani_SQLLogin_1;pwd=w1mwf5n77t;data source=CATALOGO_WEB_ROMPANI.mssql.somee.com;persist security info=False;initial catalog=CATALOGO_WEB_ROMPANI");
            comando = new SqlCommand();
        }

        //Envia consulta a la BD
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }


        //Almacena la devolucion de la BD
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Cierra conexion
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public void setearParametros(string parametro, object valor)
        {
            comando.Parameters.AddWithValue(parametro, valor);
        }

        public void insertarDatos()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public int ejecutarAccionSacalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

    }
}
