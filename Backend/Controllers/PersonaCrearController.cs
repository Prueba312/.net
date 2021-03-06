using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaCrearController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PersonaCrearController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public JsonResult Post(personasscc per)
        {
            string query = @"insert into personasscc (Cedula,Nombre,Edad,Nacimiento,Genero,Estado) values (@Cedula,@Nombre,@Edad,@Nacimiento,@Genero,@Estado)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Connectiondatabase");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Cedula", per.Cedula);
                    myCommand.Parameters.AddWithValue("@Nombre", per.Nombre);
                    myCommand.Parameters.AddWithValue("@Edad", per.Edad);
                    myCommand.Parameters.AddWithValue("@Nacimiento", per.Nacimiento);
                    myCommand.Parameters.AddWithValue("@Genero", per.Genero);
                    myCommand.Parameters.AddWithValue("@Estado", per.Estado);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Contenido agregado");

        }
    }
}
