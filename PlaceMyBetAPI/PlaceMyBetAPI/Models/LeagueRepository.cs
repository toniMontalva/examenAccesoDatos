using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class LeagueRepository
    {
        // Ejercicio 1
        private MySqlConnection Connect()
        {
            string connString = "Server=34.219.191.133;Port=3306;Database=PlaceMyBet;Uid=examen;password=examen;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);

            return con;
        }

        // Ejercicio 1
        internal List<Leagues> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from leagues";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Leagues liga = null;
                List<Leagues> ligas = new List<Leagues>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3));
                    liga = new Leagues(res.GetString(3), res.GetString(1));
                    ligas.Add(liga);
                }

                con.Close();
                return ligas;
            }
            catch (MySqlException)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }

        // FIN ejercicio 1
    }
}