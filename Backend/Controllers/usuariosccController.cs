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
    public class usuariosccController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public usuariosccController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Getlist()
        {
            string query = @"Select * from usuarioscc";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Connectiondatabase");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);

        }


        [HttpGet("{id}")]
        public JsonResult funciondelete(int id)
        {
            string query = @"delete from personasscc where id = 5;";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Connectiondatabase");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("hoola", id);



        }

        [HttpPost]
        public JsonResult Post(usuarioscc usu)
        {
            string query = @"insert into usuarioscc (Usuario,Contraseña) values (@Usuario,@Contraseña)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Connectiondatabase");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Usuario", usu.Usuario);
                    myCommand.Parameters.AddWithValue("@Contraseña", usu.Contraseña);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Usuario Agregado");

        }
    }
}
