using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.DAL;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDAL userDAL = new UserDAL();

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var listado = userDAL.ListarUsuarios().ToList();

            return listado;
        }
              
        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var user = userDAL.ObtenerUsuario(id);

            if (user.UserID == 0)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            bool resultado = userDAL.CrearUsuario(user);

            if (!resultado)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        //[HttpPut("{option}")]
        //public IActionResult Put(string option, [FromBody] User user)
        //{
        //    var userKudos = userDAL.ObtenerUsuario(user.UserID);
        //    int totalKudos = userKudos.TotalKudos;

        //    if (option == "add")
        //    {
        //        totalKudos++;
        //    }
        //    else
        //    {
        //        totalKudos--;
        //    }

        //    bool resultado = userDAL.UpdateUserKudos(user.UserID, totalKudos);

        //    if (!resultado)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok();
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool resultado = userDAL.EliminarUsuario(id);

            if (!resultado)
            {
                return NotFound();
            }

            return Ok();
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] User user)
        //{
        //    if (user.UserID != id)
        //    {
        //        return BadRequest();
        //    }

        //    bool resultado = userDAL.ActualizarUsuario(user);

        //    if (!resultado)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok();
        //}
    }
}
