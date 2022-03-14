using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Contract;

namespace OnionArchCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            this._user = user;
        }

        //Get ALl users
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAllRecords() {

            var response = this._user.GetAllRepo();
            return Ok(response);
        }
        //Get Single record
        [HttpGet("get")]
        public IActionResult GetSingleRecord(long id) {

            return Ok(this._user.GetSingleRepo(id));
        }
        //Add user
        [HttpPost("add")]
        public IActionResult AddUser(User user) {

            return Ok(this._user.AddUserRepo(user));
        }
        //Remove user
        [HttpDelete("delete/{id}")]
        public IActionResult RemoveUser(long id) {

            return Ok(this._user.RemoveUser(id));
        }
        //Update user
        [HttpPut("edit")]
        public IActionResult UpdateUser(User user) {

            return Ok(this._user.UpdateUserRepo(user));
        
        }
    }
}
