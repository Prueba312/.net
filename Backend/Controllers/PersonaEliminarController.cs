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
    public class PersonaEliminarController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PersonaEliminarController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{id}")]
        public JsonResult funciondelete(string id)
        {
            string query = @"delete from personasscc where id = " + id;

            string sqlDataSource = _configuration.GetConnectionString("Connectiondatabase");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Registo Borrado");



        }

    }
}
