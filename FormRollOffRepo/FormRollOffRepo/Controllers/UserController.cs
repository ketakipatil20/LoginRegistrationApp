using FormRollOffRepo.Models;
using FormRollOffRepo.Reository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormRollOffRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly OurExcelDataContext ourExcelDataContext;
        private readonly IUserDetails user;
        public UserController(OurExcelDataContext ourExcelData, IUserDetails _user)
        {
            ourExcelDataContext = ourExcelData;
            user = _user;
        }

        [HttpGet("GetUsers")]
         public async Task<IActionResult> GetUsers()
         {
            var user1 = await user.GetData();
            return Ok(user1);
         }


        [HttpPost("authenticate")]
        public async Task<IActionResult> Authentication([FromBody] Usertable usertable)
        {
            if (usertable == null)
                return BadRequest();
            var user = await ourExcelDataContext.Usertables.FirstOrDefaultAsync(x => x.UserName == usertable.UserName && x.Password == usertable.Password);
            if (user == null)
                return NotFound(new { Message = "User Not Found" });
            return Ok(new
            {
                Message = "Login Success!"
            });

        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] Usertable usertable)
        {
            if (usertable == null)
                return BadRequest();
            await ourExcelDataContext.Usertables.AddAsync(usertable);
            await ourExcelDataContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registered!"
            });
        }
    }
}

