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
    public class PersonaEditarController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PersonaEditarController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        public JsonResult Post(personasscc per)
        {
            string query = @"Select * from personasscc where id = @id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Connectiondatabase");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id", per.id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);


                    myReader.Close();
                    mycon.Close();
                }
            }

            if (table.Rows.Count > 0)
            {
                string actualizar = @"UPDATE personasscc set Cedula = @Cedula,Nombre = @Nombre,Edad = @Edad,Nacimiento = @Nacimiento,Genero = @Genero,Estado = @Estado where id = @id";
                using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(actualizar, mycon))
                    {
                        myCommand.Parameters.AddWithValue("@id", per.id);
                        myCommand.Parameters.AddWithValue("@Cedula", per.Cedula);
                        myCommand.Parameters.AddWithValue("@Nombre", per.Nombre);
                        myCommand.Parameters.AddWithValue("@Edad", per.Edad);
                        myCommand.Parameters.AddWithValue("@Nacimiento", per.Nacimiento);
                        myCommand.Parameters.AddWithValue("@Genero", per.Genero);
                        myCommand.Parameters.AddWithValue("@Estado", per.Estado);
                        myReader = myCommand.ExecuteReader();


                        myReader.Close();
                        mycon.Close();
                    }
                }
                return new JsonResult("registro editado");

            }

            return new JsonResult("No existe registro");

        }

    }
}
