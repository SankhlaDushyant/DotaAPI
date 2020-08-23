using DotaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace DotaAPI.Data
{
    public class SqlDotaRepoWithoutEf : IDotaRepo
    {
        //private readonly string _connectionString =  ConfigurationManager.ConnectionStrings["DotaConnection"].ConnectionString; //needs a data type<----

        public IEnumerable<Dota> GetAllCharacters() //list 
        {
            var DotaData = new List<Dota>();
            {
                //string _connectionString = ConfigurationManager.ConnectionStrings["DotaConnection"].ConnectionString;
                // read config file
                string _connectionString = "Server=localhost\\SQLEXPRESS;Database=DotaHeroes;Trusted_Connection=True;MultipleActiveResultSets=true"; //1
                using SqlConnection con = new SqlConnection(_connectionString);
                using var command = new SqlCommand("select * from DotaChampions", con); //2
                con.Open();
                DbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var DotaModel = new Dota
                    {
                        Id = reader.IsDBNull("id") ? 0 : reader.GetInt32("id"),
                        Character = reader.IsDBNull("character") ? "" : reader.GetString("character"),
                        Power = reader.IsDBNull("power") ? 0 : reader.GetInt32("power"),
                        Type = reader.IsDBNull("type") ? "" : reader.GetString("type")
                    };
                    DotaData.Add(DotaModel);
                }
            };

            return DotaData;
        }

        public Dota GetCharacterbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Dota AddCharacter(Dota Character)
        {
            var DotaData = Character;
            {
                //string _connectionString = ConfigurationManager.ConnectionStrings["DotaConnection"].ConnectionString;
                string _connectionString = "Server=localhost\\SQLEXPRESS;Database=DotaHeroes;Trusted_Connection=True;MultipleActiveResultSets=true";
                using SqlConnection con = new SqlConnection(_connectionString);
                string query = "Insert into DotaChampions values ('" + DotaData.Id + "','" + DotaData.Character + "'," + DotaData.Power + ",'" + DotaData.Type + "')";
                using var command = new SqlCommand(query, con);
                con.Open();
                int reader = command.ExecuteNonQuery();
                con.Close();
            };

            return DotaData;
        }

        public void DeleteCharacter(int id)
        {
            {
                //string _connectionString = ConfigurationManager.ConnectionStrings["DotaConnection"].ConnectionString;
                string _connectionString = "Server=localhost\\SQLEXPRESS;Database=DotaHeroes;Trusted_Connection=True;MultipleActiveResultSets=true";
                using SqlConnection con = new SqlConnection(_connectionString);
                string query = "Delete from DotaChampions where id = "+  id;
                using var command = new SqlCommand(query, con);
                con.Open();
                int reader = command.ExecuteNonQuery();
                con.Close();
            };
        }

        public Dota UpdateCharacter(Dota character)
        {
            var CharacterTemp = character;
            {
                DeleteCharacter(character.Id);
                AddCharacter(CharacterTemp);
            };
            return (CharacterTemp);
        }
    }
}
