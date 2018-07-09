using System.Collections.Generic;
using System;
using World;
using MySql.Data.MySqlClient;

namespace World.Models
{
    public class City
    {
      private string _city;
      private int _population;

      public City (string City, int Population)
      {
        _city = City;
        _population = Population;
      }

      public string GetCity()
      {
        return _city;
      }

      public int GetPopulation()
      {
        return _population;
      }


      public static List<City> GetAllCity()
      {
        List<City> allCity = new List<City> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM city;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string cityName = rdr.GetString(1);
          int popAmnt = rdr.GetInt32(4);
          City newCity = new City(cityName, popAmnt);
          allCity.Add(newCity);
        }
        conn.Close();
        if(conn != null)
        {
            conn.Dispose();
        }
        return allCity;
      }

      public static List<City> GetSearchCity(string input)
      {
        List<City> allCity = new List<City> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM city WHERE name LIKE (@cityInput);";
        MySqlParameter cityInput = new MySqlParameter();
        cityInput.ParameterName = "@cityInput";
        cityInput.Value = input;
        cmd.Parameters.Add(cityInput);
        
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          string cityName = rdr.GetString(1);
          int popAmnt = rdr.GetInt32(4);
          City newCity = new City(cityName, popAmnt);
          allCity.Add(newCity);
        }
        conn.Close();
        if(conn != null)
        {
          conn.Dispose();
        }
        return allCity;
      }
    }
}
