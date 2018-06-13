using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public string Index()
        {
            return "hello user index!";
        }

        //新增用户
        public string addUser(string userName, string password)
        {


            return "success!";

        }




    }
}