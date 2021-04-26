using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public KorisnikController(IKorisnikService service)
        {
            _service = service;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<GetUsersDto>> GetAllUsers()
        {
            return await _service.GetAllUsers();
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPut("UpdateUserById")]
        public async Task PutUser(UpdateUserDto updateUser)
        {
            await _service.UpdateUser(updateUser);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("AddUser")]
        public async Task<KorisnikDto> AddUser(PostUserDto postUser)
        {
           var user = await _service.PostUser(postUser);

            return user;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("editRoles")]
        public async Task EditRoles([FromQuery] string userName, [FromQuery] string role)
        {
            await _service.EditRoles(userName, role);
        }



    }
}
