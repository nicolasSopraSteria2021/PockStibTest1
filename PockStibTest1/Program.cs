using LumenWorks.Framework.IO.Csv;
using PockStibTest1.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PockStibTest1
{
    class Program
    {
        static void Main(string[] args)
        {


            //ouvre la connexion
            SqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {

                //creation du variable qui va prendre le contenue du fichier CSV
                var csvTable = new DataTable();
                
                //passage du chemin absolu du fichier ainsi que son extension 
                //true = readonly  / false = on peut modifier
                using (var csvReader = new CsvReader(new StreamReader(File.OpenRead(@"C:\Data\final_data.csv")), true))
                {
                    csvTable.Load(csvReader);

                }
                //creation de la requete sql 
               string sql = "Insert into line (date_observation,delays,trip_headsign,stop_name,lineNumber,vehiculeType,precip1Hour" +
                    ",precip24Hour,precip6Hour,relativeHumidity,snow1Hour,snow24Hour,snow6Hour,temperature,temperatureDewPoint,temperatureFeelsLike" +
                    ",temperatureMax24Hour,temperatureMin24Hour,uvIndex,visibility,windSpeed,prediction) "
                                           + " values (@dateOb,@delays,@trip,@stop_name,@lineNumber,@vehiculeType,@precip1Hour,@precip24Hour" +
                                           ",@precip6Hour,@relativeHumidity,@snow1Hour,@snow24Hour,@snow6Hour,@temperature,@temperatureDewPoint" +
                                           ",@temperatureFeelsLike,@temperatureMax24Hour,@temperatureMin24Hour,@uvIndex,@visibility,@windSpeed" +
                                           ",@prediction)";

               
                //on va parcourir l'entiereté du fichier csv pour avoir le nombre de ligne 
                for (int i =0; i < csvTable.Rows.Count; i++)
                {
                    //creation d'une commande sql
                   SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = sql;

                    //ajout des valeurs aux paramètres de la requetes sql ou "i" est l'index des lignes
                    cmd.Parameters.Add("@dateOb", SqlDbType.DateTime).Value = csvTable.Rows[i][0].ToString();
                    cmd.Parameters.Add("@delays", SqlDbType.Int).Value = Convert.ToInt32(csvTable.Rows[i][1].ToString());
                    cmd.Parameters.Add("@lineNumber", SqlDbType.Int).Value = Convert.ToInt32(csvTable.Rows[i][2].ToString());
                    cmd.Parameters.Add("@vehiculeType", SqlDbType.VarChar).Value = csvTable.Rows[i][3].ToString();
                    cmd.Parameters.Add("@precip1Hour", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][4].ToString());
                    cmd.Parameters.Add("@precip24Hour", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][5].ToString());
                    cmd.Parameters.Add("@precip6Hour", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][6].ToString());
                    cmd.Parameters.Add("@prediction", SqlDbType.Int).Value = Convert.ToInt32(csvTable.Rows[i][7].ToString());
                   cmd.Parameters.Add("@relativeHumidity", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][8].ToString());
                    cmd.Parameters.Add("@snow1Hour", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][9].ToString());
                    cmd.Parameters.Add("@snow24Hour", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][10].ToString());
                    cmd.Parameters.Add("@snow6Hour", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][11].ToString());
                    cmd.Parameters.Add("@stop_name", SqlDbType.VarChar).Value = csvTable.Rows[i][12].ToString();
                    cmd.Parameters.Add("@temperature", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][13].ToString());
                    cmd.Parameters.Add("@temperatureDewPoint", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][14].ToString());
                    cmd.Parameters.Add("@temperatureFeelsLike", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][15].ToString());
                    cmd.Parameters.Add("@temperatureMax24Hour", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][16].ToString());
                    cmd.Parameters.Add("@temperatureMin24Hour", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][17].ToString());
                    cmd.Parameters.Add("@trip", SqlDbType.VarChar).Value = csvTable.Rows[i][19].ToString();
                    cmd.Parameters.Add("@uvIndex", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][20].ToString());
                    cmd.Parameters.Add("@visibility", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][21].ToString());
                    cmd.Parameters.Add("@windSpeed", SqlDbType.Float).Value = Convert.ToDouble(csvTable.Rows[i][23].ToString());
                  
                    // Exécutez Commande
                    cmd.ExecuteNonQuery();
                    Console.WriteLine(i + " Donnée enregistré "); 

                }

            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }

            Console.Read();
            
       
           
        }

    }
}

