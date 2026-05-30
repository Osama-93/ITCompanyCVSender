using ITCompanyCVSenderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Services.UsersSVC;
using Services;
using DataAccessTier.DataAccessModel;
using System.Security.Claims;

namespace ITCompanyCVSenderAPI.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        UserServices services = new UserServices();
        HashPassword hash = new HashPassword();
          JwtService jwtService = new JwtService();
        [HttpPost]
        [Route("login")]
        public IHttpActionResult LogIn(LogInAPI logInAPI)
        {
            var user = services.GetUserIfValid(logInAPI.Email, logInAPI.Password);
            if (user == null) 
                return Unauthorized();

           string token = jwtService.GenerateToken(user);

            return Ok(new
            {
                success = true,
                token = token,
                userId = user.Id,
                Email = user.Email,
                roleId = user.RoleId,
                FullName = user.FName+ " " + user.LName
            });
        }
        [HttpPost]
        [Route("register")]
        public IHttpActionResult Registration(RegistrationDTO dto)
        {
            var existingUser = services.Get(dto.Email);
            if (existingUser != null)
                return BadRequest("Email already exist");
            User user = new User
            {
                FName = dto.FName,
                LName = dto.Lname,
                Email = dto.Email,
                PasswordHash = hash.Hash(dto.Password),
                RoleId = 2,
            };

            services.Add(user);

            return Ok(new { success = true , message = "User registered successfully"});
        }
        [System.Web.Http.Authorize]
        [HttpGet]
        [Route("me")]
        public IHttpActionResult Me()
        {
            var identity =(ClaimsIdentity)User.Identity;
            return Ok(new
            {
                UserId = identity.FindFirst("UserId")?.Value,
                Email = identity.FindFirst("Email")?.Value,
                RoleId = identity.FindFirst("RoleId")?.Value,
            });
        }
    }
}
