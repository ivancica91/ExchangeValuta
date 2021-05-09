using AutoMapper;
using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _service;
        private readonly UserManager<Korisnik> _userManager;

        public KorisnikController(IKorisnikService service,UserManager<Korisnik> userManager )
        {
            _service = service;
            _userManager = userManager;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<GetUsersDto>> GetAllUsers()
        {
            return await _service.GetAllUsers();
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPut("UpdateUserById/{id}")]
        public async Task PutUser(UpdateUserDto updateUser, [FromRoute] int id)
        {
            await _service.UpdateUser(updateUser, id);
        }


        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("Name={userName}")]
        public async Task<KorisnikDto> GetUserByName(string userName)
        {
            return await _service.GetUserByName(userName);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("{id}")]
        public async Task<KorisnikDto> GetUserById([FromRoute] int id)
        {
            return await _service.GetUserById(id);
        }




        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("AddUser")]
        public async Task<KorisnikDto> AddUser(PostUserDto postUser)
        {
           var user = await _service.PostUser(postUser);

            return user;
        }

        // radio na brzinu pa nisam prebacio u servis
        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("usersWithRoles")]
        public async Task<ActionResult> GetUsersWithRoles()
        {
            var users = await _userManager.Users
                .Include(r => r.UserRoles)
                .ThenInclude(r => r.Role)
                .OrderBy(u => u.UserName)
                .Select(u => new
                {
                    u.Id,
                    UserName = u.UserName,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                })
                .ToListAsync();

            return Ok(users);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("editRoles/{userName}")]
        public async Task EditRoles( string userName, [FromQuery] string role)
        {
            await _service.EditRoles(userName, role);
        }



    }
}
