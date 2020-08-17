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

        public IEnumerable<Dota> GetAllCharacters()
        {
            var DotaData = new List<Dota>();
            {
                //string _connectionString = ConfigurationManager.ConnectionStrings["DotaConnection"].ConnectionString;
                string _connectionString = "Server=localhost\\SQLEXPRESS;Database=DotaHeroes;Trusted_Connection=True;MultipleActiveResultSets=true";
                using SqlConnection con = new SqlConnection(_connectionString);
                using var command = new SqlCommand("select * from DotaChampions", con);
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
    }
}
