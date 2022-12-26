using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDAPIProject.Model;
using CRUDAPIProject.Repository;

namespace CRUDAPIProject.Controllers
{
    
    [ApiController]
    [Route("api/user")]
    public class UserController :ControllerBase
    {
         IUser _users;
        public UserController(IUser users)
        {
            _users = users;
        }

     [HttpPost]
     [Route("add")]
        public void AddUser(AddUserInPutModel model)

        {
         
       _users.InsertUser(model);

        }

         [Route("update")]
         [HttpPost]
         public void UpdateUser(EditUserInPutModel model)
        {
          _users.UpdateUser(model);
        }

        [Route("delete")]
        [HttpDelete]
       public void DeleteUser(DeleteUserInPutModel model)

        {
             
               _users.DeleteUser(model);

        }

       [HttpGet]
       [Route("getusers")]
        public List<Users> GetUsers()
        {
        return _users.GetUsers();
        }

        // [HttpGet]
        // [Route("getuserbyid")]
        // public IActionResult Get(int Id)
        // {
        //GetUserInPutModel model=new GetUserInPutModel();
        //model.Id=Id;
        //     Users u = _users.GetUser(model);
        //     if (u == null)
        //         return NotFound();
        //     else
        //         return Ok(u);
        // }
        [HttpGet]
        [Route("getuserbyid")]
        public Users Get(int Id)
        {
           // GetUserInPutModel model = new GetUserInPutModel();
           // model.Id = Id;
            Users u = _users.GetUser(Id);
            
                return u;
        }
    }
}