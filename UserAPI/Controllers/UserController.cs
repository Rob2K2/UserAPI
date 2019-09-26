using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UserAPI.DAL;
using UserAPI.Interfaces.Services;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDAL userDAL = new UserDAL();

        private readonly IUserService _userService;
        private readonly IBusControl _bus;
        private readonly IConfiguration _config;

        public UserController(IUserService userService, IBusControl bus, IConfiguration config)
        {
            _userService = userService;
            _bus = bus;
            _config = config;
        }


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
        //[HttpPost]
        //public IActionResult Post([FromBody] User user)
        //{
        //    bool resultado = userDAL.CrearUsuario(user);

        //    if (!resultado)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(user);
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            //User res = await _userService.AddNewUser(user);

            Uri uri = new Uri($"rabbitmq://localhost/create_user");

            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(user);

            return Ok();

            //return Ok(Microservices.Services.Core.Models.Response<User>.Succeeded(user));
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
