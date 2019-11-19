﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class UsuariosRepository
    {

        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);

            return con;
        }

        // Ejercicio 3. Método que obtiene un número de apuestas dado el usuario que hace la apuesta.
        internal int CuantasApuestasTieneElUsuario(int idUsuario)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas where id_usuario=@idUsuario";
            command.Parameters.AddWithValue("@idUsuario", idUsuario);

            int contadorApuestas = 0;

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                // Cada línea que lee es una apuesta que ha hecho el usuario
                while (res.Read())
                {
                    contadorApuestas++;
                }

                con.Close();
                return contadorApuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return -1;
            }
        }

        internal List<Usuario> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuario";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Usuario us = null;
                List<Usuario> usuarios = new List<Usuario>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetDouble(6));
                    us = new Usuario(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetString(4), res.GetInt32(5), res.GetDouble(6));
                    usuarios.Add(us);
                }

                con.Close();                
                return usuarios;
            } catch(MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }

        internal Usuario GetUserByEmail(string email)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuario where email=@email";
            command.Parameters.AddWithValue("@email", email);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Usuario us = null;
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetDouble(6));
                    us = new Usuario(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetString(4), res.GetInt32(5), res.GetDouble(6));
                }

                con.Close();
                return us;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }

        internal Usuario GetUserByUsername(string usr)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuario where nombreUsuario=@usr";
            command.Parameters.AddWithValue("@usr", usr);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Usuario us = null;
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetDouble(6));
                    us = new Usuario(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetString(4), res.GetInt32(5), res.GetDouble(6));
                }

                con.Close();
                return us;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }

    }
}